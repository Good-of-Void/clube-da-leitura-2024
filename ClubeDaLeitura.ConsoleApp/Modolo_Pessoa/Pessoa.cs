using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modolo_Amigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Pessoa
{
    internal class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }


        //Responsavel por atualizar o registro       
        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {                
            Pessoa novo = (Pessoa)novoegistro;

            this.Nome = novo.Nome;
            this.Telefone = novo.Telefone;        
        
        }
        //Responsável por validar os dados informados pelo usuário
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório"); 

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"Telefone\" é obrigatório");

            return erros;
        }
    }
}
