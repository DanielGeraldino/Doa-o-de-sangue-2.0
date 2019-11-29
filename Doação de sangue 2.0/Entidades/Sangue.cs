using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Sangue
    {
        private string tipo;
        private TiposSangues tiposSangues;

        public Sangue()
        {

        }

        public Sangue(string tipo)
        {
            //tiposSangues = new TiposSangues();
            try
            {
                if (TiposSangues.validaTipo(tipo))
                {
                    this.tipo = tipo;
                }
                else
                {
                    throw new Exception("Tipo sanguineo invalido!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public override string ToString()
        {
            return tipo;
        }

        public string[] PodeRecebeDe(string tipo)
        {
            //string[] tipos = tiposSangues.tipos;
            string[] tipos = TiposSangues.tipos;
            string[] listaSaguesCompativeis;

            if (tipo == tipos[0])
            {
                listaSaguesCompativeis = new string[] { tipos[0], tipos[1], tipos[6], tipos[7] };
                return listaSaguesCompativeis;
            }
            if (tipo == tipos[1])
            {
                listaSaguesCompativeis = new string[] { tipos[1], tipos[7] };
                return listaSaguesCompativeis;
            }
            if (tipo == tipos[2])
            {
                listaSaguesCompativeis = new string[] { tipos[2], tipos[3], tipos[6], tipos[7] };
                return listaSaguesCompativeis;
            }
            if (tipo == tipos[3])
            {
                listaSaguesCompativeis = new string[] { tipos[3], tipos[7] };
                return listaSaguesCompativeis;
            }
            if (tipo == tipos[4])
            {
                listaSaguesCompativeis = new string[] { tipos[0], tipos[1], tipos[2], tipos[3], tipos[4], tipos[5], tipos[6], tipos[7] };
                return listaSaguesCompativeis;
            }

            if (tipo == tipos[5])
            {
                listaSaguesCompativeis = new string[] { tipos[1], tipos[3], tipos[5], tipos[7] };
                return listaSaguesCompativeis;
            }

            if (tipo == tipos[6])
            {
                listaSaguesCompativeis = new string[] { tipos[6], tipos[7] };
                return listaSaguesCompativeis;
            }

            if (tipo == tipos[7])
            {
                listaSaguesCompativeis = new string[] { tipos[7] };
                return listaSaguesCompativeis;
            }

            return null;
        }

        public bool verificaCompatibilidade(string tipoDoDoador, string tipoDoPaciente)
        {
            string[] listaPossiveisTiposSanguineos = PodeRecebeDe(tipoDoPaciente);

            for (int i = 0; i < listaPossiveisTiposSanguineos.Length; i++)
            {
                if (listaPossiveisTiposSanguineos[i] == tipoDoDoador)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
