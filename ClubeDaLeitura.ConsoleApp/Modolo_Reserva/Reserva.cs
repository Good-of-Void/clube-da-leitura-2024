using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Responsavel
{
    internal class Reserva : EntidadeBase
    {
        //variaveis
        public Amigo Amigo {  get; set; }
        public List<Revista> revistas_Disponiveis { get; set; }
        public DateTime Data_Reserva { get; set; }

        //Construtor
        public Reserva(Amigo amigo, List<Revista> lista, DateTime data_Reserva)
        {
            this.Amigo = amigo;
            this.revistas_Disponiveis = lista;
            this.Data_Reserva = data_Reserva;
        }
        //atualizando as reservas
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Reserva novo = (Reserva)novoegistro;

            this.Amigo = novo.Amigo;
            this.revistas_Disponiveis = novo.revistas_Disponiveis;
            this.Data_Reserva = novo.Data_Reserva;
        }
        //validando os inputs do usuário
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();


            if (string.IsNullOrEmpty(Convert.ToString(Amigo).Trim()))
                erros.Add("O campo \"Amigo\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(revistas_Disponiveis).Trim()))
                erros.Add("O campo \"revistas\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Data_Reserva).Trim()))
                erros.Add("O campo \"data da reserva\" é obrigatório");

            return erros;
        }
    }
}