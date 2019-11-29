using Doação_de_sangue_2._0.Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Doação_de_sangue_2._0.Conexao
{
    class DadoDoacao
    {
        private static string PASTA_DADOS = ".\\DADOS\\";
        private static string DADOS_DOACAO = ".\\DADOS\\DOACAO.CSV";

        public static void EditarDado()
        {
            throw new NotImplementedException();
        }

        public static List<string> LerDados()
        {
            try
            {
                if (File.Exists(DADOS_DOACAO))
                {
                    using (StreamReader sr = new StreamReader(DADOS_DOACAO))
                    {

                        List<string> linhas = new List<string>();
                        string linha = "";

                        while ((linha = sr.ReadLine()) != null)
                        {
                            linhas.Add(linha);
                        }

                        return linhas;
                    }
                }

                throw new Exception("Nenhum dado encontrado!");

            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
                return null;

            }
        }

        public static void SalvarDado(Paciente p, Doador d, string texto)
        {
            try
            {
                if (!File.Exists(DADOS_DOACAO))
                {
                    Directory.CreateDirectory(PASTA_DADOS);
                    File.CreateText(DADOS_DOACAO).Close();
                }

                using (StreamWriter sw = File.AppendText(DADOS_DOACAO))
                {
                    sw.WriteLine(DateTime.Now + ": " + texto);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}


