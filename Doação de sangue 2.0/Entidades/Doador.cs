using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Doador : Pessoa
    {
        public Doador(string nome, int idade, string sangue, float peso, float altura)
            : base(nome, idade, sangue, peso, altura)
        {

        }
    }
}