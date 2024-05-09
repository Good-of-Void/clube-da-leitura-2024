using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Pessoa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

        private string atraso;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -23} | {4, -20} | {5, -20}",
                "Id", "Amigo", "Data do Emprestimo", "N Revistas emprestadas", "Data Devolucao", "Atraso"
            );

            List<EntidadeBase> lista_Eprestimos = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in lista_Eprestimos)
            {
                this.VerificarMulta(emprestimo);
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -23} | {4, -20} | {5, -20}",
                    emprestimo.Id, emprestimo.Amigo, emprestimo.Retirada, emprestimo.revistas_Selecionadas.Count, emprestimo.Devolucao, this.atraso
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            List<Revista> lista_Revistas = new List<Revista>();

            lista_Revistas = Revistas_Selecionadas();

            tela_Amigo.VisualizarRegistros(true);

            Console.Write("Digite o id do amigo: ");
            int id_Amigo = (int)Convert.ToUInt32(Console.ReadLine());

            Amigo amigo_Selecionado = (Amigo)repositorio_Amigo.SelecionarPorId(id_Amigo);



            Console.Write("Digite a data do emprestimo: ");
            DateTime retirada = Convert.ToDateTime(Console.ReadLine());

            Emprestimo emprestimo = new Emprestimo(amigo_Selecionado,retirada,lista_Revistas);

            return emprestimo;
        }

        private void VerificarMulta(Emprestimo emprestimo)
        {
            decimal multa = 0;
            int auxAtraso = 0;
            if (emprestimo.Devolucao != null)
            {
                TimeSpan diferenca = emprestimo.Devolucao.Subtract(emprestimo.Retirada);
                int dias = diferenca.Days;

                foreach(Revista revista in emprestimo.revistas_Selecionadas)
                {
                    if(revista.Caixa.Dias_Max < dias)
                    {
                        auxAtraso++;
                        multa += 10;
                        for(int i = 1;i <= dias; i++)
                        {
                            multa += 2;
                        }

                    }
                }
                emprestimo.Amigo.Multa.Valor_Multa = multa;
                if(auxAtraso != 0)
                {
                    this.atraso = "Sim";
                }
                else
                {
                    this.atraso = "Não";
                }
            }
        }

        private List<Revista> Revistas_Selecionadas()
        {
            List<Revista> carrinho = new List<Revista>();

            while (true)
            {
                tela_Revista.VisualizarRegistros(true);

                Console.Write("Digite o id da Revista desejada: ");
                int id_Revista = (int)Convert.ToUInt32(Console.ReadLine());

                if (carrinho.Count != 0)
                {
                    foreach (Revista revista in carrinho)
                    {
                        if (revista.Id != id_Revista)
                        {
                            Revista revista_Selecinada = (Revista)repositorio_Revista.SelecionarPorId(id_Revista);
                            carrinho.Add(revista_Selecinada);

                        }
                        else
                        {
                            Console.WriteLine("Não pode selecionar a mesma revista");
                            break;
                        }
                    }
                }
                else
                {
                    Revista revista_Selecinada = (Revista)repositorio_Revista.SelecionarPorId(id_Revista);
                    carrinho.Add(revista_Selecinada);
                }

                Console.Write("quer add mais revista?(s/n)");
                char continua = Convert.ToChar(Console.ReadLine());
                if (continua == 'n' | continua == 'N') break;
            }
            return carrinho;
        }

    }
}
