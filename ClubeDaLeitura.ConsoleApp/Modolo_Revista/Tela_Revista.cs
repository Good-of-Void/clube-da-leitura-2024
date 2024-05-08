using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Revista
{
    internal class Tela_Revista : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Revistas...");
            }
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                "Id", "Titulo revista", "Numero da edição", "Ano da revista"
            );
            List<EntidadeBase> revistas_Cadastradas = repositorio.SelecionarTodos();

            foreach (Revista revista in revistas_Cadastradas)
            {
                if (revista == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    revista.Id, revista.TituloRevista, revista.NumeroEdicao, revista.AnoRevista
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o título da revista: ");
            string tituloRevista = Console.ReadLine();

            Console.Write("Digite o número de edição da revista: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da revista: ");
            string anoRevista = Console.ReadLine();

            Revista nova_Revista = new Revista(tituloRevista, numeroEdicao, anoRevista);

            return nova_Revista;
        }      
    }
}
