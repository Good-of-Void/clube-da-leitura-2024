using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;
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

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            throw new NotImplementedException();
        }

        protected override EntidadeBase ObterRegistro()
        {
            throw new NotImplementedException();
        }
    }
}

