using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataBase;
using Business.Entities;

namespace Business.Logic
{
    public class AlumnoLogic
    {

        public AlumnoAdapter _AlumnoData;

        public AlumnoAdapter AlumnoData
        {
            get { return _AlumnoData; }
            set { _AlumnoData = value; }
        }

        public AlumnoLogic()
        {
            AlumnoData = new AlumnoAdapter();
        }

        public List<Alumno> GetAll()
        {
            return AlumnoData.GetAll();
        }

        public Alumno GetOne(int legajo)
        {
            return AlumnoData.GetOne(legajo);
        }

        public void Delete(int legajo)
        {
            AlumnoData.Delete(legajo);
        }

        public void Save(Alumno alu)
        {
            AlumnoData.Save(alu);
        }
    }
}

