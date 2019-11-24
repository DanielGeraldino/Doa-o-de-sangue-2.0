using System;
using System.Collections.Generic;
using System.Text;

namespace Doação_de_sangue_2._0.Entidades
{
    class Pessoa
    {
        protected string id;
        protected string nome;
        protected int idade;
        protected float peso;
        protected float altura;
        protected Sangue sangue { get; }

        public Pessoa(string id, string nome, int idade, string sangue, float peso, float altura)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.sangue = new Sangue(sangue);
            this.peso = peso;
            this.altura = altura;
        }

        public string getId()
        {
            return this.id;
        }

        public string getNome()
        {
            return this.nome;
        }

        public int getIdade()
        {
            return this.idade;
        }

        public string[] sangueCompativeis()
        {
            return sangue.PodeRecebeDe(sangue.ToString());
        }

        public string getSangue()
        {
            return sangue.ToString();
        }

        public float getPeso()
        {
            return peso;
        }

        public float getAltura()
        {
            return altura;
        }

        public static bool compatibilidadeDeSangue(string tDoador, string tPaciente)
        {
            return new Sangue().verificaCompatibilidade(tDoador, tPaciente);
        }

    }
}
