using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenOClock.Data;
using GreenOClock.Mvc.Models;
using GreenOClock.Mvc.Models.Activities;
using GreenOClock.Mvc.Models.Companies;
using GreenOClock.Mvc.Models.Progresses;
using GreenOClock.Mvc.Models.Users;
using GreenOClock.Services;

namespace GreenOClock.Mvc.Controllers
{
    [Authorize]
    public class GroupActivityController : Controller
    {
        public CompanyService CompanyService { get; set; }
        public ActivityService ActivityService { get; set; }
        public GroupActivityService GroupActivities { get; set; }
        public UserService Users { get; set; }

        public GroupActivityController()
        {
            CompanyService = new CompanyService();
            ActivityService = new ActivityService();
            GroupActivities = new GroupActivityService();
            Users = new UserService();
        }

        public ActionResult CompanyActivities(int companyId)
        {
            var groupActivities = CompanyService.ById(companyId).GroupActivities;
            
            return View(new GroupActivitiesViewModel(groupActivities));
        }

        public ActionResult ViewCompanyEmployeeProgress(int companyId)
        {
            var company = new CompanyViewModel(CompanyService.ById(companyId));
            return View(new EmployeeDateTimeSearchModel(company));
        }

        [HttpPost]
        public ActionResult ViewCompanyEmployeeProgress(DateTime start, DateTime end, Guid userId, int companyId)
        {
            var company = CompanyService.ById(companyId);
            var user = new UserService().ById(userId);
            var progresses = user.GroupProgress.Where(p => company.GroupActivities.SingleOrDefault(a => a.Id == p.ActivityId) != null);
            progresses = progresses.Where(p => p.EndTime > start && p.EndTime < end);
            return View("EmployeeProgress", new ProgressesViewModel(progresses.Reverse().ToList()));
        }

        [HttpPost]
        public ActionResult EditGroupActivityUsers(GroupActivityViewModel vm)
        {
            new ActivitySavingUtility(ActivityService).SaveActivity(vm);
            return RedirectToAction("CompanyActivities", new {companyId = vm.CompanyId});
        }

        public ActionResult UpdateActivityMembers(int activityId)
        {
            var activity = GroupActivities.ById(activityId);
            return View(new GroupMembersViewModel(new GroupActivityViewModel(activity)));
        }

        [HttpPost]
        public ActionResult UpdateActivityMembers(GroupMembersViewModel memberList)
        {
            try
            {
                var newMembersIds = memberList.GroupMembers.Where(m => m.IsGroupMember).Select(m => m.User.Id).ToList();

                GroupActivities.UpdateGroupMembers(newMembersIds, memberList.ActivityId);
                
                TempData["Message"] = "Updated activity members.";
                return RedirectToAction("GroupActivityDetails", "Activity", new {activityId = memberList.ActivityId});
            }catch
            {
                TempData["Message"] = "Error updating group members.";
                return View(memberList);
            }
        }
    }
}
