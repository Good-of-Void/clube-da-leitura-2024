using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Caixa
{
    internal class Caixa : EntidadeBase
    {
        //Variaveis
        public string Etiqueta {  get; set; }
        public string CorDaCaixa { get; set; }
        public int QuantidadeDias { get; set; } 
        public Caixa(string etiqueta, string cordaCaixa, int quantidadeDias, List<Revista> revistas_Pegas)
        {
            this.Etiqueta = etiqueta;
            this.CorDaCaixa = cordaCaixa;
            this.QuantidadeDias = quantidadeDias;
        }
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Caixa novo = (Caixa)novoegistro;

            this.Etiqueta = novo.Etiqueta;
            this.CorDaCaixa = novo.CorDaCaixa;
            this.QuantidadeDias = novo.QuantidadeDias;
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
