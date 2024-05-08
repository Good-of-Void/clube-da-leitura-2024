using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Multa
{
    internal class Tela_Multa : TelaBase
    {
      
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
                "Id", "Valor da multa", "Data de abertura"
            );

            List<EntidadeBase> multas_Cadastradas = repositorio.SelecionarTodos();

            foreach (Multa multa in multas_Cadastradas)
            {
                if (multa == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} |",
                    multa.Id, multa.ValorMulta, multa.DataAbertura 
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o valor da multa: ");
            string  valorMulta = Console.ReadLine();

            Console.Write("Digite a data de abertura da multa: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());        

            Multa novaMulta = new Multa(valorMulta, dataAbertura);

            return novaMulta;
        }
    }
}
