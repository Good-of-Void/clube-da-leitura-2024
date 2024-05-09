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
                "{0, -10} | {1, -20} | {2, -20} | {3, -23} | {4, -20}",
                "Id", "Amigo", "Data do Emprestimo", "id Revista emprestada", "Atraso"
            );

            List<EntidadeBase> lista_Eprestimos = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in lista_Eprestimos)
            {
                //this.VerificarMulta(emprestimo);
                TimeSpan diferenca = emprestimo.Devolucao.Subtract(DateTime.Now);
                int dias = diferenca.Days;
                if(dias > emprestimo.revista.Caixa.Dias_Max)
                {
                    this.atraso = "sim";
                }
                else
                {
                    this.atraso = "Não";
                }
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -23} | {4, -20}",
                    emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Retirada, emprestimo.revista.Id, this.atraso.ToString()
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

            Console.Write("Digite a data do emprestimo: ");
            DateTime retirada = Convert.ToDateTime(Console.ReadLine());

            Emprestimo emprestimo = new Emprestimo(amigo_Selecionado,retirada, revista_Selecionada);

            return emprestimo;
        }

        private void VerificarMulta(Emprestimo emprestimo)
        {
            decimal multa = 0;
            int auxAtraso = 0;
            Revista revista = emprestimo.revista;

            if (emprestimo.Devolucao != null)
            {
                TimeSpan diferenca = emprestimo.Devolucao.Subtract(emprestimo.Retirada);
                int dias = diferenca.Days;

                    if(revista.Caixa.Dias_Max < dias)
                    {
                        auxAtraso++;
                        multa += 10;
                        for(int i = 1;i <= dias; i++)
                        {
                            multa += 2;
                        }

                    }
                
                emprestimo.Amigo.Multa.ValorMulta = multa;
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
    }
}
