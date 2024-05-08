using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;
using ControleMedicamentos.ConsoleApp.Compartilhado;


namespace ClubeDaLeitura.ConsoleApp.Modolo_Caixa
{
    internal class Tela_Caixa : TelaBase
    {
        public Tela_Revista tela_Revista = null;
        public Repositorio_Revista repositorio_Revista = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Caixas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {2, -20}",
                "Id", "Etiqueta", "Cor da caixa", "Quantidade de dias"
            );

            List<EntidadeBase> caixa_Cadastrados = repositorio.SelecionarTodos();

            foreach (Caixa caixa in caixa_Cadastrados)
            {
                if (caixa == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {2, -20}",
                    caixa.Id, caixa.Etiqueta, caixa.CorDaCaixa, caixa.QuantidadeDias
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

            tela_Revista.VisualizarRegistros(false);

            Console.Write("Digite o id da caixa: ");
            int id_Caixa = (int)Convert.ToUInt32(Console.ReadLine());

            Revista revista_Selecionada = (Revista)repositorio_Revista.SelecionarPorId(id_Revista);           

            Caixa caixa = new Caixa(etiqueta, cordaCaixa, quantidadeDias, revista_Selecionada);

            return caixa;
        }
    }
}
