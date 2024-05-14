using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Emprestimo
{
    internal class Emprestimo : EntidadeBase
    {
        //Variaveis
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime Retirada { get; set; }
        public DateTime Devolucao { get; set; }
        public bool Estado { get; set; }

        //Contrutor para cadastro
        public Emprestimo(Amigo amigo, Revista revista)
        {
            this.Amigo = amigo;
            this.Retirada = DateTime.Now;
            this.Revista = revista;
            this.Estado = true;
        }

        //construtor para a devolucao
        public Emprestimo(Amigo amigo, Revista revista, DateTime retirada, DateTime devolucao, bool estado)
        {
            Amigo = amigo;
            this.Revista = revista;
            Retirada = retirada;
            Devolucao = devolucao;
            Estado = estado;
        }



        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            Emprestimo emprestimo_novo = (Emprestimo)novoegistro;

            this.Devolucao = emprestimo_novo.Devolucao;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();


            if (string.IsNullOrEmpty(Convert.ToString(Amigo).Trim()))
                erros.Add("O campo \"Amigo\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Revista).Trim()))
                erros.Add("O campo \"revistas\" é obrigatório");

            if (Revista.Disponivel != true)
                erros.Add("O campo \"revistas\" tem que estar disponivel");

            if (this.Amigo.Revista_Pega != null)
                erros.Add("O amigo não pode ter mais que uma revista emprestada");

            return erros;

        }
    }
}
