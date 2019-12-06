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

        private bool validarId(string id)
        {
            try
            {
                if (!(doadores.Find(x => x.getId() == id) != null))
                {
                    if (!(pacientes.Find(x => x.getId() == id) != null))
                    {
                        return true;
                    }
                    else
                    {
                        throw new ClinicaException("O id do doador já existe na base de dado!");
                    }

                }
                else
                {
                    throw new ClinicaException("O id do doador já existe na base de dado!");
                }
            } catch(ClinicaException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
            
        }

        public bool addDoador(Doador d)
        {
            try
            {
                if (d != null &&
                    d.podeDoar() && 
                    TiposSangues.validaTipo(d.getSangue()) && 
                    validarId(d.getId()))
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
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        public bool addPaciente(Paciente p)
        {
            try
            {
                if (p != null &&
                TiposSangues.validaTipo(p.getSangue()) &&
                validarId(p.getId()))
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool doarSangue(string idPaciente, string idDoador)
        {
            try
            {
                Doador doador = doadores.Find(x => x.getId() == idDoador);
                Paciente paciente = pacientes.Find(x => x.getId() == idPaciente);

                if(doador != null)
                {
                    if(paciente != null)
                    {
                        if (Paciente.compatibilidadeDeSangue(doador.getSangue(), paciente.getSangue()))
                        {

                            Console.WriteLine("\nDoador: " + doador.getNome());
                            Console.WriteLine("Paciente: " + paciente.getNome());

                            doadores.Remove(doador);
                            pacientes.Remove(paciente);

                            string texto = $"Sangue do {doador.getNome()}(Tipo: {doador.getSangue()}) doado para {paciente.getNome()}(tipo: {paciente.getSangue()})";

                            DadoDoacao.SalvarDado(paciente, doador, texto);

                            return true;
                        }
                        else
                        {
                            throw new ClinicaException("Sangue incompatíveis!");
                        }
                    } 
                    else
                    {
                        throw new ClinicaException("Codigo do paciente invalido!");
                    }
                } 
                else
                {
                    throw new ClinicaException("Codigo do doador invalido!");
                }
            }
            
            catch(Exception e)
            {
                Console.WriteLine("Doaçao: " + e.Message);
                
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

        public void salvarDados()
        {
            DadoDoador.EditarDado(listaDoadores());
            DadoPaciente.EditarDado(listaPacientes());
        }
    }
}
