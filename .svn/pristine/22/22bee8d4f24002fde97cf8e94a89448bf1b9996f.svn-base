using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Companies;
using GreenOClock.Mvc.Models.Progresses;
using GreenOClock.Mvc.Models.Users;

namespace GreenOClock.Mvc.Models.Activities
{
    public class GroupActivityViewModel : ActivityViewModel
    {
        public CompanyViewModel Company { get; set; }
        public int CompanyId { get; set; }
        public List<GroupMemberViewModel> GroupMembers { get; set; }

        public GroupActivityViewModel()
        {
        }

        public GroupActivityViewModel(GroupActivity activity) : base(activity)
        {
            Company = new CompanyViewModel(activity.Company);
            Progresses = new ProgressesViewModel(activity.GroupProgresses);
            GroupMembers = activity.GroupMembers.ToList().ConvertAll(gm => new GroupMemberViewModel(new UserViewModel(gm.User), true));
        }
    }
}