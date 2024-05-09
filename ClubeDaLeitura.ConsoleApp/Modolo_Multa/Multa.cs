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
        public decimal ValorMulta { get; set; }
        public DateTime DataAbertura { get; set; }

        public Multa (decimal valorMulta, DateTime dataAbertura)
        {
            this.ValorMulta = valorMulta;
            this.DataAbertura = dataAbertura;
        }
        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Multa novo = (Multa)novoregistro;

            this.ValorMulta = novo.ValorMulta;          
            this.DataAbertura = novo.DataAbertura;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
