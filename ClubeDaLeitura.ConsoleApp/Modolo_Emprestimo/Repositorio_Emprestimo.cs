using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Emprestimo
{
    internal class Repositorio_Emprestimo : RepositorioBase
    {
        public void AplicarMulta(Emprestimo emprestimo)
        {
            DateTime dataLimite = emprestimo.Retirada.AddDays(emprestimo.Revista.Caixa.Dias_Max);
            if (dataLimite < emprestimo.Devolucao)
            {
                emprestimo.Amigo.Multa += 10;
                TimeSpan diferenca = emprestimo.Devolucao.Subtract(dataLimite);
                int dias = diferenca.Days;

                for (int i = 0; i < dias; i++)
                {
                    emprestimo.Amigo.Multa += 2;
                }
            }
        }
    }
}
