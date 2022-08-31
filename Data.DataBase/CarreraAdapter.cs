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
                SQLiteCommand comando = new SQLiteCommand("SELECT * FROM carreras", sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Carrera car = new Carrera();
                    //NO SE PORQUE NO ME LO TOMA
                    car.IdCarrera = reader.GetInt32(0);
                    car.DescCarrera = (string)reader["descCarrera"];
                    car.SiglaCarrera = (string)reader["siglaCarrera"];
                    carreras.Add(car);
                }
            }catch(SQLiteException ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", ex1);
                MessageBox.Show("Error en la base de datos", "Error");
            }
            catch(Exception ex2)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", ex2);
                MessageBox.Show("Error en la base de datos", "Error");
            }
            finally
            {
                this.CloseConnection();
            }
            return carreras;
        }

        public Carrera GetOne(int id)
        {
            Carrera c = new Carrera();
            try
            {
                this.OpenConnection();
                SQLiteCommand comando = new SQLiteCommand("SELECT idCarrera, siglaCarrera, descCarrera FROM carreras where idCarrera = @idCar", sqliteConn);
                comando.Parameters.Add("@idCar", DbType.Int32).Value = id;
                SQLiteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    c.IdCarrera = reader.GetInt32(0);
                    c.SiglaCarrera = (string)reader["siglaCarrera"];
                    c.DescCarrera = (string)reader["descCarrera"];
                }
                reader.Close();
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                MessageBox.Show("Se produjo un error con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar alumno ", Ex2);
                MessageBox.Show("Se produjo un error con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                this.CloseConnection();
            }
            return c;
        }

    }
}
