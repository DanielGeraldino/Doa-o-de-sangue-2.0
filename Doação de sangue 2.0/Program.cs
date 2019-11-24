using Doação_de_sangue_2._0.Entidades;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Doação_de_sangue_2._0
{
    class Program
    {
        static void Main(string[] args)
        {/*
            Clinica c = new Clinica(1, "Clinica 1");

            Paciente p = new Paciente("1", "daniel", 21, "A-", 80.0f, 1.7f);
            Doador d = new Doador("2", "pedro", 21, "A-", 80.0f, 1.7f);

            c.addDoador(d);
            c.addPaciente(p);

            c.listaPacientes();

            Console.WriteLine(c.doarSangue("1", "2"));*/

            /*string path = "C:\\Users\\danie\\Documents\\Projetos\\doacao_sangue\\Doação de sangue 2.0\\Doação de sangue 2.0\\teste.csv";

            var teste = File.ReadAllLines(path)
                .Select(a => a.Split(";"))
                .Select(p => new Paciente(p[0], p[1], int.Parse(p[2]), p[3], float.Parse(p[4]), float.Parse(p[5])))
                .ToList();

            foreach(var i in teste)
            {
                Console.WriteLine(i.getNome());
            }*/

            string path = ".\\dados";

            Directory.CreateDirectory(path);

            using (StreamWriter sw = File.AppendText(path + "\\dados.csv"))
            {
                sw.Write("teste;teste");
            }

           
            
        }
    }
}
