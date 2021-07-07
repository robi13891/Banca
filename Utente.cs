using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Un utente può:
//Creare un conto, Eliminare un conto

namespace Banca
{
    class Utente
    {
        List<Conto> listaConti = new List<Conto>();
        public void CreaConto()
        {
            Conto conto = new Conto();
            Console.Write("Inserisci intestatario conto: ");
            conto.Intestatario = Console.ReadLine();
            Console.WriteLine("Che tipo di conto vuoi aprire?\nPremi 1 per aprire un conto corrente\nPremi 2 per aprire un conto risparmio");
            bool IsSuccesful = int.TryParse(Console.ReadLine(), out int choice);
            while(!(IsSuccesful && choice>=1 && choice <= 2))
            {
                IsSuccesful = int.TryParse(Console.ReadLine(), out choice);
            }
            conto.TipoDiConto = (TipologiaConto)choice;
            Console.WriteLine("Inserisci l'importo del primo versamento");
            bool isDouble = double.TryParse(Console.ReadLine(), out double saldo);
            while(!(isDouble && saldo > 0))
            {
                isDouble = double.TryParse(Console.ReadLine(), out saldo);
            }
            listaConti.Add(conto);
        }

        public void EliminaConto()
        {
            Conto contoDaEliminare = new Conto();
            contoDaEliminare = CercaConto();
            listaConti.Remove(contoDaEliminare);

        }

        public Conto CercaConto()
        {
            Console.WriteLine("Inserisci il nome dell'intestatario del conto");
            string intestatario = Console.ReadLine();
            foreach (Conto conto in listaConti)
            {
                if (conto.Intestatario == intestatario)
                {
                    return conto;
                }
                else
                {
                    Console.WriteLine($"{intestatario} non trovato");
                    return null;
                }
            }
            return null;
        }

    }
}
