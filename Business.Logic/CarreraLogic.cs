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
        public CarreraAdapter _CarreraData;

        public CarreraAdapter CarreraData
        {
            get { return _CarreraData; }
            set { _CarreraData = value; }
        }

        public CarrerasLogic()
        {
            CarreraData = new CarreraAdapter(); 
        }

        public List<Carrera> GetAll()
        {
            return CarreraData.GetAll();
        }

    }
}
