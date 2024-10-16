using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSMSVaschool.Models.Connect
{
    public class ConnectServer
    {
        private string serverName = "118.69.69.249,7467";
        public string ServerName { get { return serverName; } set { serverName = value; } }

        private string Database = "student_db_all";
        public string DatabaseName { get { return Database; } set { Database = value; } }

        private string username = "uid-sms";
        public string Username { get { return username; } set { username = value; } }

        private string password = "V@sch00l1qaz";
        public string Password { get { return password; } set { password = value; } }

    }
}