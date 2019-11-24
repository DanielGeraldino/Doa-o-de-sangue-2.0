using Doação_de_sangue_2._0.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Conexao
{
    internal interface IComunicaoDados
    {
        public void SalvarDados(Pessoa p);
        public void LerDados(Pessoa p);
        public void EditarDado(Pessoa p);
    }
}
