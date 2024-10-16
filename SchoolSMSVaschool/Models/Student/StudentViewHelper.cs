using DevExpress.Web;
using DevExpress.Web.Mvc;
using SchoolSMSVaschool.Code;
using SchoolSMSVaschool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SchoolSMSVaschool.Models
{
    public class StudentViewHelper
    {
        public static List<aci_hocsinh_insert> GetStudents()
        {
            return DataProvider3.GetStudents();
        }

        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(aci_hocsinh_insert StudentDB)
        {
            DataProvider3.AddNewMenuStudent(StudentDB);
        }

        public static void UpdateRecord(aci_hocsinh_insert StudentDB)
        {
            DataProvider3.UpdateMenuStudent(StudentDB);
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<long> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(so => long.Parse(so));
            DataProvider3.DeleteMenuStudents(selectedIds);
        }
    }
}
