using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;
using ClubeDaLeitura.ConsoleApp.Modolo_Emprestimo;
using ClubeDaLeitura.ConsoleApp.Modolo_Multa;
using ClubeDaLeitura.ConsoleApp.Modolo_Reserva;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;


namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //chamar o modolo Responsavel
            Repositorio_Responsavel repositorio_Responsavel = new Repositorio_Responsavel();
            Tela_Responsavel tela_Responsavel = new Tela_Responsavel();

            tela_Responsavel.tipoEntidade = "Responsavel";
            tela_Responsavel.repositorio = repositorio_Responsavel;

            //chamar modolo Amigo
            Repositorio_Amigo repositorio_Amigo = new Repositorio_Amigo();
            Tela_Amigo tela_Amigo = new Tela_Amigo();

            tela_Amigo.tipoEntidade = "Amigo";
            tela_Amigo.repositorio = repositorio_Amigo;

            tela_Amigo.repositorio_Responsavel = repositorio_Responsavel;
            tela_Amigo.tela_Responsavel = tela_Responsavel;

            //chamar módulo caixa
            Repositorio_Caixa repositorio_Caixa = new Repositorio_Caixa();
            Tela_Caixa tela_Caixa = new Tela_Caixa();

            tela_Caixa.tipoEntidade = "Caixa";
            tela_Caixa.repositorio = repositorio_Caixa;

            //chamar modulo revista
            Repositorio_Revista repositorio_Revista = new Repositorio_Revista();
            Tela_Revista tela_Revista = new Tela_Revista();

            tela_Revista.tipoEntidade = "Revista";
            tela_Revista.repositorio= repositorio_Revista;

            tela_Revista.tela_Caixa = tela_Caixa;
            tela_Revista.repositorio_Caixa = repositorio_Caixa;

            //chamar modulo emprestimo
            Repositorio_Emprestimo repositorio_Emprestimo = new Repositorio_Emprestimo();
            Tela_Emprestimo tela_Emprestimo = new Tela_Emprestimo();

            tela_Emprestimo.tipoEntidade = "Emprestimo";
            tela_Emprestimo.repositorio = repositorio_Emprestimo;

            tela_Emprestimo.tela_Amigo = tela_Amigo;
            tela_Emprestimo.repositorio_Amigo = repositorio_Amigo;

            tela_Emprestimo.tela_Revista= tela_Revista;
            tela_Emprestimo.repositorio_Revista = repositorio_Revista;

            //chamar modulo reserva
            Repositorio_Reserva repositorio_Reserva = new Repositorio_Reserva();
            Tela_Reserva tela_Reserva = new Tela_Reserva();

            tela_Reserva.tipoEntidade = "Reserva";
            tela_Reserva.repositorio = repositorio_Reserva;

            tela_Reserva.tela_Amigo = tela_Amigo;
            tela_Reserva.repositorio_Amigo = repositorio_Amigo;

            tela_Reserva.tela_Revista = tela_Revista;
            tela_Reserva.repositorio_Revista = repositorio_Revista;

            //chamar modulo multa
            Repositorio_Multa repositorio_Multa = new Repositorio_Multa();
            Tela_Multa tela_Multa = new Tela_Multa();

            tela_Multa.tipoEntidade = "Multa";
            tela_Amigo.repositorio = repositorio_Multa;

            tela_Multa.tela_Amigo = tela_Amigo;
            tela_Multa.repositorio_Amigo = repositorio_Amigo;


            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;
                //id do submenu
                int id = 0;
                if (opcaoPrincipalEscolhida == '1')
                {
                    tela = tela_Responsavel;
                    id = 0;
                }
                else if (opcaoPrincipalEscolhida == '2')
                {
                    tela = tela_Amigo;
                    id = 0;
                }
                else if (opcaoPrincipalEscolhida == '3')
                {
                    tela = tela_Caixa;
                    id = 0;
                }
                else if (opcaoPrincipalEscolhida == '4')
                {
                    tela = tela_Revista;
                    id = 0;
                }
                else if (opcaoPrincipalEscolhida == '5')
                {
                    tela = tela_Emprestimo;
                    id = 1;
                }
                else if (opcaoPrincipalEscolhida == '6')
                {
                    tela = tela_Reserva;
                    id = 1;
                }
                else if (opcaoPrincipalEscolhida == '7')
                {
                    tela = tela_Amigo;
                    id = 2;
                }

                if (id == 0) 
                { 
                    char operacaoEscolhida = tela.ApresentarMenu();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                    if (operacaoEscolhida == '1')
                           tela.Registrar();
  
                    else if (operacaoEscolhida == '2')
                            tela.Editar();
                    
                    else if (operacaoEscolhida == '3')
                         tela.Excluir();

                    else if (operacaoEscolhida == '4')
                        tela.VisualizarRegistros(true);

                }
                else if(id == 1)
                {
                    char operacaoEscolhida = tela.ApresentarMenu2();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        continue;

                    if (operacaoEscolhida == '1')
                        tela.Registrar();

                    else if (operacaoEscolhida == '2')
                        tela.Concluir();

                    else if (operacaoEscolhida == '3')
                        tela.Excluir();

                    else if (operacaoEscolhida == '4')
                        tela.VisualizarRegistros(true);
                }
                else
                {
                    char operacaoEscolhida = tela.ApresentarMenuMultas();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        continue;

                    if (operacaoEscolhida == '1')
                        tela.Quitar();

                    else if (operacaoEscolhida == '2')
                        tela.VisualizarRegistros(true);
                }


            }
        }
    }
}
