using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Companies;

namespace GreenOClock.Mvc.Models.Activities
{

    public class GroupActivitiesViewModel
    {
    
        public List<GroupActivityViewModel> GroupActivities { get; set; }

        public GroupActivitiesViewModel()
        {
            GroupActivities = new List<GroupActivityViewModel>();
        }

        public GroupActivitiesViewModel(IEnumerable<GroupActivity> usersGroupActivities)
        {
            GroupActivities = new List<GroupActivityViewModel>();

            foreach (var usersGroupActivity in usersGroupActivities)
            {
                var active = false;
                if (ActiveSessionData.ActiveActivity != null)
                    try
                    {
                        active = usersGroupActivity.Id == ActiveSessionData.ActiveActivity.Id;
                    } catch(NullReferenceException)
                    {
                        active = false;
                    }
                GroupActivities.Add(new GroupActivityViewModel(usersGroupActivity));
            }
        }
    }
}
