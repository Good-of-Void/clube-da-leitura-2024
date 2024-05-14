using ClubeDaLeitura.ConsoleApp.Compartilhado;


namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal principal = new TelaPrincipal();
            while (true)
            {
                ITelaCadastros tela = principal.ApresentarMenuPrincipal();

                if (tela == null)
                    break;

                char submenu_Escolida = tela.ApresetarMenu();

                if (submenu_Escolida == 'S' || submenu_Escolida == 's')
                    continue;

                else if (submenu_Escolida == '1')
                    tela.Registrar();

                else if (submenu_Escolida == '2')
                    tela.Editar();

                else if (submenu_Escolida == '3')
                    tela.Excluir();

                else if (submenu_Escolida == '4')
                    tela.VisualizarRegistros(true);

                else if (submenu_Escolida == '5' && tela is Tela telaAmigo)
                    telaAmigo.PagarMulta();
            }
        } 
    }
}
