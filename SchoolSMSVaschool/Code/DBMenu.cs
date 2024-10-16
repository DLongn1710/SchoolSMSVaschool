using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraScheduler;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using SchoolSMSVaschool.Model;
using DevExpress.XtraPrinting.Native;
using static System.Data.Entity.Infrastructure.Design.Executor;
using DevExpress.XtraEditors.Controls;


namespace SchoolSMSVaschool.Model
{
    public class MenuStudent 
    {
        public long ID { get; set; }
        public int Ma { get; set; }
        public int Ma2 { get; set; }
        public string FullName { get; set; }

        public DateTime NgaySinh { get; set; } 
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public string DanToc { get; set; }
        public string QuocTich { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TenCha { get; set; }
        public string DTCha { get; set; }
        public string TenMe { get; set; }
        public string DTMe { get; set; }
        public string TrangThai { get; set; }
        public string TinhTrang { get; set; }
        public string Khoi { get; set; }
        public string CoSo { get; set; }
        public string ChinhSach { get; set; }
        public string TenNguoiQuanHe { get; set; }
        public string QuanHe { get; set; }
        public string Note { get; set; }

        public void Assign(MenuStudent src)
        {
            ID = src.ID;
            Ma = src.Ma;
            Ma2 = src.Ma2;
            FullName = src.FullName;
            NgaySinh = src.NgaySinh;
            GioiTinh = src.GioiTinh;
            TrangThai = src.TrangThai;
        }
    }
    #region DataProvider
    public static class DataProvider1 {
        public static List<MenuStudent> GetMenuStudents() {
            if (HttpContext.Current.Session["Student"] == null)
                HttpContext.Current.Session["Student"] = GenerateMenuStudent();
            return HttpContext.Current.Session["Student"] as List<MenuStudent>;
        }
        static void UpdateMenuStudents(List<MenuStudent> list)
        {
            HttpContext.Current.Session["MenuStudents"] = list;
        }

        private static readonly object lockObject = new object();
        public static void AddNewMenuStudent(MenuStudent MenuStudent)
        {
            lock (lockObject)
            {
                List<MenuStudent> MenuStudents = GetMenuStudents();
                MenuStudent.NgaySinh = DateTime.Now;
                MenuStudent.ID = GetNextMenuStudentId();
                

                MenuStudents.Add(MenuStudent);

                UpdateMenuStudents(MenuStudents);
            }
        }
        public static void UpdateMenuStudent(MenuStudent MenuStudent)
        {
            List<MenuStudent> MenuStudents = GetMenuStudents();

            MenuStudent existingMenuStudent = MenuStudents.Find(i => i.ID == MenuStudent.ID);
            if (existingMenuStudent != null)
                existingMenuStudent.Assign(MenuStudent);

            UpdateMenuStudents(MenuStudents);
        }
        public static void DeleteMenuStudents(List<long> ids)
        {
            List<MenuStudent> MenuStudents = GetMenuStudents();
            MenuStudents.RemoveAll(i => ids.Contains(i.ID));
            UpdateMenuStudents(MenuStudents);
        }

        static List<MenuStudent> GenerateMenuStudent()
        {
            List<MenuStudent> MenuStudents = new List<MenuStudent> {
             new MenuStudent {
               ID = 1, Ma = 1,Ma2 = 1,FullName="Vu Duc Long" , GioiTinh ="Nam", NgaySinh = new DateTime(2000, 10, 17) , TrangThai="dang hoc"
             },
                new MenuStudent {
               ID = 2, Ma = 2,Ma2 =2,FullName="Truc", GioiTinh ="Nu", NgaySinh = new DateTime(2000, 10, 17), TrangThai="dang hoc"
             },
             
            };

            

            return MenuStudents;
        }
        internal static long GetNextMenuStudentId()
        {
            IEnumerable<long> MenuStudentsIds = GetMenuStudents().Select(i => i.ID);
            if (MenuStudentsIds.Count() > 0)
                return MenuStudentsIds.Max() + 1;
            else
                return 1;
        }
    }
    #endregion
}