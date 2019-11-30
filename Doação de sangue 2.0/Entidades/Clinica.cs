using Doação_de_sangue_2._0.Conexao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Clinica
    {
        public int idClinica { get; private set; }
        public string nome { get; private set; }
        private List<Doador> doadores = new List<Doador>();
        private List<Paciente> pacientes = new List<Paciente>();

        public Clinica(int id, string nome)
        {
            this.idClinica = id;
            this.nome = nome;
            doadores = DadoDoador.LerDados();
            pacientes = DadoPaciente.LerDados();
        }

        public bool addDoador(Doador d)
        {
            try
            {
                if (d.podeDoar())
                {
                    doadores.Add(d);
                    DadoDoador.SalvarDado(d);
                    
                    return true;
                } else
                {
                    throw new ClinicaException("Doador não pode realizar doações");              
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ADD: " + e.Message);
                return false;
            }
            
        }

        public bool addPaciente(Paciente p)
        {
            if(p != null && TiposSangues.validaTipo(p.getSangue()))
            {
                pacientes.Add(p);
                DadoPaciente.SalvarDado(p);
                
                return true;
            } 
            else
            {
                return false;
            }
        }

        public bool doarSangue(string idPaciente, string idDoador)
        {
            try
            {
                Doador doador = doadores.Find(x => x.getId() == idDoador);
                Paciente paciente = pacientes.Find(x => x.getId() == idPaciente);

                Console.WriteLine(doador.getNome());
                Console.WriteLine(paciente.getNome());

                if (Paciente.compatibilidadeDeSangue(doador.getSangue(), paciente.getSangue()))
                {

                    doadores.Remove(doador);
                    pacientes.Remove(paciente);

                    string texto = $"Sangue do {doador.getNome()}(Tipo: {doador.getSangue()}) doado para {paciente.getNome()}(tipo: {paciente.getSangue()})";

                    DadoDoacao.SalvarDado(paciente, doador, texto);

                    return true;
                }

                throw new ClinicaException("Sangue incompatíveis!");

            } catch(Exception e)
            {
                Console.WriteLine("Doaçao: " + e.Message);
                /*string texto = $"Sangue do {doador.getNome()}(Tipo: {doador.getSangue()}) não pode ser doado para {paciente.getNome()}(tipo: {paciente.getSangue()})";

                DadoDoacao.SalvarDado(paciente, doador, texto);*/
                return false;
            }
                                    
        }

        public List<Paciente> listaPacientes()
        {
            return pacientes;
        }

        public List<Doador> listaDoadores()
        {
            return doadores;
        }
    }
}
