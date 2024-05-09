using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Multa
{
    internal class Multa : EntidadeBase
    {
        //variaveis
        public decimal Valor_Multa { get; set; }
        public DateTime Data_Abertura { get; set; }
        //construtor
        public Multa (decimal valor_Multa, DateTime data_Abertura)
        {
            this.Valor_Multa = valor_Multa;
            this.Data_Abertura = data_Abertura;
        }
        //caso precise atualizar a multa, porém vai automática
        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Multa novo = (Multa)novoregistro;

            this.Valor_Multa = novo.Valor_Multa;          
            this.Data_Abertura = novo.Data_Abertura;
        }
        //não precisa validar pois vai como regra de negócio
        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
