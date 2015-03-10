using System;
using System.Web.Mvc;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Activities;
using GreenOClock.Mvc.Models.Progresses;
using GreenOClock.Services;

namespace GreenOClock.Mvc.Controllers
{
    [Authorize]
    public class ProgressController : Controller
    {
        public ProgressService Progresses { get; set; }
        public ActivityService Activities { get; set; }

        public ProgressController()
        {
            Progresses = new ProgressService();
            Activities = new ActivityService();
        }

        public ActionResult Start(int activityId)
        {
            try
            {
                if (ActiveSessionData.ActiveActivity != null && ActiveSessionData.ActiveActivity.Id != activityId)
                    AutoStop("Started a new activity without stopping the active one");

				var activity = Activities.ById(activityId);

                Progress progress;
                if (activity.GetType().BaseType == typeof(GroupActivity))
                    progress = new GroupProgress { GroupActivityId = activityId, User_Id = ActiveSessionData.ActiveUser.Id };
                else
                    progress = new PersonalProgress { PersonalActivity_Id = activityId, User_Id = ActiveSessionData.ActiveUser.Id };

                progress.UserId = ActiveSessionData.ActiveUser.Id;
                progress.ActivityId = activityId;
                progress.StartTime = DateTime.Now;
                progress.IsActive = true;

				ActiveSessionData.ActiveActivity = activity;
                ActiveSessionData.ActiveActivityProgress = Progresses.AddProgress(progress);
            } catch
            {
                TempData["Message"] = "Error setting active activity.";
            }

            return RedirectToAction("Status");
        }

        public ActionResult Status()
        {
            if (ActiveSessionData.ActiveActivityProgress == null)
                return View();
            return StatusById(ActiveSessionData.ActiveActivityProgress.Id);
        }

        public ActionResult StatusById(int id)
        {
            var vm = new ProgressViewModel(Progresses.ById(id));
            return View("Status", vm);
        }

        public ActionResult Stop()
        {
            return View(new ProgressViewModel(ActiveSessionData.ActiveActivityProgress));
        }

        [HttpPost]
        public void AutoStop(string description)
        {
            Stop("INFO: " + description);
        }

        [HttpPost]
        public ActionResult Stop(string description)
        {
            if (ActiveSessionData.ActiveActivity == null)
            {
                TempData["Message"] = "There is no activity to stop.";
                ActiveSessionData.ActiveActivityProgress = null;

                return RedirectToAction("Index", "Activity");
            }
                
            var progress = ActiveSessionData.ActiveActivityProgress;
            var activityId = ActiveSessionData.ActiveActivity.Id;

            ActiveSessionData.ActiveActivityProgress = null;
            ActiveSessionData.ActiveActivity = null;
            
            if (progress != null)
            {
                progress.Description = description ?? "";
                Progresses.Finish(progress);

                if (string.IsNullOrEmpty(description))
                    return RedirectToAction("UpdateDescription", new { progress.Id });
            }

            return RedirectToAction("ViewProgresses", new { activityId });
        }

        public ActionResult UpdateDescription(int progressId)
        {
            return View(new ProgressViewModel(Progresses.ById(progressId)));
        }

        [HttpPost]
        public ActionResult UpdateDescription(ProgressViewModel progress)
        {
            if (string.IsNullOrEmpty(progress.Description))
                return View(progress);

            Progresses.UpdateDescription(new PersonalProgress
                                  {
                                      Id = progress.Id,
                                      Description = progress.Description
                                  });
            TempData["Message"] = "Progress description updated.";
            return RedirectToAction("Index", "Activity");
        }

        public ActionResult ViewProgresses(int activityId)
        {
            ActivityViewModel vm;
            var activity = Activities.ById(activityId);

            if (activity.GetType().BaseType == typeof(GroupActivity))
                vm = new GroupActivityViewModel((GroupActivity)activity);
            else
                vm = new PersonalActivityViewModel((PersonalActivity)activity);

            return View(vm);
        }

        public PartialViewResult ActiveActivity()
        {
            ProgressViewModel vm = null;
            if (ActiveSessionData.ActiveActivityProgress != null)
                vm = new ProgressViewModel(ActiveSessionData.ActiveActivityProgress);

            return PartialView(vm);
        }

        public JsonResult ActiveActivityTime()
        {
            var seconds = 0;
            if (ActiveSessionData.ActiveActivityProgress != null)
            {
                ActiveSessionData.ActiveActivityProgress.EndTime = DateTime.Now;
                Progresses.UpdateEndTime(ActiveSessionData.ActiveActivityProgress);

                seconds = (Int32)(DateTime.Now - ActiveSessionData.ActiveActivityProgress.StartTime).TotalSeconds;
            }

            return Json(new { seconds }, JsonRequestBehavior.AllowGet);
        }
    }
}
