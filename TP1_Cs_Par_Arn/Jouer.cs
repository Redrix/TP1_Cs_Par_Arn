using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal class Jouer
    {
        static void Main(String[] args)
        {
            Affichage affichage = new Affichage();

            bool rejouer = false;

            affichage.Message("Bienvenu ! Veuillez choisir un jeu : \n1. Morpion\n2. Puissance 4");
            switch (Entree.GetUserIntInput(2))
            {
                case 1:
                    do
                    {
                        JeuMorpion jeu = new JeuMorpion(2);
                        jeu.jouer();
                        affichage.Message("Voulez vous jouer une autre partie de Morpion ? [o/n]");
                        if (Entree.GetUserStringInput() == "o")
                        {
                            rejouer = true;
                        }
                        else
                        {
                            rejouer = false;
                        }
                    } while (rejouer);
                    break;

                case 2:
                    do
                    {
                        JeuPuissance4 jeu = new JeuPuissance4(2);
                        jeu.jouer();
                        affichage.Message("Voulez vous jouer une autre partie de Puissance 4 ? [o/n]");
                        if (Entree.GetUserStringInput() == "o")
                        {
                            rejouer = true;
                        }
                        else
                        {
                            rejouer = false;
                        }
                    } while (rejouer);
                    break;

                default:
                    affichage.Message("Une erreur est survenue, fin du programme");
                    break;
            }
        }
    }
}
