﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;


namespace ClubeDaLeitura.ConsoleApp.Modolo_Revista
{
    internal class Tela_Revista : TelaBase<Revista>, ITelaCadastros
    {
        public Tela_Caixa tela_Caixa = null;
        public Repositorio_Caixa repositorio_Caixa = null;

        public char ApresetarMenu()
        {
            throw new NotImplementedException();
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Revistas...");
            }
            Console.WriteLine();

            Console.WriteLine(
             "{0, -10} | {1, -20} | {2, -18} | {3, -15} | {4, -18}| {5, -15}",
             "Id", "Titulo revista", "Numero da edição", "Ano da revista", "Etiqueta da caixa", "Disponivel"
         );
            List<Revista> revistas_Cadastradas = repositorio.SelecionarTodos();
            string disponivel;

            foreach (Revista revista in revistas_Cadastradas)
            {
                if (revista.Disponivel) disponivel = "Sim";
                else disponivel = "Não";

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -18} | {3, -15} | {4, -18}| {5, -15}",
                    revista.Id, revista.Titulo_Revista, revista.Numero_Edicao, revista.Ano_Revista, revista.Caixa.Etiqueta, disponivel.ToString()
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }
        protected override Revista ObterRegistro()
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

            Caixa caixa_Selecionada = repositorio_Caixa.SelecionarPorId(id_Caixa);

            Revista nova_Revista = new Revista(tituloRevista, numeroEdicao, anoRevista, caixa_Selecionada);

            return nova_Revista;
        }
    }
}
