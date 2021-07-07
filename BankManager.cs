using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banca
{
    class BankManager
    {
        static string path = @"C:\Users\utente\Desktop\Esercizi\Week2\Banca.txt";

        static List<Conto> conti = new List<Conto>();

        public static void CreaConto()
        {
            Console.Write("Inserisci nome e cognome intestatario conto: ");
            string intestatario = Console.ReadLine();
            Console.WriteLine("Che tipo di conto vuoi aprire?\nPremi 1 per aprire un conto corrente\nPremi 2 per aprire un conto risparmio");
            bool IsSuccesful = int.TryParse(Console.ReadLine(), out int choice);
            while(!(IsSuccesful && choice>=1 && choice <= 2))
            {
                IsSuccesful = int.TryParse(Console.ReadLine(), out choice);
            }
            TipologiaConto tipologia = (TipologiaConto)choice;
            Conto conto = new Conto(intestatario,tipologia);
            conti.Add(conto);
        }

        public static void EliminaConto()

        {
            Console.WriteLine("Inserisci il numero del conto che vuoi eliminare:");
            StampaConti();
            int numeroContoDaEliminare = int.Parse(Console.ReadLine());
            Conto contoDaEliminare = new Conto();
            contoDaEliminare = conti.ElementAt(numeroContoDaEliminare - 1);
            conti.Remove(contoDaEliminare);
        }

        public static void FiltraContiPerTipo()
        {
            Console.WriteLine("Scegli il tipo di conto che vuoi vedere:\n1: Conto Corrente\n2: Conto Risparmio");
            bool IsSuccesful = int.TryParse(Console.ReadLine(), out int choice);
            while (!(IsSuccesful && choice >= 1 && choice <= 2))
            {
                IsSuccesful = int.TryParse(Console.ReadLine(), out choice);
            }
            TipologiaConto tipoDaFiltrare = (TipologiaConto)choice;
            List<Conto> contiDaFiltrare = new List<Conto>();
            foreach(Conto conto in conti)
            {
                if(conto.TipoDiConto == tipoDaFiltrare)
                {
                    contiDaFiltrare.Add(conto);
                }
            }
            if (contiDaFiltrare.Count == 0)
            {
                Console.WriteLine($"Non ci sono conti di tipo {tipoDaFiltrare}");
            }
            else
            {
                foreach(Conto conto in contiDaFiltrare)
                {
                    Console.WriteLine($"Intestatario: {conto.Intestatario}\tSaldo: {conto.Saldo}");
                }
            }
        }

        public void PrelevaDaConto()
        {

        }

        public static void StampaConti()
        {
            if (conti.Count > 0)
            {
                int count = 1;
                foreach(Conto conto in conti)
                {
                    count++;
                    Console.WriteLine($"{count} --> Intestatario: {conto.Intestatario}\tSaldo: {conto.Saldo}\tTipo di conto: {conto.TipoDiConto}");
                }
            }
            else
            {
                Console.WriteLine("Nessun conto presente");
            }

            }

        public static void Preleva()
        {
            Console.WriteLine("Inserisci numero del conto da cui vuoi prelevare");
            StampaConti();
            int numeroConto = int.Parse(Console.ReadLine());
            Conto contoPerPrelevare = conti.ElementAt(numeroConto - 1);
            if(contoPerPrelevare.TipoDiConto == TipologiaConto.Risparmio)
            {
                Console.WriteLine("Non puoi prelevare da un conto risparmio!");
            }
            else
            {
                conti.Remove(contoPerPrelevare);
                Console.WriteLine("Quanto vuoi prelevare?");
                double importo = double.Parse(Console.ReadLine());
                if(importo >= contoPerPrelevare.Saldo)
                {
                    contoPerPrelevare.Saldo = contoPerPrelevare.Saldo - importo;
                }
                else
                {
                    Console.WriteLine("L'importo supera la giacenza");
                }
                Console.WriteLine($"Saldo Redisuo: {contoPerPrelevare.Saldo}");
                conti.Add(contoPerPrelevare);
            }
        }

        public static void Versamento()
        {
            Console.WriteLine("Inserisci il numero del conto su cui vuoi versare");
            StampaConti();
            int numeroConto = int.Parse(Console.ReadLine());
            Conto contoPerVersare = conti.ElementAt(numeroConto - 1);
            conti.Remove(contoPerVersare);
            Console.WriteLine("Quanto vuoi versare?");
            double importo = double.Parse(Console.ReadLine());
            contoPerVersare.Saldo = contoPerVersare.Saldo + importo;
            Console.WriteLine($"Nuovo Saldo: {contoPerVersare.Saldo}");

        }

        public static void SalvaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Conto conto in conti)
                {
                    sw.WriteLine($"Intestatario: {conto.Intestatario}\tSaldo: {conto.Saldo}\tTipo di conto: {conto.TipoDiConto}");
                }
            }
        }

        }

    }

