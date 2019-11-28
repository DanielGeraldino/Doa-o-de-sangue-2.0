using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Doador : Pessoa
    {
        public Doador(string id, string nome, int idade, string sangue, float peso, float altura)
            : base(id, nome, idade, sangue, peso, altura)
        {

        }

        public bool podeDoar()
        {
            if ((idade >= 18 && idade < 70) && peso > 50)
            {
                return true;
            }
            return false;
        }
    }
}