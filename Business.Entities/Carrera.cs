using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Carrera : Entidades
    {
        private int _IdCarrera;
        private string _SiglaCarrera;
        private string _DescCarrera;

        public int IdCarrera
        {
            get { return _IdCarrera; }
            set { _IdCarrera = value; }
        }
        public string SiglaCarrera
        {
            get { return _SiglaCarrera; }
            set { _SiglaCarrera = value; }
        }

        public string DescCarrera
        {
            get { return _DescCarrera; }
            set { _DescCarrera = value; }
        }

        public override string ToString()
        {
            return DescCarrera;
        }

    }
}
