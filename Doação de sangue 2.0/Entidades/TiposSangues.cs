using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class  TiposSangues
    {
        public static String[] tipos = {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };

        public static bool validaTipo(string tipo)
        {
            if(procuraTipo(tipo) != -1)
            {
                return true;
            }

            return false;
        }

        private static int procuraTipo(string t)
        {
            for(int i = 0; i < tipos.Length; i++)
            {
                if (tipos.Equals(t))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
