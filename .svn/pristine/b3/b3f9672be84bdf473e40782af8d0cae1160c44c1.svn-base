using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Activities;
using GreenOClock.Mvc.Models.Users;

namespace GreenOClock.Mvc.Models.Progresses
{
    public class ProgressViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public int ActivityId { get; set; }
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }

        public UserViewModel User { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan TimeActive
        {
            get
            {
                var end = EndTime.HasValue ? EndTime.Value : DateTime.Now;
                return end - StartTime;
            }
        }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }

        public ProgressViewModel()
        {
        }

        public ProgressViewModel(Progress progress)
        {
            ActivityId = progress.ActivityId;
            UserId = progress.UserId;
            StartTime = progress.StartTime;
            EndTime = progress.EndTime;
            Description = progress.Description;
            Id = progress.Id;
            IsActive = progress.IsActive;
        }

        public static implicit operator TimeSpan(ProgressViewModel vm)
        {
            var end = vm.EndTime.HasValue ? vm.EndTime.Value : DateTime.Now;
            return end - vm.StartTime;
        }

        public static implicit operator PersonalProgress(ProgressViewModel vm)
        {
            return new PersonalProgress
            {
                ActivityId = vm.ActivityId,
                Description = vm.Description,
                StartTime = vm.StartTime,
                EndTime = vm.EndTime,
                Id = vm.Id,
                UserId = vm.UserId,
                User_Id = vm.UserId,
                PersonalActivity_Id = vm.ActivityId
            };
        }

        public static implicit operator GroupProgress(ProgressViewModel vm)
        {
            return new GroupProgress
            {
                ActivityId = vm.ActivityId,
                Description = vm.Description,
                StartTime = vm.StartTime,
                EndTime = vm.EndTime,
                Id = vm.Id,
                UserId = vm.UserId,
                User_Id = vm.UserId,
                GroupActivityId = vm.ActivityId
            };
        }
    }
}