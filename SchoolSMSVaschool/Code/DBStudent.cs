using DevExpress.Xpo;
using SchoolSMSVaschool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSMSVaschool.Code
{
    public class StudentDB 
    {
        //public long ID { get; set; }
        //public int Ma { get; set; }
        //public int Ma2 { get; set; }
        //public string FullName { get; set; }

        //public DateTime NgaySinh { get; set; }
        //public string GioiTinh { get; set; }
        //public string NoiSinh { get; set; }
        //public string DanToc { get; set; }
        //public string QuocTich { get; set; }
        //public string DiaChi { get; set; }
        //public string DienThoai { get; set; }
        //public string TenCha { get; set; }
        //public string DTCha { get; set; }
        //public string TenMe { get; set; }
        //public string DTMe { get; set; }
        //public string TrangThai { get; set; }
        //public string TinhTrang { get; set; }
        //public string Khoi { get; set; }
        //public string CoSo { get; set; }
        //public string ChinhSach { get; set; }
        //public string TenNguoiQuanHe { get; set; }
        //public string QuanHe { get; set; }
        //public string Note { get; set; }
        public int so { get; set; }
        public string ma { get; set; }
        public string hodem { get; set; }
        public string ten { get; set; }
        public string quoctich { get; set; }
        public Nullable<System.DateTime> sinhnhat { get; set; }
        public string noisinh { get; set; }
        public Nullable<System.DateTime> ngaynhaphoc { get; set; }
        public string phai { get; set; }
        public string dantoc { get; set; }
        public string tongiao { get; set; }
        public string email { get; set; }
        public string cccd { get; set; }
        public string dienthoai { get; set; }
        public Nullable<int> so_donvi { get; set; }
        public Nullable<int> so_namhoc { get; set; }
        public string khoi { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string userid { get; set; }

        public void Assign(StudentDB src)
        {
            so = src.so;
            ma = src.ma;
            hodem = src.hodem;
            ten = src.ten;
            sinhnhat = src.sinhnhat;
            phai = src.phai;

        }
    }
    public static class DataProvider2
    {
        public static List<StudentDB> GetMenuStudents()
        {
            if (HttpContext.Current.Session["Student"] == null)
                HttpContext.Current.Session["Student"] = GenerateMenuStudent();
            return HttpContext.Current.Session["Student"] as List<StudentDB>;
        }
        static void UpdateMenuStudent(List<StudentDB> list)
        {
            HttpContext.Current.Session["StudentDB"] = list;
        }

        private static readonly object lockObject = new object();
        public static void AddNewMenuStudent(StudentDB StudentDBs)
        {
            lock (lockObject)
            {
                List<StudentDB> StudentDB = GetMenuStudents();
                StudentDBs.sinhnhat = DateTime.Now;
                StudentDBs.so = GetNextMenuStudentId();


                StudentDB.Add(StudentDBs);

                UpdateMenuStudent(StudentDB);
            }
        }
        public static void UpdateMenuStudent(StudentDB StudentDB)
        {
            List<StudentDB> StudentDBs = GetMenuStudents();

            StudentDB existingMenuStudent = StudentDBs.Find(i => i.so == StudentDB.so);
            if (existingMenuStudent != null)
                existingMenuStudent.Assign(StudentDB);

            UpdateMenuStudent(StudentDBs);
        }
        public static void DeleteMenuStudents(List<long> ids)
        {
            List<StudentDB> StudentDBs = GetMenuStudents();
            StudentDBs.RemoveAll(i => ids.Contains(i.so));
            UpdateMenuStudent(StudentDBs);
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
        internal static int GetNextMenuStudentId()
        {
            IEnumerable<int> MenuStudentsIds = GetMenuStudents().Select(i => i.so);
            if (MenuStudentsIds.Count() > 0)
                return MenuStudentsIds.Max() + 1;
            else
                return 1;
        }
    }

}