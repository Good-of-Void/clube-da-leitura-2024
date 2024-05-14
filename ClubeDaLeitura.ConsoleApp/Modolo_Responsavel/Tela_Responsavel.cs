using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Responsavel
{
    internal class Tela_Responsavel : TelaBase<Responsavel>,ITelaCadastros
    {
        public char ApresetarMenu()
        {
            throw new NotImplementedException();
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Responsaveis...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20}",
                "Id", "Nome", "Telefone"
            );

            List<Responsavel> lista_Resposveis = repositorio.SelecionarTodos();

            foreach (Responsavel responsavel in lista_Resposveis)
            {

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20}",
                    responsavel.Id, responsavel.Nome, responsavel.Telefone
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override Responsavel ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Responsavel responsavel = new Responsavel(nome, telefone);

            return responsavel;
        }
    }
}
