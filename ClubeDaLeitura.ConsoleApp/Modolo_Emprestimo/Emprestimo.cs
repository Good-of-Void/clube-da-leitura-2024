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
        public Amigo Amigo {  get; set; }
        public List<Revista> revistas_Selecionadas { get; set; }
        public DateTime Retirada { get; set; }
        public DateTime Devolucao { get; set; }

        //Contrutor
        public Emprestimo(Amigo amigo,DateTime retirada,List<Revista> lista)
        {
            this.Amigo = amigo;
            this.Retirada = retirada;
            this.revistas_Selecionadas = lista;
        }
        

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();


            if (string.IsNullOrEmpty(Convert.ToString(Amigo).Trim()))
                erros.Add("O campo \"Amigo\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(revistas_Selecionadas).Trim()))
                erros.Add("O campo \"revistas\" é obrigatório");

            if (string.IsNullOrEmpty(Convert.ToString(Retirada).Trim()))
                erros.Add("O campo \"data do Emprestimo\" é obrigatório");

            return erros;

        }
    }
}
