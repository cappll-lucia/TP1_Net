using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Business.Entities;

namespace Data.DataBase
{
    public class CarreraAdapter: Adapter
    {
        public List<Carrera> GetAll()
        {
            List<Carrera> carreras = new List<Carrera>();
            try
            {
                this.OpenConnection();
                SQLiteCommand comando = new SQLiteCommand("SELECT * FROM carreras", sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
            }
            catch(SQLiteException ex)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return carreras;
        }
    }
}
