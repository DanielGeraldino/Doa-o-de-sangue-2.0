using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Clinica
    {
        public int idClinica { get; private set; }
        public string nome { get; private set; }
        private List<Doador> doadores;
        private List<Paciente> pacientes;

        public Clinica(int id, string nome)
        {
            this.idClinica = id;
            this.nome = nome;
            doadores = new List<Doador>();
            pacientes = new List<Paciente>();
        }

        public void addDoador(Doador d)
        {
            if(d != null)
            {
                doadores.Add(d);
            }
        }

        public void addPaciente(Paciente p)
        {
            if(p != null)
            {
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
                Console.WriteLine(p.ToString());
            }
        }
    }
}
