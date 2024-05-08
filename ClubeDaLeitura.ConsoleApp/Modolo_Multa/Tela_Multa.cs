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
            throw new NotImplementedException();
        }
    }
}
