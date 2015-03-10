using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreenOClock.Data;

namespace GreenOClock.Services
{
    public class ProgressService : Service<Progress, GreenOClockEntities>
    {
        public CompanyEmployeeService CompanyEmployees { get; set; }
        public UserService Users { get; set; }
        public ActivityService ActivityService { get; set; }

        public ProgressService()
        {
            CompanyEmployees = new CompanyEmployeeService();
            Users = new UserService();
            ActivityService = new ActivityService();
        }

        public Progress ById(int progressId)
        {
            return All().FirstOrDefault(p => p.Id == progressId);
        }

        public IQueryable<Progress> ByUserId(Guid userId)
        {
            return All().Where(p => p.UserId == userId);
        }

        public IQueryable<Progress> ByActivityId(int activityId)
        {
            return All().Where(p => p.ActivityId == activityId);
        }

        public Progress ActiveForUser(Guid userId)
        {
            return All().FirstOrDefault(p => p.IsActive && p.UserId == userId);
        }

        public Progress AddProgress(Progress progress)
        {
            if (progress.GetType() == typeof(PersonalProgress))
                return AddPersonalProgress(progress as PersonalProgress);
            else
                return AddGroupProgress(progress as GroupProgress);
        }

        public PersonalProgress AddPersonalProgress(PersonalProgress progress)
        {
            try
            {
                using (Entities)
                {
                    Entities.Progresses.Add(progress);
                    Entities.SaveChanges();
                }
                return progress;
            }
            catch (Exception e)
            {
                throw new Exception("Error adding a personal progress.", e);
            }
        }

        public GroupProgress AddGroupProgress(GroupProgress progress)
        {
            try
            {
                var companyId = ActivityService.GroupActivityService.ById(progress.GroupActivityId).Company.Id;
                if (CompanyEmployees.UserHasEmployeePriveleges(progress.UserId, companyId))
                {
                    using (Entities)
                    {
                        Entities.Progresses.Add(progress);
                        Entities.SaveChanges();
                    }
                    return progress;
                }
                else
                    throw new Exception("user does not have employee priveleges");
            }
            catch (Exception e)
            {
                throw new Exception("Error adding a group progress.", e);
            }
        }

        public void UpdateDescription(Progress progress)
        {
            using (Entities)
            {
                var updated = Entities.Progresses.Find(progress.Id);
                updated.Description = progress.Description;
                Entities.SaveChanges();
            }
        }

        public void UpdateEndTime(Progress progress)
        {
            using (Entities)
            {
                var updated = Entities.Progresses.Find(progress.Id);
                updated.EndTime = progress.EndTime;
                Entities.SaveChanges();
            }
        }

        public void Finish(Progress progress)
        {
            if(progress.IsActive)
                using(Entities)
                {
                    var active = Entities.Progresses.Find(progress.Id);
                    active.Description = progress.Description;
                    active.EndTime = progress.EndTime ?? DateTime.Now;
                    active.IsActive = false;
                    Entities.SaveChanges();
                }
        }
    }
}
