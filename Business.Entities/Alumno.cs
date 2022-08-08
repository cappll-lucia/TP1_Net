using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Alumno : Entidades
    {
        private int _Legajo;
        private string _Nombre;
        private string _Apellido;
        private int _IdCarrera;
        private string _Estado;

        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
        public string Estado { get => _Estado; set => _Estado = value; }


    }
}
