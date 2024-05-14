using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Pessoa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Amigo
{
    internal class Tela_Amigo : TelaBase<Amigo>, ITelaCadastros
    {
        //para buscar os Responsaveis ja cadastrados
        public Tela_Responsavel Tela_Responsavel = null;
        public Repositorio_Responsavel Repositorio_Responsavel = null;

        public char ApresetarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"5 - Pagar Multas");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void PagarMulta()
        {
            ApresentarCabecalho();

            Console.WriteLine("Pagamento de Multas...");

            VisualizarAmigosComMulta();

            Console.Write("Digite o ID do amigo que deseja pagar as multas: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = repositorio.SelecionarPorId(idAmigo);

            Console.WriteLine($"Você deseja pagar o valor total de: R$ {amigo.ValorMulta}?");
            Console.WriteLine("1 - Pagar");
            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcao = Console.ReadLine()[0];

            if (opcao == 'S' || opcao == 's')
                return;

            amigo.PagarMultas();

            ExibirMensagem($"Multas com o valor de R$ {amigo.ValorMulta} pagas com sucesso!", ConsoleColor.Green);
        }



        //responsavel por estruturar de como vai ser mostrado os dados
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -20} | {4, -8} | {5, -20}",
                "Id", "Nome", "Telefone", "Multa", "Responsavel"
            );

            List<Amigo> lista_Amigos = repositorio.SelecionarTodos();
            string temMulta;

            foreach (Amigo amigo in lista_Amigos)
            {
                if (amigo.TemMulta) temMulta = "Sim";
                else temMulta = "Não";

                Console.WriteLine(
                    "{0, -5} | {1, -20} | {2, -20} | {4, -8} | {5, -20}",
                    amigo.Id, amigo.Nome,amigo.Telefone,temMulta,amigo.Responsavel.Nome 
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        private void VisualizarAmigosComMulta()
        {
            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -25}",
                "Id", "Nome", "Responsável", "Telefone", "Multa Acumulada"
            );

            List<Amigo> amigosCadastrados = ((Repositorio_Amigo)repositorio).SelecionarAmigosComMulta();

            foreach (Amigo amigo in amigosCadastrados)
            {
                if (amigo == null)
                    continue;

                Console.WriteLine(
                    "{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -25}",
                    amigo.Id, amigo.Nome, amigo.Responsavel.Nome, amigo.ValorMulta
                );
            }

            Console.ReadLine();
        }

        //responsavel por fazer o cadastro
        protected override Amigo ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Tela_Responsavel.VisualizarRegistros(true);

            Console.Write("Digite o id do responsavel: ");
            int id_Responsavel = (int)Convert.ToUInt32(Console.ReadLine());

            Responsavel responsavel_Selecionado = Repositorio_Responsavel.SelecionarPorId(id_Responsavel);

            Amigo amigo = new Amigo(nome, telefone, responsavel_Selecionado);

            return amigo;
        }
    }
}
