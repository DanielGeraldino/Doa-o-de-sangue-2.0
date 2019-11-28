﻿using Doação_de_sangue_2._0.Conexao;
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

                string texto = $"Sangue do {doador.getNome()}(Tipo: {doador.getSangue()}) doado para {paciente.getNome()}(tipo: {paciente.getSangue()})";

                DadoDoacao.SalvarDado(paciente, doador, texto);

                return true;
            }

            return false;
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
