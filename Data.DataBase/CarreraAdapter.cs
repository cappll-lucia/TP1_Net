using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Business.Entities;
using System.Windows.Forms;

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
                SQLiteCommand comando = new SQLiteCommand("SELECT IdCarrera, descCarrera, siglaCarrera FROM carreras", sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Carrera car = new Carrera();
                    car.IdCarrera = (int)reader["idCarrera"];
                    car.DescCarrera = (string)reader["descCarrera"];
                    car.SiglaCarrera = (string)reader["siglaCarrera"];
                }
            }catch(SQLiteException ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", ex1);
                //MessageBox.Show("Error en la base de datos", "Error");
            }
            /*catch(Exception ex2)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", ex2);
                MessageBox.Show("Error en la base de datos", "Error");
            }*/
            finally
            {
                this.CloseConnection();
            }
            return carreras;
        }
    }
}
