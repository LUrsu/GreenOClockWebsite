using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenOClock.Mvc.Models.Users;

namespace GreenOClock.Mvc.Models.Activities
{
    public class GroupMembersViewModel
    {
        public IEnumerable<GroupMemberViewModel> GroupMembers { get; set; }
        public int ActivityId { get; set; }

        public GroupMembersViewModel()
        {
            
        }

        public GroupMembersViewModel(GroupActivityViewModel activity)
        {
            GroupMembers = activity.Company.CompanyEmployees.Select(u => new GroupMemberViewModel(u.User, activity.GroupMembers.FirstOrDefault(gm => gm.User.Id == u.User.Id) != null));
            ActivityId = activity.Id;
        }
    }
}