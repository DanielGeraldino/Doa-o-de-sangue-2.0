using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Sangue
    {
        private string tipo;

        public Sangue(string tipo)
        {
            if (TiposSangues.validaTipo(tipo))
            {
                this.tipo = tipo;
            }
        }

        public override string ToString()
        {
            return tipo;
        }
    }
}
