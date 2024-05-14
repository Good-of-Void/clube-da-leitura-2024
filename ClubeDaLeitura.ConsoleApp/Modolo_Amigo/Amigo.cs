using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Pessoa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Amigo
{
    internal class Amigo : Pessoa
    {
        //Variaveis
        public Responsavel Responsavel { get; set; }
        public Revista Revista_Pega { get; set; }
        public List<Multa> Multas { get; set; }
        public bool TemMulta
        { get
            {
                for (int i = 0; i < Multas.Count; i++)
                {
                    Multa multa = (Multa)Multas[i];

                    if (!multa.Paga)
                        return true;
                }

                return false;
            } 
        }

        public decimal ValorMulta
        {
            get
            {
                decimal valor = 0;

                for (int i = 0; i < Multas.Count; i++)
                {
                    Multa multa = (Multa)Multas[i];

                    if (!multa.Paga)
                        valor += multa.Valor;
                }

                return valor;
            }
        }

        //Contrutor
        public Amigo(string nome, string fone, Responsavel responsavel)
        {
            this.Nome = nome;
            this.Telefone = fone;
            this.Responsavel = responsavel;
        }

        //metados

        //responsavel por fazer a edição do objeto ja criado
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Amigo novo = (Amigo)novoegistro;

            this.Nome = novo.Nome;
            this.Telefone = novo.Telefone;
            this.Responsavel = novo.Responsavel;
        }

        //Responsavel por tratar as entradas
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Responsavel).Trim()))
                erros.Add("O campo \"responsavel\" é obrigatório");

            return erros;
        }

        public void Multar(Multa multa)
        {
            Multas.Add(multa);
        }

        public void PagarMultas()
        {
            for (int i = 0; i < Multas.Count; i++)
            {
                Multa multa = (Multa)Multas[i];

                if (!multa.Paga)
                    multa.Pagar();
            }
        }
    }
}
