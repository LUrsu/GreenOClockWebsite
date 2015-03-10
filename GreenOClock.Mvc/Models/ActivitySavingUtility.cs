using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Activities;
using GreenOClock.Mvc.Models.Progresses;
using GreenOClock.Mvc.Models.Users;
using GreenOClock.Services;

namespace GreenOClock.Mvc.Models
{
    public class ActivitySavingUtility
    {
        public ActivityService ActivityService { get; set; }
        public UserService UserService { get; set; }

        public ActivitySavingUtility(ActivityService activityService)
        {
            ActivityService = activityService;
            UserService = new UserService();
        }

        public int SaveActivity(ActivityViewModel vm)
        {
            Activity activity;
            if (vm.Id != 0)
            {
                activity = ActivityService.ById(vm.Id);
                activity.Description = vm.Description;
                activity.Name = vm.Name;
                ActivityService.UpdateActivity(activity);
            }
            else
            {
                vm.Progresses = new ProgressesViewModel();
                
                if (vm.GetType() == typeof(PersonalActivityViewModel))
                    activity = vm.AsPersonalActivity();
                else
                    activity = vm.AsGroupActivity();
                ActivityService.SaveActivity(activity);
            }
            return activity.Id;
        }
    }

    static class ActivityExtesions
    {
        public static Activity AsPersonalActivity(this ActivityViewModel vm)
        {
            return new PersonalActivity
            {
                Description = vm.Description,
                Name = vm.Name,
                PersonalProgresses = vm.Progresses.ProgressViewModels.Select(p => (PersonalProgress)p).ToList(),
                UserId = ActiveSessionData.ActiveUser.Id
            };
        }

        public static Activity AsGroupActivity(this ActivityViewModel vm)
        {
            var activity = (GroupActivityViewModel) vm;
            if (activity.GroupMembers == null)
                activity.GroupMembers = new List<GroupMemberViewModel>();

            return new GroupActivity
            {
                Description = vm.Description,
                Name = vm.Name,
                GroupProgresses = vm.Progresses.ProgressViewModels.Select(p => (GroupProgress)p).ToList(),
                CompanyId = activity.Company == null ? activity.CompanyId : activity.Company.Id,
                GroupMembers = activity.GroupMembers.Select(u => new GroupMember(){UserId = u.User.Id, GroupActivityId = activity.Id}).ToList(),
                IsActive = true
            };
        }
    }
}