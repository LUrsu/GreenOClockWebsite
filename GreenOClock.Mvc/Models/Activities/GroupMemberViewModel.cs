using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Users;

namespace GreenOClock.Mvc.Models.Activities
{
    public class GroupMemberViewModel
    {
        public UserViewModel User { get; set; }
        public bool IsGroupMember { get; set; }

        public GroupMemberViewModel()
        {
            
        }

        public GroupMemberViewModel(UserViewModel user)
        {
            User = user;
            IsGroupMember = false;
        }

        public GroupMemberViewModel(UserViewModel user, bool isGroupMember)
        {
            User = user;
            IsGroupMember = isGroupMember;
        }
    }
}