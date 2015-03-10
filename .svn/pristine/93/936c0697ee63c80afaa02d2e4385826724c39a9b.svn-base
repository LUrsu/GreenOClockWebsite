using System;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Progresses;

namespace GreenOClock.Mvc.Models.Activities
{
    public class PersonalActivityViewModel : ActivityViewModel
    {
        public Guid UserId { get; set; }

        public PersonalActivityViewModel()
        {
            Progresses = new ProgressesViewModel();
        }

        public PersonalActivityViewModel(PersonalActivity activity) : base(activity)
        {
            UserId = activity.UserId;
            Progresses = new ProgressesViewModel(activity.PersonalProgresses);
        }
    }
}