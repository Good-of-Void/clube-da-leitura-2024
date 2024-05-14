using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public interface ITelaCadastros
    {
        char ApresetarMenu();

        void Registrar();
        void Editar();
        void Excluir();
        void VisualizarRegistros(bool exibirTitulo);
    }
}
