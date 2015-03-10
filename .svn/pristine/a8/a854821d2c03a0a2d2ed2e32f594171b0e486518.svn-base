using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreenOClock.Data;

namespace GreenOClock.Services
{
    public class PersonalActivityService : Service<PersonalActivity, GreenOClockEntities>
    {
        public PersonalActivity ById(int activityId)
        {
            return All().FirstOrDefault(a => a.Id == activityId);
        }

        public IQueryable<PersonalActivity> ByUserId(Guid userId)
        {
            return All().Where(a => a.UserId == userId);
        }

        public IQueryable<PersonalActivity> ByUserIdInactive(Guid userId)
        {
            return ByUserId(userId).Where(a => a.IsActive);
        }

        public IQueryable<PersonalActivity> ByProgressId(int progressId)
        {
            return All().Where(a => a.PersonalProgresses.FirstOrDefault(p => p.Id == progressId) != null);
        }

        protected internal void FinishUpdate(PersonalActivity changes, PersonalActivity activity, GreenOClockEntities entities)
        {
            activity.PersonalProgresses = changes.PersonalProgresses;
        }

        public void EnableActivity(int activityId)
        {
            using (Entities)
            {
                var activity = ById(activityId);
                activity.IsActive = true;
                Entities.SaveChanges();
            }
        }

        public void DeleteActivity(int activityId)
        {
            using(Entities)
            {
                var activity = ById(activityId);
                activity.IsActive = false;
                Entities.SaveChanges();
            }
        }
    }
}
