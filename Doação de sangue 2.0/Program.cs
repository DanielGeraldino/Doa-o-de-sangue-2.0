using Doação_de_sangue_2._0.Entidades;
using System;

namespace Doação_de_sangue_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Doador doador = new Doador("daniel", 21, 80.0f, 1.7f);

            Console.WriteLine(doador.getNome());
        }
    }
}
