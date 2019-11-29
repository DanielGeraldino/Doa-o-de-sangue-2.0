using Doação_de_sangue_2._0.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Doação_de_sangue_2._0.Conexao
{
    class DadoDoador
    {
        private static string PASTA_DADOS = ".\\DADOS\\";
        private static string DADOS_DOADOR = ".\\DADOS\\DOADOR.CSV";

        public static void EditarDado(Doador p)
        {
            throw new NotImplementedException();
        }

        public static List<Doador> LerDados()
        {
            try
            {
                if (File.Exists(DADOS_DOADOR))
                {
                    List<Doador> dadosDoador = File.ReadAllLines(DADOS_DOADOR)
                        .Select(a => a.Split(";"))
                        .Select(p => new Doador(p[0], p[1], int.Parse(p[2]), p[3], float.Parse(p[4]), float.Parse(p[5])))
                        .ToList();

                    return dadosDoador;
                }

                throw new Exception("Nenhum doador encontrado.");
            } 
            
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public static void SalvarDado(Doador p)
        {
            try
            {
                if (!File.Exists(DADOS_DOADOR))
                {
                    Directory.CreateDirectory(PASTA_DADOS);
                    File.Create(DADOS_DOADOR).Close();
                }
                if (p != null)
                {
                    using (StreamWriter sw = File.AppendText(DADOS_DOADOR))
                    {
                        sw.WriteLine($"{p.getId()};{p.getNome()};{p.getIdade()};{p.getSangue()};{p.getPeso()};{p.getAltura()}");
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
