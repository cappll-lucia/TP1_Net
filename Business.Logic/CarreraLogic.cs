using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataBase;
using Business.Entities;

namespace Business.Logic
{
    public class CarrerasLogic
    {
        public CarreraAdapter _CarreraAdapter;

        public CarreraAdapter CarreraAdapter
        {
            get { return _CarreraAdapter; }
            set { _CarreraAdapter = value; }
        }

        public CarrerasLogic()
        {
            CarreraAdapter = new CarreraAdapter(); 
        }

        public List<Carrera> GetAll()
        {
            return CarreraAdapter.GetAll();
        }

    }
}
