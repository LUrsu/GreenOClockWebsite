using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GreenOClock.Mvc.Models.Companies;
using GreenOClock.Mvc.Models.Users;

namespace GreenOClock.Mvc.Models.Activities
{
    public class EmployeeDateTimeSearchModel
    {
        public DateTime LowerBound { get; set; }
        public DateTime UpperBound { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public CompanyViewModel Company { get; set; }

        public EmployeeDateTimeSearchModel()
        {
        }

        public EmployeeDateTimeSearchModel(CompanyViewModel company)
        {
            Company = company;
        }
    }
}