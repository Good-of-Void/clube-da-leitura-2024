using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Responsavel
{
    internal class Reserva : EntidadeBase
    {
        //variaveis
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime Data_Reserva { get; set; }
        public bool Valido { get; set; } = true;

        //Construtor
        public Reserva(Amigo amigo, Revista lista)
        {
            this.Amigo = amigo;
            this.Revista = lista;
            this.Data_Reserva = DateTime.Now;
        }
        //atualizando as reservas
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Reserva novo = (Reserva)novoegistro;

            this.Amigo = novo.Amigo;
            this.Revista = novo.Revista;
            this.Data_Reserva = novo.Data_Reserva;
        }
        //validando os inputs do usuário
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Convert.ToString(Amigo).Trim()))
                erros.Add("O campo \"Amigo\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Revista).Trim()))
                erros.Add("O campo \"revistas\" é obrigatório");

            return erros;
        }
    }
}