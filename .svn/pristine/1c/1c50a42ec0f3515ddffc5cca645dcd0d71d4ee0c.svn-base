using System;
using System.Collections.Generic;
using System.Linq;
using GreenOClock.Data;

namespace GreenOClock.Services
{
    public class ActivityService : Service<Activity, GreenOClockEntities>
    {
        public UserService Users { get; set; }
        public GroupActivityService GroupActivityService { get; set; }
        public PersonalActivityService PersonalActivityService { get; set; }

        public ActivityService()
        {
            Users = new UserService();
            GroupActivityService = new GroupActivityService();
            PersonalActivityService = new PersonalActivityService();
        }

        public IQueryable<Activity> AllActive()
        {
            return All().Where(a => a.IsActive);
        } 

        public IQueryable<Activity> AllInactive()
        {
            return All().Where(a => !a.IsActive);
        }

        public Activity ById(int activityId)
        {
            return All().FirstOrDefault(a => a.Id == activityId);
        }

        public IQueryable<Activity> ByName(string name)
        {
            return All().Where(a => a.Name.Contains(name));
        }

        public IQueryable<Activity> ByUserId(Guid userId)
        {
            var activities = new List<Activity>();
            activities.AddRange(GroupActivityService.ByUserId(userId).ToList());
            activities.AddRange(PersonalActivityService.ByUserId(userId).ToList());
            return activities.AsQueryable().OrderBy(a => a.Name);
        }

        public IQueryable<Activity> ByUserIdActive(Guid userId)
        {
            var activities = new List<Activity>();
            activities.AddRange(GroupActivityService.ByUserId(userId).ToList());
            activities.AddRange(PersonalActivityService.ByUserId(userId).ToList());
            return activities.AsQueryable().OrderBy(a => a.Name).Where(a => a.IsActive);
        }

        public IQueryable<Activity> ByUserIdInactive(Guid userId)
        {
            var activities = new List<Activity>();
            activities.AddRange(GroupActivityService.ByUserId(userId).ToList());
            activities.AddRange(PersonalActivityService.ByUserId(userId).ToList());
            return activities.AsQueryable().OrderBy(a => a.Name).Where(a => !a.IsActive);
        }

        public void UpdateActivity(Activity activityToUpdate)
        {
            var activity = ById(activityToUpdate.Id);

            using (Entities)
            {
                activity.Description = activityToUpdate.Description;
                activity.Name = activityToUpdate.Name;
                if (activityToUpdate.GetType().BaseType == typeof(GroupActivity))
                    GroupActivityService.FinishUpdate(activityToUpdate as GroupActivity, activity as GroupActivity, Entities);
                else
                    PersonalActivityService.FinishUpdate(activityToUpdate as PersonalActivity, activity as PersonalActivity, Entities);
                Entities.SaveChanges();
            }
        }

        public void SaveActivity(Activity activityToSave)
        {
            using (Entities)
            {
                Entities.Activities.Add(activityToSave);
                Entities.SaveChanges();
            }
        }

        public void DeleteActivity(int activityId)
        {
            using (Entities)
            {
                var activity = ById(activityId);
                activity.IsActive = false;
                Entities.SaveChanges();
            }
        }
    }
}
