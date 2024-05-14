using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modolo_Amigo
{
    internal class Repositorio_Amigo : RepositorioBase<Amigo>
    {
        public List<Amigo> SelecionarAmigosComMulta()
        {
            List<Amigo> amigosComMulta = new List<Amigo>();

            foreach (Amigo a in registros)
            {
                if (a.TemMulta)
                    amigosComMulta.Add(a);
            }

            return amigosComMulta;
        }
    }
}
