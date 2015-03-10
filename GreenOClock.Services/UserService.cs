using System;
using System.Linq;
using GreenOClock.Data;

namespace GreenOClock.Services
{
    public interface IUserService : IService<User>
    {
        User ById(Guid userId);
        
        IQueryable<User> ByName(string name);
        IQueryable<User> ByActivityId(int activityId);
        IQueryable<User> ByActivity(Activity activity);
        IQueryable<User> ByCompanyId(int companyId);
        IQueryable<User> ByCompany(Company company);

        bool Update(User user);
        bool Remove(User user);
    }

    public class UserService : Service<User, GreenOClockEntities>, IUserService
    {
        public IQueryable<User> AllActive()
        {
            return All().Where(u => u.IsActive);
        }
        
        public User ById(Guid userId)
        {
            return AllActive().FirstOrDefault(u => u.Id == userId);
        }

        public IQueryable<User> ByName(string name)
        {
            return AllActive().Where(u => (u.FirstName + " " + u.LastName).Contains(name));
        }

        //this returns those users who WORKED ON the activity, not those assigned to it
        public IQueryable<User> ByActivityId(int activityId)
        {
            return AllActive().Where(u => u.GroupProgress.FirstOrDefault(gp => gp.GroupActivity.Id == activityId) != null);
        }

        public IQueryable<User> ByActivity(Activity activity)
        {
            return ByActivityId(activity.Id);
        }

        public IQueryable<User> ByCompanyId(int companyId)
        {
            return AllActive().Where(u => u.CompanyEmployees.FirstOrDefault(cu => cu.CompanyId == companyId) != null);
        }

        //All employees
        public IQueryable<User> ByCompany(Company company)
        {
            return ByCompanyId(company.Id);
        }

        public bool Add(User user)
        {
            try
            {
                Entities.Users.Add(user);
                Save(user);
                return true;
            }
            catch { return false; }
        }

        public bool Update(User user)
        {
            try
            {
                using(Entities)
                {
                    var use = ById(user.Id);
                    use.Id = user.Id;
                    use.FirstName = user.FirstName;
                    use.LastName = user.LastName;

                    Entities.SaveChanges();
                    return true; 
                }
            }
            catch { return false; }
        }

        public bool Remove(User user)
        {
            try
            {
                using (Entities)
                {
                    Entities.Users.Find(user.Id).IsActive = false;
                    Entities.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }
    }
}
