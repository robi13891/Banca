using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Benvenuto nella Banca!");
            int keepGoing = 1;
            do
            {
                Console.WriteLine("Scegli cosa vuoi fare:");
                Console.WriteLine("1: Creare un conto\n2: Eliminare un conto\n3: Filtrare conti per tipologia\n4: Prelevare\n5: Versare\n");
                bool isSuccessful = int.TryParse(Console.ReadLine(), out int menuIndex);
                while (!(isSuccessful && menuIndex > 0 && menuIndex < 6))
                {
                    Console.WriteLine("Scelta non valida!");
                    isSuccessful = int.TryParse(Console.ReadLine(), out menuIndex);
                }
                switch (menuIndex)
                {
                    case 1:
                        BankManager.CreaConto();
                        break;
                    case 2:
                        BankManager.EliminaConto();
                        break;
                    case 3:
                        BankManager.FiltraContiPerTipo();
                        break;
                    case 4:
                        BankManager.Preleva();
                        break;
                    case 5:
                        BankManager.Versamento();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Premi 1 se vuoi fare altre operazioni, oppure premi 0");
                keepGoing = int.Parse(Console.ReadLine());
                if (keepGoing == 0)
                {
                    BankManager.SalvaSuFile();
                }
            } while (keepGoing == 1);

        }
    }
}
