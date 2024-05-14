using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Amigo
{
    internal class Multa
    {
        //variaveis
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public bool Paga { get; set; }

        //construtor
        public Multa(decimal valor) {
            Valor = valor;
            Data = DateTime.Now;
            Paga = false;
        }
        //Metados
        public void Pagar()
        {
            Paga = true;
        }
    }
}
