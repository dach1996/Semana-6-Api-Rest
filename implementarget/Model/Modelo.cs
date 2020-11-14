using System;
using System.Collections.Generic;
using System.Text;

namespace implementarget
{
    public class Modelo
    {
        private int _codigo;

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        private string _edad;

        public string edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        private string _apelldio;

        public string apellido
        {
            get { return _apelldio; }
            set { _apelldio = value; }
        }
    }
}
