using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenOClock.Data;

namespace GreenOClock.Mvc.Models.Companies
{
    public class EmployeeTypeViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public EmployeeTypeViewModel()
        {
            
        }

        public EmployeeTypeViewModel(EmployeeType type)
        {
            Name = type.Name;
            Id = type.Id;
        }

        public new string ToString()
        {
            return Name;
        }
    }
}