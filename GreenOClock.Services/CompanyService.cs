using System;
using System.Linq;
using GreenOClock.Data;

namespace GreenOClock.Services
{
    public class CompanyService : Service<Company, GreenOClockEntities>
    {
        public EmployeeTypeService EmployeeTypes { get; set; }
        public CompanyEmployeeService CompanyEmployees { get; set; }
        public UserService Users { get; set; }

        public CompanyService()
        {
            EmployeeTypes = new EmployeeTypeService();
            CompanyEmployees = new CompanyEmployeeService();
            Users = new UserService();
        }

        public IQueryable<Company> ByName(string name)
        {
            return All().Where(c => c.Name.Contains(name));
        }

        public Company ById(int companyId)
        {
            return All().FirstOrDefault(c => c.Id == companyId);
        }

        public IQueryable<Company> ByLocation(string location)
        {
            return All().Where(c => c.City.Contains(location) || c.State.Contains(location) || c.Country.Contains(location));
        }

        public IQueryable<Company> ByEmployeeId(Guid userId)
        {
            return All().Where(c => c.CompanyEmployees.FirstOrDefault(u => u.UserId == userId && u.IsActive) != null);
        }

        public void Add(Company company, Guid userId)
        {
            using (Entities)
            {
                var ownerEmployeeType = EmployeeTypes.OwnerType();
                    
                Entities.Companies.Add(company);
                Entities.SaveChanges();

                //sets creator as owner
                CompanyEmployees.Add(company.Id, userId, ownerEmployeeType);
                Entities.SaveChanges();
            }
        }

        public void Update(Company company, Guid userId)
        {
            if(CompanyEmployees.UserHasManagerPriveleges(userId, company.Id))
            {
                using (Entities)
                {
                    var comp = ById(company.Id);
                    comp.City = company.City;
                    comp.State = company.State;
                    comp.Country = company.Country;
                    comp.Name = company.Name;

                    Entities.SaveChanges();
                }
            }
        }
    }
}
