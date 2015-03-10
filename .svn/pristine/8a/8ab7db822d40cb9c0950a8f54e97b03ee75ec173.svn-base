using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Users;

namespace GreenOClock.Mvc.Models.Companies
{
    public class CompanyEmployeeViewModel
    {
        public UserViewModel User { get; set; }
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }

        [ScaffoldColumn(false)]
        public int CompanyId { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }

        [DisplayName("Employee Type")]
        public EmployeeTypeViewModel CompanyEmployeeType { get; set; }
        [ScaffoldColumn(false)]
        public int EmployeeTypeId { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public CompanyEmployeeViewModel()
        {
        }

        public CompanyEmployeeViewModel(CompanyEmployee companyEmployee)
        {
            CompanyId = companyEmployee.CompanyId;
            UserId = companyEmployee.UserId;
            EmployeeTypeId = companyEmployee.EmployeeTypeId;

            User = new UserViewModel(companyEmployee.User);
            CompanyEmployeeType = new EmployeeTypeViewModel(companyEmployee.EmployeeType);

            Id = companyEmployee.Id;
            IsActive = companyEmployee.IsActive;
        }

        public string FullName()
        {
            return User.FirstName + " " + User.LastName;
        }
    }
}