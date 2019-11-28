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

        public void addDoador(Doador d)
        {
            if(d != null)
            {
                DadoDoador.SalvarDado(d);
                doadores.Add(d);
            }
        }

        public void addPaciente(Paciente p)
        {
            if(p != null)
            {
                DadoPaciente.SalvarDado(p);
                pacientes.Add(p);
            }
        }

        public bool doarSangue(string idPaciente, string idDoador)
        {
            
            Doador doador = doadores.Find(x => x.getId() == idDoador);
            Paciente paciente = pacientes.Find(x => x.getId() == idPaciente);
                    
            if (doador.podeDoar() && Paciente.compatibilidadeDeSangue(doador.getSangue(), paciente.getSangue()))
            {

                doadores.Remove(doador);
                pacientes.Remove(paciente);

                return true;
            }

            return false;
        }

        public void listaPacientes()
        {
            foreach(var p in pacientes)
            {
                String paciente = $"Paciente: {p.getNome()}, Idade: {p.getIdade()}, Sangue: {p.getSangue()}";
                Console.WriteLine(paciente);
            }
        }

        public void listaDoadores()
        {
            foreach(var d in doadores)
            {
                String doadores = $"Doador: {d.getNome()}, Idade: {d.getIdade()}, Sangue: {d.getSangue()}";
                Console.WriteLine(doadores);
            }
        }
    }
}
