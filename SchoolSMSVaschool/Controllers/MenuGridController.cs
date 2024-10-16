using SchoolSMSVaschool.Model;
using SchoolSMSVaschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSMSVaschool.Controllers
{
    public class MenuGridController : BaseController
    {
        // GET: MenuGrid
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(DataProvider1.GetMenuStudents().Find(i => i.ID == id));
        }
        public ActionResult MenuViewPartial()
        {
            return PartialView("MenuViewPartial", MenuViewHelper.GetMenuStudents());
        }
        [ValidateAntiForgeryToken]
        public ActionResult MenuViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return MenuViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(MenuStudent menuStudent)
        {
            return UpdateModelWithDataValidation(menuStudent, MenuViewHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(MenuStudent menuStudent)
        {
            return UpdateModelWithDataValidation(menuStudent, MenuViewHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(MenuStudent menuStudent, Action<MenuStudent> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(menuStudent));
            else
                ViewBag.GeneralError = "Please, correct all errors.";
            return MenuViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                MenuViewHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}