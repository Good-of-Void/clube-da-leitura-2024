using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;
using ClubeDaLeitura.ConsoleApp.Modolo_Emprestimo;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Reserva
{
    internal class Tela_Reserva : TelaBase
    {      
        //para buscar as revistas ja cadastradas
        public Tela_Revista tela_Revista = null;
        public Repositorio_Revista repositorio_Revista = null;

        //para buscar os Amigos ja cadastrados
        public Tela_Amigo tela_Amigo = null;
        public Repositorio_Amigo repositorio_Amigo = null;

        //chamando tela emprestimo
        public Tela_Emprestimo tele_Emprestimo = null;
        public Repositorio_Emprestimo repositorio_Emprestimo = null;
        
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Reserva...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20}",
                "Id", "Amigo", "Revista");

            List<EntidadeBase> lista_Reserva = repositorio.SelecionarTodos();

            foreach (Reserva reserva in lista_Reserva)
            {               
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20}",
                    reserva.Id, reserva.Amigo.Nome, reserva.Revista.Titulo_Revista
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

            Console.Write("Digite a data da reserva: ");
            DateTime retirada = Convert.ToDateTime(Console.ReadLine());

            Reserva Reserva = new Reserva(amigo_Selecionado, revista_Selecionada, retirada);

            return Reserva;
        
        }
    }
}

