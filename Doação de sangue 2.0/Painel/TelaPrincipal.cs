﻿using Doação_de_sangue_2._0.Conexao;
using Doação_de_sangue_2._0.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Painel
{
    class TelaPrincipal
    {
        private Clinica clinica;
        
        public TelaPrincipal(Clinica clinica)
        {
            this.clinica = clinica;
        }
        
        public int menuPrincipal()
        {
            int escolha = 0;

            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[1] - Cadastrar doador");
            Console.WriteLine("[2] - Cadastrar paciente");
            Console.WriteLine("[3] - Realiza doação");
            Console.WriteLine("[4] - Imprimir pacientes na fila");
            Console.WriteLine("[5] - Imprimir doadores na fila");
            Console.WriteLine("[6] - Imprimir registros de doações");
            Console.WriteLine("[7] - Deseja sair\n");
            Console.WriteLine("----------------------------------");

            Console.Write("\nEscolha: ");
            escolha = int.Parse(Console.ReadLine());

            if(escolha > 0 && escolha <= 7)
                return escolha;
            return -1;
        }

        public void mCadastrarDoador()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando doador:");
            Console.WriteLine("----------------------------------");

            Console.Write("Digite a identidade: ");
            string id = Console.ReadLine();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o tipo sanguineo(exemplo A+): ");
            string tipo = Console.ReadLine().ToUpper();

            Console.Write("Digite a idade: ");
            int idade = int.Parse(Console.ReadLine());

            Console.Write("Digite digite o peso: ");
            float peso = float.Parse(Console.ReadLine());


            Console.Write("Digite digite a altura: ");
            float altura = float.Parse(Console.ReadLine());

            Console.WriteLine("----------------------------------");

            bool teste = clinica.addDoador(new Doador(id, nome, idade, tipo, peso, altura));

            Console.WriteLine("\nDoador cadastrado: " + teste);
            Console.ReadKey();
        }

        public void mCadastrarPaciente()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando paciente:");
            Console.WriteLine("----------------------------------");

            Console.Write("Digite a identidade: ");
            string id = Console.ReadLine();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o tipo sanguineo(exemplo A+): ");
            string tipo = Console.ReadLine().ToUpper();

            Console.Write("Digite a idade: ");
            int idade = int.Parse(Console.ReadLine());

            Console.Write("Digite digite o peso: ");
            float peso = float.Parse(Console.ReadLine());


            Console.Write("Digite digite a altura: ");
            float altura = float.Parse(Console.ReadLine());

            Console.WriteLine("----------------------------------");

            clinica.addPaciente(new Paciente(id, nome, idade, tipo, peso, altura));
        }

        public void mRealizaDoacao()
        {
            Console.Clear();
            Console.WriteLine("Para realiaza uma doação é necessario" +
                "\ndigitar o codigo do paciente e do doador.");

            Console.WriteLine("----------------------------------");
            Console.Write("Digite o codigo doador: ");
            string codigoDoador = Console.ReadLine();
            Console.Write("Digite o codigo recptor: ");
            string codigoPaciente = Console.ReadLine();

            Console.WriteLine("Doação realizada: " + clinica.doarSangue(codigoPaciente, codigoDoador));

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Utilize a função 6 para analisar os registros.");
            Console.Write("Digite entre para voltar.");
            Console.ReadLine();
        }

        public void mImprimirDoadores()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
            List<Doador> doadores = clinica.listaDoadores();
            
            if(doadores != null)
            {
                foreach (var d in doadores)
                {
                    string doador = $"ID: {d.getId()}, Doador: {d.getNome()}, Idade: {d.getIdade()}, Sangue: {d.getSangue()}";
                    Console.WriteLine(doador);
                }
            }
            else
            {
                Console.WriteLine("\nLista de pacientes esta vazia.\n");
            }

            Console.WriteLine("----------------------------------");
            Console.Write("Digite entre para voltar.");
            Console.ReadLine();
        }

        public void mImprimirPacientes()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
            List<Paciente> pacientes = clinica.listaPacientes();

            if(pacientes != null)
            {
                foreach (var d in pacientes)
                {
                    string paciente = $"ID: {d.getId()} Paciente: {d.getNome()}, Idade: {d.getIdade()}, Sangue: {d.getSangue()}";
                    Console.WriteLine(paciente);
                }
            } else
            {
                Console.WriteLine("\nLista de pacientes esta vazia.\n");
            }
            
            Console.WriteLine("----------------------------------");
            Console.Write("Digite entre para voltar.");
            Console.ReadLine();
        }

        public void imprimirDoaçoes()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------\n");
            //ComunicaoArquivo.leia("registro_doacoes.txt");
            List<string> dados = DadoDoacao.LerDados();
            if(dados != null)
            {
                foreach (string linha in dados)
                {
                    Console.WriteLine(linha);
                }
            }
            
            Console.WriteLine("\n----------------------------------");
            Console.Write("Digite entre para voltar.");
            Console.ReadLine();
        }
    }
}
