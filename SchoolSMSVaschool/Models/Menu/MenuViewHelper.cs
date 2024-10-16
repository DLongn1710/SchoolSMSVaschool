using DevExpress.Web;
using DevExpress.Web.Mvc;
using SchoolSMSVaschool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SchoolSMSVaschool.Models
{
    public class MenuViewHelper
    {
        public static List<MenuStudent> GetMenuStudents()
        {
            return DataProvider1.GetMenuStudents();
        }
       
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(MenuStudent menuStudent)
        {
            DataProvider1.AddNewMenuStudent(menuStudent);
        }

        public static void UpdateRecord(MenuStudent menuStudent)
        {
            DataProvider1.UpdateMenuStudent(menuStudent);
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<long> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(ID => long.Parse(ID));
            DataProvider1.DeleteMenuStudents(selectedIds);
        }
    }
}
