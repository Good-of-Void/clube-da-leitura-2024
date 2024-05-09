using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;
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
        public Caixa Caixa {  get; set; }
        public string TituloRevista { get; set; }
        public string NumeroEdicao { get; set; }
        public string AnoRevista { get; set; }
        public bool Disponivel {  get; set; } = true;
        //Construtor
        public Revista (string tituloRevista, string numeroEdicao, string anoRevista, Caixa caixa)
        {
            this.TituloRevista = tituloRevista;
            this.NumeroEdicao = numeroEdicao;
            this.AnoRevista = anoRevista;
            this.Caixa = caixa; 
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
