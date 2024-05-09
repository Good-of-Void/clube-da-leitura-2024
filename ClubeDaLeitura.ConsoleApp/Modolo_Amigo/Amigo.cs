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
        public Revista revista_Pega { get; set; }

        //Contrutor
        public Amigo(string nome,string fone,Responsavel responsavel) {
            this.Nome = nome;
            this.Telefone = fone;
            this.Responsavel = responsavel;
            this.Multa = null;
            this.revista_Pega = null;
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
    }
}
