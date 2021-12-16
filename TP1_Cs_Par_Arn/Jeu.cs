using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal class Jeu
    {
        static void Main(String[] args)
        {
            Jeu partie = new Jeu();
            Affichage affichage = new Affichage();
            bool rejouer = false;
            affichage.Message("Bienvenu ! Veuillez choisir un jeu : \n1. Morpion\n2. Puissance 4");
            switch (Entree.GetUserIntInput(2))
            {
                case 1:
                    do
                    {
                        partie.jouerMorpion();
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
                        partie.jouerPuissance4();
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


        // -------------------------------------------------Morpion--------------------------------------------------
        public void jouerMorpion()
        {
            GrilleDeMorpion grille = new GrilleDeMorpion(3, 3);
            Affichage affichage = new Affichage();

            int tour = 0;
            int emplacement;

            while (!grille.victoireJoueur(1) && !grille.victoireJoueur(2) && tour < GrilleDeMorpion.NBR_CASES)
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Joueur " + ((tour % 2) + 1) + " : Veuillez saisir une case");
                emplacement = Entree.GetUserIntInput(GrilleDeMorpion.NBR_CASES);

                while (!grille.caseVide(emplacement))
                {
                    affichage.Message("Veuillez choisir une case non utilisée");
                    emplacement = Entree.GetUserIntInput(GrilleDeMorpion.NBR_CASES);
                }

                grille.deposerJeton((tour % 2) + 1, emplacement);
                tour++;

            }

            if (grille.victoireJoueur(1))
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Le joueur 1 a gagné");
            }
            else if (grille.victoireJoueur(2))
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Le joueur 2 a gagné");
            }
            else
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Match nul");
            }

        }


        // ------------------------------------------------Puissance4--------------------------------------------
        public void jouerPuissance4()
        {
            GrillePuissance4 grille = new GrillePuissance4(4, 7);
            Affichage affichage = new Affichage();
            int tour = 0;
            int emplacement;
            while (!grille.victoireJoueur(1) && !grille.victoireJoueur(2) && tour < GrillePuissance4.NBR_CASES)
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Joueur " + ((tour % 2) + 1) + " : Veuillez saisir une colonne");
                emplacement = Entree.GetUserIntInput(GrillePuissance4.LARGEUR_GRILLE);
                while (!grille.colonneValide(emplacement))
                {
                    affichage.Message("Veuillez choisir un colonne non remplie");
                    while (!int.TryParse(Console.ReadLine(), out emplacement))
                    {
                        affichage.Message("Veuillez saisir un nombre");
                        emplacement = Entree.GetUserIntInput(GrillePuissance4.LARGEUR_GRILLE);
                    }
                }
                grille.deposerJeton(((tour % 2) + 1), emplacement);
                tour++;

            }

            if (grille.victoireJoueur(1))
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Le joueur 1 a gagné");
            }
            else if (grille.victoireJoueur(2))
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Le joueur 2 a gagné");
            }
            else
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Match nul");
            }
        }
    }
}