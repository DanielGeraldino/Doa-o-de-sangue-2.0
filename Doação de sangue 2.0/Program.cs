using Doação_de_sangue_2._0.Entidades;
using System;

namespace Doação_de_sangue_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Paciente p = new Paciente("daniel", 21, "A+", 80.0f, 1.7f);
            Doador d = new Doador("pedro", 21, "O-", 80.0f, 1.7f);

            Console.WriteLine(Pessoa.compatibilidadeDeSangue(d.getSangue(), p.getSangue()));
            
        }
    }
}
