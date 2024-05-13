using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;
using ClubeDaLeitura.ConsoleApp.Modolo_Emprestimo;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;
using System.Globalization;

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
                "{0, -10} | {1, -20} | {2, -20}| {3, -20}",
                "Id", "Amigo", "Revista", "Valido");

            List<EntidadeBase> lista_Reserva = repositorio.SelecionarTodos();
            string disponivel;
            foreach (Reserva reserva in lista_Reserva)
            {
                if (this.Valido(reserva))
                {
                    disponivel = "Sim";
                }
                else
                {
                    disponivel = "Não";
                }
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20}| {3, -20}",
                    reserva.Id, reserva.Amigo.Nome, reserva.Revista.Titulo_Revista, disponivel.ToString()
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

            Reserva Reserva = new Reserva(amigo_Selecionado, revista_Selecionada);

            return Reserva;

        }

        private bool Valido(Reserva reserva)
        {
            DateTime dataMax = (reserva.Data_Reserva.AddDays(reserva.Revista.Caixa.Dias_Max));
            if (dataMax > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Concluir o {tipoEntidade}");
            Console.WriteLine($"3 - Visualizar {tipoEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }
    }
}

