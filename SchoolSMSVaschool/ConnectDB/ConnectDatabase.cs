using SchoolSMSVaschool.Models.Connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SchoolSMSVaschool.ConnectDB
{
    public class ConnectDatabase
    {
        SqlDataAdapter da;
        DataTable dt;
        public ConnectServer Server { get; set; } = new ConnectServer();
        public string StringConnectServer()
        {
            string StringConnectServer =
                $"Server={Server.ServerName}; " +
                $"Database={Server.DatabaseName}; " +
                $"User Id={Server.Username}; " +
                $"Password={Server.Password};";
            return StringConnectServer;
        }

        public T GetTable<T>(string sql)
        {
            SqlConnection cnn = new SqlConnection(StringConnectServer());
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            var rows = (T)cmd.ExecuteScalar();
            cnn.Close();
            return rows;
        }

        public DataTable GetDataTable(string sql)
        {
            da = new SqlDataAdapter(sql, StringConnectServer());
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Này đọc sql xịn nhất vì dùng SqlDataReader đọc nhanh 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetDataReader<T>(string sql)
        {
            List<T> data = new List<T>();
            T obj = default;
            using (SqlConnection con = new SqlConnection(StringConnectServer()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            obj = Activator.CreateInstance<T>();
                            foreach (PropertyInfo prop in obj.GetType().GetProperties())
                            {
                                if (!Equals(reader[prop.Name], DBNull.Value))
                                {
                                    prop.SetValue(obj, reader[prop.Name], null);
                                }
                            }
                            data.Add(obj);
                        }
                    }
                }
            
            
            }
            return data;
        }

        /// <summary>Model tương ứng
        /// này lấy bình thường
        /// </summary>
        /// <typeparam name="T">Model tương ứng</typeparam>
        /// <param name="sql">lệnh query </param>
        /// <returns></returns>
        public List<T> GetDataTable<T>(string sql)
        {
            List<T> data = new List<T>();
            GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        /// <summary>
        /// dùng cho POST PUT DELETE
        /// </summary>
        /// <param name="sql"></param>
        public void ExecuteData(string sql)
        {
            SqlConnection cnn = new SqlConnection(StringConnectServer());
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public string Field(string sql)
        {
            SqlConnection cnn = new SqlConnection(StringConnectServer());
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);

            return cmd.ExecuteScalar().ToString();
        }
    }
}