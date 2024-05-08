using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Caixa
{
    internal class Caixa : EntidadeBase
    {
        //Variaveis
        public List<Revista> lista_Revista {  get; set; }
        public string Etiqueta {  get; set; }
        public string CorDaCaixa { get; set; }
        public int Dias_Max { get; set; }       
        public Caixa(string etiqueta, string cordaCaixa, int quantidadeDias)
        {
            this.Etiqueta = etiqueta;
            this.CorDaCaixa = cordaCaixa;
            this.Dias_Max = quantidadeDias;
            this.lista_Revista = new List<Revista>();
        }
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Caixa novo = (Caixa)novoegistro;

            this.Etiqueta = novo.Etiqueta;
            this.CorDaCaixa = novo.CorDaCaixa;
            this.Dias_Max = novo.Dias_Max;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Etiqueta.Trim()))
                erros.Add("O campo \"Etiqueta\" é obrigatório");
            
            if (string.IsNullOrEmpty(CorDaCaixa.Trim()))
                erros.Add("O campo \"Cor da Caixa\" é obrigatório");            
         
            return erros;
        }
    }
}
