using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GreenOClock.Data;
using GreenOClock.Mvc.Models.Companies;
using GreenOClock.Services;

namespace GreenOClock.Mvc.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        public CompanyService Companies { get; set; }
        public UserService Users { get; set; }
        public CompanyEmployeeService CompanyEmployees { get; set; }

        public CompanyController()
        {
            Companies = new CompanyService();
            Users = new UserService();
            CompanyEmployees = new CompanyEmployeeService();
        }

        public ActionResult Index()
        {
            var companies = Companies.ByEmployeeId(ActiveSessionData.ActiveUser.Id);
            return View(companies.ToList().ConvertAll(c => new CompanyViewModel(c)));
        }

        //
        // GET: /Company/Details/5
        public ActionResult Details(int id)
        {
            TempData["UserId"] = ActiveSessionData.ActiveUser.Id;
            var company = Companies.ById(id);
            return View(new CompanyViewModel(company));
        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            return View(new CompanyViewModel());
        } 

        //
        // POST: /Company/Create
        [HttpPost]
        public ActionResult Create(CompanyViewModel companyVm)
        {
            try
            {
                var company = new Company
                    {
                        City = companyVm.City,
                        State = companyVm.State,
                        Country = companyVm.Country,
                        Name = companyVm.Name
                    };
                Companies.Add(company, ActiveSessionData.ActiveUser.Id);

                return RedirectToAction("Details", new{ id = company.Id });
            } catch
            {
                return View(companyVm);
            }
        }

        public ActionResult Update(int id)
        {
            var company = Companies.ById(id);
            return View(new CompanyViewModel(company));
        }

        [HttpPost]
        public ActionResult Update(CompanyViewModel company)
        {
            try
            {
                Companies.Update(
                    new Company{
                            Id = company.Id,
                            City = company.City,
                            State = company.State,
                            Country = company.Country,
                            Name = company.Name
                        }, ActiveSessionData.ActiveUser.Id);
                
                TempData["Message"] = "Company information updated.";
                return RedirectToAction("Details", new{id=company.Id});
            } catch
            {
                TempData["Message"] = "Error updating company information.";
                return View();
            }
        }

        public PartialViewResult CompanyControls(CompanyViewModel company)
        {
            TempData["UserId"] = ActiveSessionData.ActiveUser.Id;
            var isEmployee = CompanyEmployees.UserHasEmployeePriveleges((Guid)TempData["UserId"], company.Id);
            
            return isEmployee ? PartialView(company) : null;
        }

        public PartialViewResult CompanyEmployeeControls(CompanyViewModel company)
        {
            var isEmployee = CompanyEmployees.UserHasEmployeePriveleges((Guid)TempData["UserId"], company.Id);

            return isEmployee ? PartialView(company) : null;
        }

        public PartialViewResult CompanyManagerControls(int companyId)
        {
            var isManager = CompanyEmployees.UserHasManagerPriveleges((Guid)TempData["UserId"], companyId);

            return isManager ? PartialView(companyId) : null;
        }

        public PartialViewResult CompanyOwnerControls(CompanyViewModel company)
        {
            var isOwner = CompanyEmployees.UserHasOwnerPriveleges((Guid)TempData["UserId"], company.Id);

            return isOwner ? PartialView(company) : null;
        }

        public PartialViewResult SearchBar()
        {
            return PartialView("CompanySearchBar");
        }

        [HttpPost]
        public ActionResult Search(string searchTerms)
        {
            return View(Companies.ByName(searchTerms).ToList().ConvertAll(c => new CompanyViewModel(c)));
        }

        public ActionResult Join(Guid userId, int companyId)
        {
            var employeeType = new EmployeeTypeService().EmployeeType();
            try
            {
                CompanyEmployees.Add(companyId, userId, employeeType);
                TempData["Message"] = "You added a new user to the company.";
            }
            catch
            {
                TempData["Message"] = "Error adding a new user to the company.";
            }

            return RedirectToAction("Details", new { id = companyId });
        }

        public ActionResult Leave(Guid userId, int companyId)
        {
            try
            {
                CompanyEmployees.Leave(userId, companyId);
                TempData["Message"] = "You left the company.";
            }
            catch
            {
                TempData["Message"] = "Error leaving company.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateEmployeeTypes(int companyId)
        {
            var companyEmployees = CompanyEmployees.ByCompanyId(companyId).ToList();
            return View(new CompanyEmployeesViewModel(companyEmployees.Select(ce => new CompanyEmployeeViewModel(ce)).AsQueryable(), companyId));
        }

        [HttpPost]
        public ActionResult UpdateEmployeeTypes(IEnumerable<CompanyEmployeeViewModel> companyEmployees, int companyId)
        {
            try
            {
                //If there is no user left who has EmployeeType "Owner", STOP
                if(companyEmployees.FirstOrDefault(ce => ce.CompanyEmployeeType.Id == CompanyEmployees.OwnerType.Id) == null)
                {
                    TempData["Message"] = "You must have at least one person of type \"Owner\" in your company.";
                    return RedirectToAction("UpdateEmployeeTypes", new{ companyId });
                }
                
                CompanyEmployees.UpdateEmployeeTypes(
                    companyEmployees.Select(e => e.UserId).ToArray(),
                    companyEmployees.Select(et => et.CompanyEmployeeType.Id).ToArray(),
                    companyId);
                    
                TempData["Message"] = "Employee types updated.";
            }
            catch
            {
                TempData["Message"] = "Error updating employee types.";
            }
            
            return RedirectToAction("Details", new { id = companyId });
        }

        //
        // GET: /Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Company/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
