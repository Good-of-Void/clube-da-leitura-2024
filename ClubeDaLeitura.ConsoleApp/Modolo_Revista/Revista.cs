using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Revista
{
    internal class Revista : EntidadeBase
    {
        //Variaveis
        public string TituloRevista { get; set; }
        public int NumeroEdicao { get; set; }
        public int AnoRevista { get; set; }
        //Construtor
        public Revista (string tituloRevista, int numeroEdicao, int anoRevista)
        {
            this.TituloRevista = tituloRevista;
            this.NumeroEdicao = numeroEdicao;
            this.AnoRevista = anoRevista;
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Revista novo = (Revista)novoegistro;

            this.TituloRevista = novo.TituloRevista;
            this.NumeroEdicao = novo.NumeroEdicao;
            this.AnoRevista = novo.AnoRevista;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(TituloRevista.Trim()))
                erros.Add("O campo \"Titulo da revista\" é obrigatório");
                
            return erros;
        }
    }
}
