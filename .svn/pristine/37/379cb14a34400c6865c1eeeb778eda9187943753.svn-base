using System;
using System.Linq;
using System.Web.Mvc;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Users;
using GreenOClock.Services;

namespace GreenOClock.Mvc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public UserService Users { get; set; }

        public UserController()
        {
            Users = new UserService();
        }

        public ActionResult SearchBar(int companyId)
        {
            return PartialView("UserSearchBar", new UserSearchViewModel(companyId));
        }

        [HttpPost]
        public ActionResult SearchResults(UserSearchViewModel searchModel)
        {
            searchModel.Results = Users.ByName(searchModel.SearchTerms).ToList().ConvertAll(u => new UserViewModel(u));
            return View(searchModel);
        }

        //
        // GET: /User/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(Users.AllActive().ToList().ConvertAll(u => new UserViewModel(u)));
        }

        public ActionResult Details(Guid userId)
        {
            var user = Users.ById(userId);
            return View(new UserViewModel(user));
        }

        public ActionResult Update(Guid userId)
        {
            var user = Users.ById(userId);
            return View(new UserViewModel(user));
        }

        [HttpPost]
        public ActionResult Update(Guid userId, UserViewModel uvm)
        {
            Users.Update(new User
                                   {
                                       FirstName = uvm.FirstName,
                                       LastName = uvm.LastName,
                                       Id = userId
                                   });
            return RedirectToAction("Details", new { userId });
        }

        public ActionResult Delete(Guid userId)
        {
            Users.Remove(Users.ById(userId));
            return RedirectToAction("Index");
        }
    }
}
