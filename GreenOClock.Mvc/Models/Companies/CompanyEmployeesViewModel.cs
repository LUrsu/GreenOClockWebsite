using System.Collections.Generic;
using System.Linq;
using GreenOClock.Data;

namespace GreenOClock.Mvc.Models.Companies
{
    public class CompanyEmployeesViewModel
    {
        public IQueryable<CompanyEmployeeViewModel> CompanyEmployees { get; set; }
        public int CompanyId { get; set; }

        public CompanyEmployeesViewModel(IQueryable<CompanyEmployeeViewModel> companyEmployees, int companyId)
        {
            CompanyEmployees = companyEmployees;
            CompanyId = companyId;
        }

        public CompanyEmployeesViewModel(IQueryable<CompanyEmployee> companyEmployees, int companyId)
        {
            CompanyEmployees = companyEmployees.Select(ce => new CompanyEmployeeViewModel(ce));
            CompanyId = companyId;
        }

        public CompanyEmployeesViewModel()
        {

        }
    }
}