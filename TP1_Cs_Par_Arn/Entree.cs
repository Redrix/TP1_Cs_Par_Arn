using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal class Entree
    {
        public static int GetUserIntInput(int limite = 0)
        {
            int choix;
            Affichage affichage = new Affichage();
            while (!int.TryParse(Console.ReadLine(), out choix))
            {
                affichage.Message("Veuillez saisir un nombre");
            }
            if (limite != 0)
            {
                while (choix < 1 || choix > limite)
                {
                    affichage.Message("Veuillez saisir un nombre entre 1 et " + limite);
                    while (!int.TryParse(Console.ReadLine(), out choix))
                    {
                        affichage.Message("Veuillez saisir un nombre");
                    }
                }
            }
            return choix;
        }

        public static string GetUserStringInput()
        {
            return Console.ReadLine();
        }
    }
}
