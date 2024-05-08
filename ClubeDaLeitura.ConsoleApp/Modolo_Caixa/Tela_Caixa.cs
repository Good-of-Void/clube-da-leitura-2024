using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;
using ClubeDaLeitura.ConsoleApp.Compartilhado;


namespace ClubeDaLeitura.ConsoleApp.Modolo_Caixa
{
    internal class Tela_Caixa : TelaBase
    {      
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Caixas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                "Id", "Etiqueta", "Cor da caixa", "Quantidade de dias"
            );

            List<EntidadeBase> caixa_Cadastrados = repositorio.SelecionarTodos();

            foreach (Caixa caixa in caixa_Cadastrados)
            {
                if (caixa == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                    caixa.Id, caixa.Etiqueta, caixa.CorDaCaixa, caixa.Dias_Max
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite a etiqueda: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string  cordaCaixa = Console.ReadLine();

            Console.Write("Digite a quantidade de dias de empréstimo: ");
            int quantidadeDias = (int)Convert.ToUInt32(Console.ReadLine());                

            Caixa caixa = new Caixa(etiqueta, cordaCaixa, quantidadeDias);

            return caixa;
        }
    }
}
