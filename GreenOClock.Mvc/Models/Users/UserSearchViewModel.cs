using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenOClock.Mvc.Models.Users
{
    public class UserSearchViewModel
    {
        [Required]
        [DisplayName("Search Terms ")]
        public string SearchTerms { get; set; }

        [ScaffoldColumn(false)]
        public int CompanyId { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<UserViewModel> Results { get; set; }

        public UserSearchViewModel()
        {
            
        }

        public UserSearchViewModel(int companyId)
        {
            CompanyId = companyId;
        }
    }
}