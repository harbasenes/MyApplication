using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Podaci
{
    public class KnjigovodstvoDB
    {
        public static OleDbConnection GetConnection(string folderName)
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=dBase III;Data Source=" + folderName;
//            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=e:\\proba\\;Extended Properties=dBase III";
            OleDbConnection conn = new OleDbConnection(connString);
            return conn;

        }
    }
}
