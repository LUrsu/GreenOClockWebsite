using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenOClock.Data;

namespace GreenOClock.Mvc.Models.Activities
{

    public class PersonalActivitiesViewModel
    {
        public List<PersonalActivityViewModel> PersonalActivities { get; set; }

        public PersonalActivitiesViewModel()
        {
            PersonalActivities = new List<PersonalActivityViewModel>();
        }

        public PersonalActivitiesViewModel(IEnumerable<PersonalActivity> usersPersonalActivities)
        {
            PersonalActivities = new List<PersonalActivityViewModel>();
            foreach (var usersPersonalActivity in usersPersonalActivities)
            {
                var active = false;
                if (ActiveSessionData.ActiveActivity != null)
                    try
                    {
                        active = usersPersonalActivity.Id == ActiveSessionData.ActiveActivity.Id;
                    } catch(Exception) {}
                PersonalActivities.Add(new PersonalActivityViewModel(usersPersonalActivity));
            }
        }
    }
}