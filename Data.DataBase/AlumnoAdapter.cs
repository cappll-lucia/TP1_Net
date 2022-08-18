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
    public class AlumnoAdapter : Adapter
    {
        public List<Alumno> GetAll()
        {
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                this.OpenConnection();
                string consulta = "select legajo, apellido, nombre, idCarrera, estado from estudiantes";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Alumno alu = new Alumno();
                    alu.Legajo = reader.GetInt32(0);
                    alu.Apellido = (string)reader["apellido"];
                    alu.Nombre = (string)reader["nombre"];
                    alu.IdCarrera = reader.GetInt32(3);
                    alu.Estado = (string)reader["estado"];
                    alumnos.Add(alu);
                }
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                MessageBox.Show("Se produjo un error con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex2);
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;
        }

        public Alumno GetOne(int leg)
        {
            Alumno alu = new Alumno();
            try
            {
                this.OpenConnection();
                string consulta = "select legajo, apellido, nombre, idCarrera, estado from estudiantes where legajo = @leg";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                comando.Parameters.Add("@leg", DbType.Int32).Value = leg; //revisar que DBType sea correcto pq no encuentro SQLiteDbType
                SQLiteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    alu.Legajo = reader.GetInt32(0);
                    alu.Apellido = (string)reader["apellido"];
                    alu.Nombre = (string)reader["nombre"];
                    alu.IdCarrera = reader.GetInt32(3);
                    alu.Estado = (string)reader["estado"];
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
            return alu;
        }

        public void Delete(int leg)
        {
            try
            {
                this.OpenConnection();
                string consulta = "delete estudiantes where legajo=@leg";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                comando.Parameters.Add("@leg", DbType.Int32).Value = leg; //revisar que DBType sea correcto pq no encuentro SQLiteDbType
                comando.ExecuteNonQuery();
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                MessageBox.Show("Se produjo un error con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar alumno", Ex2);
                MessageBox.Show("Error con el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Alumno alu)
        {
            try
            {
                this.OpenConnection();
                
                SQLiteCommand comandoSave = new SQLiteCommand("insert into estudiantes (apellido, nombre, idCarrera, estado)" + "values ( @apell, @nombre, @carrera, @estado)" , sqliteConn);
                comandoSave.Parameters.Add("@apell", DbType.String).Value = alu.Apellido;
                comandoSave.Parameters.Add("@nombre", DbType.String).Value = alu.Nombre;
                comandoSave.Parameters.Add("@carrera", DbType.String).Value = alu.IdCarrera;
                comandoSave.Parameters.Add("@estado", DbType.String).Value = alu.Estado;
                comandoSave.ExecuteNonQuery(); 
                //alu.Legajo = Decimal.ToInt32((decimal)comandoSave.ExecuteScalar()); // tira error

                /*comandoSave.Parameters.Add("@apell", DbType.String).Value = alu.Apellido;
                comandoSave.Parameters.Add("@nombre", DbType.String).Value = alu.Nombre;
                comandoSave.Parameters.Add("@carrera", DbType.String).Value = alu.IdCarrera;
                comandoSave.Parameters.Add("@estado", DbType.String).Value = alu.Estado;*/

            }
            /*catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                MessageBox.Show("Se produjo un error con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar alumno", Ex2);
                MessageBox.Show("Error con el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }*/
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Alumno alu)
        {
            try
            {
                this.OpenConnection();
                string consulta = "update estudiantes set nombre = @nombre, apellido = @apellido, idCarrera=@carrera, estado=@estado" +
                    "where  legajo=@legajo";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                //revisar que DBType sea correcto pq no encuentro SQLiteDbType
                comando.Parameters.Add("@apell", DbType.String).Value = alu.Apellido;
                comando.Parameters.Add("@nombre", DbType.String).Value = alu.Nombre;
                comando.Parameters.Add("@carrera", DbType.String).Value = alu.IdCarrera;
                comando.Parameters.Add("@estado", DbType.String).Value = alu.Estado;
                comando.ExecuteNonQuery();
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos del alumno", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Alumno alu)
        {
            if (alu.State == Business.Entities.Entidades.States.New)
            {
                this.Insert(alu);
            }
            else if (alu.State == Business.Entities.Entidades.States.Deleted)
            {
                this.Delete(alu.Legajo);
            }
            else if (alu.State == Business.Entities.Entidades.States.Modified)
            {
                this.Update(alu);
            }
            alu.State = Business.Entities.Entidades.States.Unmodified;
        }

    }
}
