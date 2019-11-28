using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Doação_de_sangue_2._0.Entidades;

namespace Doação_de_sangue_2._0.Conexao
{
    class DadoPaciente
    {
        private static string PASTA_DADOS = ".\\DADOS\\";
        private static string DADOS_PACIENTES = ".\\DADOS\\PACIENTES.CSV";

        public static void EditarDado(Pessoa p)
        {
            throw new NotImplementedException();
        }

        public static List<Paciente> LerDados()
        {
            if (!File.Exists(DADOS_PACIENTES))
            {
                Directory.CreateDirectory(PASTA_DADOS);
                File.CreateText(DADOS_PACIENTES).Close();

                Console.WriteLine("Criando Arq");
            }

            List<Paciente> dadosPacientes = File.ReadAllLines(DADOS_PACIENTES)
                .Select(a => a.Split(";"))
                .Select(p => new Paciente(p[0], p[1], int.Parse(p[2]), p[3], float.Parse(p[4]), float.Parse(p[5])))
                .ToList();

            return dadosPacientes;
        }

        public static void SalvarDado(Pessoa p)
        {
            if(p != null)
            {
                using(StreamWriter sw = File.AppendText(DADOS_PACIENTES))
                {
                    sw.WriteLine($"{p.getId()};{p.getNome()};{p.getIdade()};{p.getSangue()};{p.getPeso()};{p.getAltura()}");
                }
            }
        }
    }
}
