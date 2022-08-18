using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Data.DataBase
{
    public class Adapter
    {
        public SQLiteConnection sqliteConn;
        public SQLiteConnection sqliteCon { get => sqliteConn; set => sqliteConn = value; }


        public void OpenConnection()
        {
           // string connectionString = "Data Source = C:/SQLiteStudio/TP1-Net";
            string connectionString = "Data Source = C:\\sqlite\\SQLiteStudio\\TP1-Net-T05.db";
            sqliteConn = new SQLiteConnection(connectionString);
            sqliteConn.Open();
        }

        public void CloseConnection()
        {
            sqliteConn.Close();
            sqliteConn = null;
        }
    }
}
