using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Pessoa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Emprestimo
{
    internal class Tela_Emprestimo : TelaBase
    {
        //para buscar as revistas ja cadastrado
        public Tela_Revista tela_Revista = null;
        public Repositorio_Revista repositorio_Revista = null;

        //para buscar os Amigos ja cadastrado
        public Tela_Amigo tela_Amigo = null;
        public Repositorio_Amigo repositorio_Amigo = null;

        private string estado;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -25} | {3, -25} | {4, -25} | {5, -25}",
                "Id", "Amigo","id Revista emprestada","Data do Emprestimo","Data da Devolução" ,"Aberto"
            );

            List<EntidadeBase> lista_Eprestimos = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in lista_Eprestimos)
            {
                //this.VerificarMulta(emprestimo);
                TimeSpan diferenca = emprestimo.Devolucao.Subtract(DateTime.Now);
                int dias = diferenca.Days;
                if(emprestimo.Estado)
                {
                    this.estado = "sim";
                }
                else
                {
                    this.estado = "Não";
                }
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -25} | {3, -25} | {4, -25} | {5, -25}",
                    emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Revista.Id,emprestimo.Retirada,
                    emprestimo.Devolucao, this.estado.ToString()
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
                tela_Revista.VisualizarRegistros(true);

                Console.Write("Digite o id da revista: ");
                int id_Revista = (int)Convert.ToUInt32(Console.ReadLine());

                Revista revista_Selecionada = (Revista)repositorio_Revista.SelecionarPorId(id_Revista);

            tela_Amigo.VisualizarRegistros(true);

            Console.Write("Digite o id do amigo: ");
            int id_Amigo = (int)Convert.ToUInt32(Console.ReadLine());

            Amigo amigo_Selecionado = (Amigo)repositorio_Amigo.SelecionarPorId(id_Amigo);

            Emprestimo emprestimo = new Emprestimo(amigo_Selecionado, revista_Selecionada);

                return emprestimo;

        }
    }
}
