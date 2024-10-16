using SchoolSMSVaschool.Code;
using SchoolSMSVaschool.ConnectDB;
using SchoolSMSVaschool.Model;
using SchoolSMSVaschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSMSVaschool.Controllers
{
    public class StudentController : BaseController
    {
        //okay cấu trúc cơ bản là như này
        //ConnectDatabase connect = new ConnectDatabase();
        //List<aci_hocsinh_insert> listStudent = new List<aci_hocsinh_insert>();
        // GET: Student
        public ActionResult Index()
        {
            ///này là gọi dữ liệu từ sqldb như này 
            ///GetDataReader<T> này lấy dữ liệu cần có model tưng ứng
            /// listStudet add vào grid của web
            //listStudent = connect.GetDataReader<aci_hocsinh_insert>("select * from Students");
            return View();
        }
        public ActionResult MenuViewDetailsPage(int id)
        {
            ViewBag.ShowBackButton = true;
            return View(DataProvider3.GetStudents().Find(i => i.so == id));
        }
        public ActionResult StudentViewPartial()
        {
            return PartialView("StudentViewPartial", StudentViewHelper.GetStudents());
        }
        [ValidateAntiForgeryToken]
        public ActionResult StudentViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return StudentViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult MenuViewAddNewPartial(aci_hocsinh_insert StudentVas)
        {
            return UpdateStudent(StudentVas, StudentViewHelper.AddNewRecord);
        }

        private ActionResult UpdateModelWithDataValidation(aci_hocsinh_insert StudentVas, Action<aci_hocsinh_insert> addNewRecord)
        {
            throw new NotImplementedException();
        }

        [ValidateAntiForgeryToken]
        public ActionResult MenuViewUpdatePartial(aci_hocsinh_insert StudentVas)
        {
            return UpdateStudent(StudentVas, StudentViewHelper.UpdateRecord);
        }

        private ActionResult UpdateStudent(aci_hocsinh_insert StudentVas, Action<aci_hocsinh_insert> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(StudentVas));
            else
                ViewBag.GeneralError = "Please, correct all errors.";
            return StudentViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                GridViewHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}