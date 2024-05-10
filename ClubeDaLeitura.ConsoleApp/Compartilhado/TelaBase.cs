using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Emprestimo;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class TelaBase
    {
        public string tipoEntidade = "";
        public RepositorioBase repositorio = null;

        public char ApresentarMenu()
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

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public char ApresentarMenu2()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Concluir o {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public char ApresentarMenuMultas()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Quitar {tipoEntidade}");
            Console.WriteLine($"2 - Visualizar {tipoEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public virtual void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros.ToArray());
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void Editar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Editando {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"Digite o ID do {tipoEntidade} que deseja editar: ");
            int idEntidadeEscolhida = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idEntidadeEscolhida))
            {
                ExibirMensagem($"O {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros.ToArray());
                return;
            }

            bool conseguiuEditar = repositorio.Editar(idEntidadeEscolhida, entidade);

            if (!conseguiuEditar)
            {
                ExibirMensagem($"Houve um erro durante a edição de {tipoEntidade}", ConsoleColor.Red);
                return;
            }

            ExibirMensagem($"O {tipoEntidade} foi editado com sucesso!", ConsoleColor.Green);
        }

        public void Excluir()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Excluindo {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"Digite o ID do {tipoEntidade} que deseja excluir: ");
            int idRegistroEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idRegistroEscolhido))
            {
                ExibirMensagem($"O {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idRegistroEscolhido);

            if (!conseguiuExcluir)
            {
                ExibirMensagem($"Houve um erro durante a exclusão do {tipoEntidade}", ConsoleColor.Red);
                return;
            }

            ExibirMensagem($"O {tipoEntidade} foi excluído com sucesso!", ConsoleColor.Green);
        }

        public abstract void VisualizarRegistros(bool exibirTitulo);

        protected void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }

        protected void ApresentarCabecalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube da Leitura            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }

        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        protected abstract EntidadeBase ObterRegistro();

        public EntidadeBase ObterDataDevolucao(Emprestimo emprestimo)
        {
            Amigo amigo = emprestimo.Amigo;
            Revista revista = emprestimo.Revista;
            DateTime retirada = emprestimo.Retirada;

            Console.Write("Digite a data da devolução: ");
            DateTime devolucao = Convert.ToDateTime(Console.ReadLine());

            bool estado = emprestimo.Estado;

            EntidadeBase emprestimo_Novo = new Emprestimo(amigo,revista,retirada,devolucao,estado);
            return emprestimo_Novo;
        }

        public void Concluir()
        {

            ApresentarCabecalho();

            Console.WriteLine($"Concluir {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"Digite o ID do {tipoEntidade} que deseja concluir: ");
            int idEntidadeEscolhida = Convert.ToInt32(Console.ReadLine());

            List<EntidadeBase> lista_Eprestimos = repositorio.SelecionarTodos();
            EntidadeBase entidade;

            foreach (Emprestimo emprestimo in lista_Eprestimos)
            {
                if (idEntidadeEscolhida == emprestimo.Id)
                {
                    entidade = ObterDataDevolucao(emprestimo);

                    bool conseguiuEditar = repositorio.Editar(idEntidadeEscolhida, entidade);

                    if (!conseguiuEditar)
                    {
                        ExibirMensagem($"Houve um erro durante a edição de {tipoEntidade}", ConsoleColor.Red);
                        return;

                    }
                    ExibirMensagem($"O {tipoEntidade} foi editado com sucesso!", ConsoleColor.Green);
                    return;
                }
            }            
        }

        public void Quitar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Quitar {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"Digite o ID da {tipoEntidade} que deseja quitar: ");
            int idEntidadeEscolhida = Convert.ToInt32(Console.ReadLine());

            List<EntidadeBase> lista_Eprestimos = repositorio.SelecionarTodos();
            EntidadeBase entidade;
            foreach(Amigo amigo in lista_Eprestimos)
            {
                if(idEntidadeEscolhida == amigo.Id)
                {
                    amigo.Multa = 0;
                    break;
                }
            }
        }
    }
}
