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
    public class AlumnoAdapter : Adapter
    {
        public List<Alumno> GetAll()
        {
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                this.OpenConnection();
                string consulta = "select * from alumnos";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Alumno alu = new Alumno();
                    alu.Legajo = (int)reader["legajo"];
                    alu.Apellido = (string)reader["apellido"];
                    alu.Nombre = (string)reader["nombre"];
                    alu.IdCarrera = (string)reader["idCarrera"];
                    alu.Estado = (string)reader["estado"];
                    alumnos.Add(alu);
                }
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex2);
                throw ExcepcionManejada;
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
                string consulta = "select * from alumnos where legajo=@leg";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                comando.Parameters.Add("@leg", DbType.Int32).Value = leg; //revisar que DBType sea correcto pq no encuentro SQLiteDbType
                while (reader.Read())
                {
                    alu.Legajo = (int)reader["legajo"];
                    alu.Apellido = (string)reader["apellido"];
                    alu.Nombre = (string)reader["nombre"];
                    alu.IdCarrera = (string)reader["idCarrera"];
                    alu.Estado = (string)reader["estado"];
                }
                reader.Close();
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar alumno ", Ex2);
                throw ExcepcionManejada;
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
                string consulta = "delete alumnos where legajo=@leg";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                comando.Parameters.Add("@leg", DbType.Int32).Value = leg; //revisar que DBType sea correcto pq no encuentro SQLiteDbType
                comando.ExecuteNonQuery();
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar alumno", Ex2);
                throw ExcepcionManejada;
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
                string consulta = "insert into alumnos (legajo, apellido, nombre, idCarrera, estado)" +
                    "values (@leg, @apell, @nombre, @carrera, @estado)"
                    /*+ "select @@identity"*/;      //agregar cuando el legajo sea generated value
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                comando.Parameters.Add("@leg", DbType.Int32).Value = alu.Legajo; //revisar que DBType sea correcto pq no encuentro SQLiteDbType
                comando.Parameters.Add("@apell", DbType.String).Value = alu.Apellido;
                comando.Parameters.Add("@nombre", DbType.String).Value = alu.Nombre;
                comando.Parameters.Add("@carrera", DbType.String).Value = alu.IdCarrera;
                comando.Parameters.Add("@estado", DbType.String).Value = alu.Estado;
            }
            catch (SQLiteException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar alumno", Ex2);
                throw ExcepcionManejada;
            }
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
                string consulta = "update alumnos set nombre = @nombre, apellido = @apellido, idCarrera=@carrera, estado=@estado" +
                    "where  legajo=@legajo";
                SQLiteCommand comando = new SQLiteCommand(consulta, sqliteConn);
                SQLiteDataReader reader = comando.ExecuteReader();
                comando.Parameters.Add("@leg", DbType.Int32).Value = alu.Legajo; //revisar que DBType sea correcto pq no encuentro SQLiteDbType
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
