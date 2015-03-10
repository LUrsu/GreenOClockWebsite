using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Companies;

namespace GreenOClock.Mvc.Helpers
{
    public static class EmployeeTypeHelper
    {
        static readonly List<EmployeeTypeViewModel> types = new List<EmployeeTypeViewModel>();

        static EmployeeTypeHelper()
        {
            types.Add(new EmployeeTypeViewModel() {Id = 1, Name = "Employee"});
            types.Add(new EmployeeTypeViewModel() {Id = 2, Name = "Manager"});
            types.Add(new EmployeeTypeViewModel() {Id = 3, Name = "Owner"});
        }

        public static List<EmployeeTypeViewModel> Types
        {
            get
            {
                return types;
            }
        }
    }
}