using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Pessoa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Amigo
{
    internal class Tela_Amigo : TelaBase
    {
        //para buscar o responsavel ja cadastrado
        public Tela_Responsavel tela_Responsavel = null;
        public Repositorio_Responsavel repositorio_Responsavel = null;

        //responsavel por estruturar de como vai ser mostrado os dados
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                "Id", "Nome", "Telefone", "Revista em posse", "Multa", "Responsavel"
            );

            List<EntidadeBase> lista_Amigos = repositorio.SelecionarTodos();

            foreach (Amigo amigo in lista_Amigos)
            {
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                    amigo.Id, amigo.Nome, amigo.Telefone, amigo.revista_Pega, amigo.Multa, amigo.Responsavel.Nome
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        //responsavel por fazer o cadastro
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            tela_Responsavel.VisualizarRegistros(true);

            Console.Write("Digite o id do responsavel: ");
            int id_Responsavel = (int)Convert.ToUInt32(Console.ReadLine());

            Responsavel responsavel_Selecionado = (Responsavel)repositorio_Responsavel.SelecionarPorId(id_Responsavel);

            Pessoa amigo = new Amigo(nome, telefone, responsavel_Selecionado);

            return amigo;
        }
    }
}
