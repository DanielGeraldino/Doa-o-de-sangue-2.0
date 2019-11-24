using Doação_de_sangue_2._0.Entidades;
using System;

namespace Doação_de_sangue_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Clinica c = new Clinica(1, "Clinica 1");

            Paciente p = new Paciente("1", "daniel", 21, "A-", 80.0f, 1.7f);
            Doador d = new Doador("2", "pedro", 21, "A-", 80.0f, 1.7f);

            c.addDoador(d);
            c.addPaciente(p);

            c.listaPacientes();

            Console.WriteLine(c.doarSangue("1", "2"));
            
        }
    }
}
