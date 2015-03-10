using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenOClock.Data;

namespace GreenOClock.Mvc.Models.Activities
{
    public class ActivitiesViewModel
    {
        public GroupActivitiesViewModel GroupActivities { get; set; }
        public PersonalActivitiesViewModel PersonalActivities { get; set; }

        public ActivitiesViewModel(IEnumerable<PersonalActivity> activities) : this(new List<GroupActivity>(), activities)
        {
        }

        public ActivitiesViewModel() : this(new List<GroupActivity>(), new List<PersonalActivity>())
        {
        }

        public ActivitiesViewModel(IEnumerable<GroupActivity> usersGroupActivities, IEnumerable<PersonalActivity> usersPersonalActivities)
        {
            GroupActivities = new GroupActivitiesViewModel(usersGroupActivities);
            PersonalActivities = new PersonalActivitiesViewModel(usersPersonalActivities);
        }
    }
}