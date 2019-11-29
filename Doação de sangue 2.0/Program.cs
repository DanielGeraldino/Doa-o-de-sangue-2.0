using Doação_de_sangue_2._0.Entidades;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Doação_de_sangue_2._0.Painel;

namespace Doação_de_sangue_2._0
{
    class Program
    {
        static Clinica c;
        static TelaPrincipal tl;

        static void Main(string[] args)
        {
            c = new Clinica(1, "HR HEMO");

            tl = new TelaPrincipal(c);

            programa();
        }

        static void programa()
        {
            int escolha = tl.menuPrincipal();

            switch (escolha)
            {
                case 1:
                    tl.mCadastrarDoador();
                    programa();
                    break;
                case 2:
                    tl.mCadastrarPaciente();
                    programa();
                    break;
                case 3:
                    tl.mRealizaDoacao();
                    programa();
                    break;
                case 4:
                    tl.mImprimirPacientes();
                    programa();
                    break;
                case 5:
                    tl.mImprimirDoadores();
                    programa();
                    break;
                case 6:
                    tl.imprimirDoaçoes();
                    programa();
                    break;
                case 7:
                    Console.Clear();
                    Environment.Exit(1);
                    break;
                default:
                    programa();
                    break;
            }
        }
    }
}
