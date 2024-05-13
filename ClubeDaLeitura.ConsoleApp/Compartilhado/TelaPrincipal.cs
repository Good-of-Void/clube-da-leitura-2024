
namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal static class TelaPrincipal
    {
        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube de Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastro de Responsaveis");
            Console.WriteLine("2 - Cadastro de Amigos");
            Console.WriteLine("3 - Cadastro de Caixa");
            Console.WriteLine("4 - Cadastro de Revista");
            Console.WriteLine("5 - Cadastro de Emprestimo ");
            Console.WriteLine("6 - Cadastro de Reserva ");
            Console.WriteLine("7 - Multas em aberto");

            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }

}

