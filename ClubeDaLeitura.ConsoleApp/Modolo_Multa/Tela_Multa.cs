using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Multa
{
    internal class Tela_Multa : TelaBase
    {
        //para buscar o amigo ja cadastrado
        public Tela_Amigo tela_Amigo = new Tela_Amigo();
        public Repositorio_Amigo repositorio_Amigo = new Repositorio_Amigo();
    public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Multas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} |",
                "Id", "Amigo", "Valor da multa"
            );

            List<EntidadeBase> multas_Cadastradas = repositorio.SelecionarTodos();

            foreach (Amigo amigo in multas_Cadastradas)
            {
                if (amigo.Multa > 0)
                {
                    Console.WriteLine(
                        "{0, -10} | {1, -15} | {2, -15} |",
                        amigo.Id, amigo.Nome, amigo.Multa
                    );
                }
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
