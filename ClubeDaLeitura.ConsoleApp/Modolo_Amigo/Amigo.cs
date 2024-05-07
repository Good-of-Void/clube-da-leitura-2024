using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Multa;
using ClubeDaLeitura.ConsoleApp.Modolo_Pessoa;
using ClubeDaLeitura.ConsoleApp.Modolo_Responsavel;
using ClubeDaLeitura.ConsoleApp.Modolo_Revista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Amigo
{
    internal class Amigo : Pessoa
    {
        //Variaveis
        public Responsavel Responsavel { get; set; }
        public Multa Multa { get; set; }
        public List<Revista> revistas_Pegas { get; set; }

        //Contrutor
        public Amigo(string nome,string fone,Responsavel responsavel,Multa multa) {
            this.Nome = nome;
            this.Telefone = fone;
            this.Responsavel = responsavel;
            this.Multa = multa;
            this.revistas_Pegas = new List<Revista>();
        }

        //metados

        //responsavel por fazer a edição do objeto ja criado
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
           Amigo novo = (Amigo)novoegistro;
            
            this.Nome = novo.Nome;
            this.Telefone = novo.Telefone;
            this.Responsavel = novo.Responsavel;
            this.Multa = novo.Multa;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");



            return erros;
        }
    }
}
