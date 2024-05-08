using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;


namespace ClubeDaLeitura.ConsoleApp.Modolo_Revista
{
    internal class Tela_Revista : TelaBase
    {
        public Tela_Caixa tela_Caixa =  null;
        public Repositorio_Caixa repositorio_Caixa = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Revistas...");
            }
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -18} | {3, -15} | {4, -15}",
                "Id", "Titulo revista", "Numero da edição", "Ano da revista", "Etiqueta da caixa"
            );
            List<EntidadeBase> revistas_Cadastradas = repositorio.SelecionarTodos();

            foreach (Revista revista in revistas_Cadastradas)
            {
                if (revista == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -18} | {3, -15} | {4, -15}",
                    revista.Id, revista.TituloRevista, revista.NumeroEdicao, revista.AnoRevista, revista.Caixa.Etiqueta
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

            tela_Caixa.VisualizarRegistros(true);

            Console.Write("Digite o id da caixa: ");
            int id_Caixa = (int)Convert.ToUInt32(Console.ReadLine());

            Caixa caixa_Selecionada = (Caixa)repositorio_Caixa.SelecionarPorId(id_Caixa);

            Revista nova_Revista = new Revista(tituloRevista, numeroEdicao, anoRevista, caixa_Selecionada);

            return nova_Revista;
        }      
    }
}
