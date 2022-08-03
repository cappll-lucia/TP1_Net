using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Carrera : Entidades
    {
        private string _IdCarrera;
        private string _DescCarrera;

        public string IdCarrera
        {
            get { return _IdCarrera; }
            set { value = _IdCarrera; }
        }

        public string DescCarrera
        {
            get { return _DescCarrera; }
            set { _DescCarrera = value; }
        }

    }
}
