using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal class Affichage
    {
        public void AffichageGrilleConsole(Grille grille)
        {
            for (int i = 0; i < Grille.HAUTEUR_GRILLE; i++)
            {
                for (int y = 0; y < Grille.LARGEUR_GRILLE; y++)
                {
                    Console.Write(grille.Getgrille()[i, y] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Message(String message)
        {
            Console.WriteLine(message);
        }
    }
}
