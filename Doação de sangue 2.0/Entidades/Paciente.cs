using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Paciente : Pessoa
    {
        public Paciente(string id, string nome, int idade, string sangue, float peso, float altura)
            : base(id, nome, idade, sangue, peso, altura)
        {

        }

    }
}
