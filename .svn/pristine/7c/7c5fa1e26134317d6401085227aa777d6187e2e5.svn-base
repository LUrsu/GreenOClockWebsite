using System;
using System.Linq;
using GreenOClock.Data;

namespace GreenOClock.Services
{
    public class CompanyEmployeeService : Service<CompanyEmployee, GreenOClockEntities>
    {
        //these are stored for quick comparison of employee role
        public EmployeeType OwnerType, ManagerType, EmployeeType;

        public CompanyEmployeeService()
        {
            var employeeTypes = new EmployeeTypeService();
            OwnerType = employeeTypes.OwnerType();
            ManagerType = employeeTypes.ManagerType();
            EmployeeType = employeeTypes.EmployeeType();
        }

        public IQueryable<CompanyEmployee> AllActive()
        {
            return All().Where(ce => ce.IsActive);
        }

        public void Add(int companyId, Guid userId, EmployeeType type)
        {
            using (Entities)
            {
                var company = Entities.Companies.Find(companyId);
                var employee = company.CompanyEmployees.FirstOrDefault(ce => ce.UserId == userId);
                //if they aren't in the company already
                if (employee == null)
                {
                    company.CompanyEmployees.Add(new CompanyEmployee
                    {
                        CompanyId = companyId,
                        UserId = userId,
                        EmployeeTypeId = type.Id
                    });
                //if they have left the company
                }else if(!employee.IsActive)
                {
                    employee.IsActive = true;
                //if they are currently in the company
                }else if(employee.IsActive)
                {
                    throw new Exception("User is already a member of this company.");
                }
                Entities.SaveChanges();
            }
        }

        public void Leave(Guid userId, int companyId)
        {
            using (Entities)
            {
                var companyEmployeeId = Entities.Companies.Find(companyId).CompanyEmployees.SingleOrDefault(u => u.User.Id == userId).Id;
                var companyEmployee = Entities.CompanyEmployees.SingleOrDefault(ce => ce.Id == companyEmployeeId);
                
                if(companyEmployee != null)
                {
                    companyEmployee.IsActive = false;
                }
                else
                {
                    throw new Exception("Error leaving company.");
                }

                Entities.SaveChanges();
            }
        }

        public IQueryable<CompanyEmployee> ByCompanyId(int companyId)
        {
            return AllActive().Where(ce => ce.CompanyId == companyId);
        }

        public void UpdateEmployeeTypes(Guid[] userIds, int[] employeeTypeIds, int companyId)
        {
            using (Entities)
            {
                var companyEmployees = Entities.Companies.Find(companyId).CompanyEmployees;

                for (var i = 0; i < userIds.Length; i++)
                {
                    var employee = companyEmployees.FirstOrDefault(ce => ce.UserId == userIds[i]);
                    if (employee != null) employee.EmployeeTypeId = employeeTypeIds[i];
                }

                Entities.SaveChanges();
            }
        }

        public bool UserHasEmployeePriveleges(Guid userId, int companyId)
        {
            return AllActive().FirstOrDefault(
                ce => ce.UserId == userId && ce.CompanyId == companyId && ce.EmployeeTypeId == EmployeeType.Id) != null
                || UserHasManagerPriveleges(userId, companyId);
        }

        public bool UserHasManagerPriveleges(Guid userId, int companyId)
        {
            return AllActive().FirstOrDefault(
                ce => ce.UserId == userId && ce.CompanyId == companyId && ce.EmployeeTypeId == ManagerType.Id) != null
                || UserHasOwnerPriveleges(userId, companyId);
        }

        public bool UserHasOwnerPriveleges(Guid userId, int companyId)
        {
            return AllActive().FirstOrDefault(
                ce => ce.UserId == userId && ce.CompanyId == companyId && ce.EmployeeTypeId == OwnerType.Id) != null;
        }
    }
}
