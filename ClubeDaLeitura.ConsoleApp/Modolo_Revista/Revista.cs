using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Caixa;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Revista
{
    internal class Revista : EntidadeBase
    {
        //Variaveis
        public Caixa Caixa {  get; set; }
        public string Titulo_Revista { get; set; }
        public string Numero_Edicao { get; set; }
        public string Ano_Revista { get; set; }
        public bool Disponivel {  get; set; } = true;
        //Construtor
        public Revista (string tituloRevista, string numeroEdicao, string anoRevista, Caixa caixa)
        {
            this.Titulo_Revista = tituloRevista;
            this.Numero_Edicao = numeroEdicao;
            this.Ano_Revista = anoRevista;
            this.Caixa = caixa; 
        }
        //atualizando a revista
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Revista novo = (Revista)novoegistro;

            this.Titulo_Revista = novo.Titulo_Revista;
            this.Numero_Edicao = novo.Numero_Edicao;
            this.Ano_Revista = novo.Ano_Revista;
        }
        //validando os inputs do usuário
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo_Revista.Trim()))
                erros.Add("O campo \"Titulo da revista\" é obrigatório");

            if (string.IsNullOrEmpty(Numero_Edicao.Trim()))
                erros.Add("O campo \"Numero de edição\" é obrigatório");

            if (string.IsNullOrEmpty(Ano_Revista.Trim()))
                erros.Add("O campo \"Ano da revista\" é obrigatório");

            return erros;
        }
    }
}
