using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Doação_de_sangue_2._0.Entidades;

namespace Doação_de_sangue_2._0.Conexao
{
    class DadoPaciente : IComunicaoDados
    {
        private static string PASTA_DADOS = @".\DADOS\";
        private static string DADOS_PACIENTES = @".\DADOS\PACIENTES.CSV";

        public DadoPaciente()
        {
            if (!File.Exists(PASTA_DADOS))
            {
                Directory.CreateDirectory(PASTA_DADOS);
            }
        }

        public void EditarDado(Pessoa p)
        {
            throw new NotImplementedException();
        }

        public void LerDados(Pessoa p)
        {
            throw new NotImplementedException();
        }

        public void SalvarDado(Pessoa p)
        {
            if(p != null)
            {
                using(StreamWriter sw = File.AppendText(DADOS_PACIENTES))
                {
                    sw.Write($"{p.getId()};{p.getNome()};{p.getSangue()};{p.getPeso()};{p.getAltura()}");
                }
            }
        }
    }
}
