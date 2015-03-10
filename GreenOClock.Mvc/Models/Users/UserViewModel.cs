using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GreenOClock.Data;

namespace GreenOClock.Mvc.Models.Users
{
    public class UserViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        [ScaffoldColumn(false)]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        [DisplayName("Date Created")]
        [ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }

        public UserViewModel()
        {
            IsActive = true;
        }

        public UserViewModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            CreatedOn = user.CreatedOn;
            Id = user.Id;
            user.
            IsActive = true;
        }
    }
}