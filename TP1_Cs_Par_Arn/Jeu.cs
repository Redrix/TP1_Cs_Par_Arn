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
            int choix;
            affichage.Message("Bienvenu ! Veuillez choisir un jeu : \n1. Morpion\n2. Puissance 4");
            while (!int.TryParse(Console.ReadLine(), out choix))
            {
                affichage.Message("Veuillez saisir un nombre");
            }
            while (choix < 1 || choix > 2)
            {
                affichage.Message("Veuillez saisir un nombre entre 1 et 2");
                while (!int.TryParse(Console.ReadLine(), out choix))
                {
                    affichage.Message("Veuillez saisir un nombre");
                }
            }

            if (choix == 1)
            {
                do
                {
                    partie.jouerMorpion();
                    affichage.Message("Voulez vous jouer une autre partie de Morpion ? [o/n]");
                    if (Console.ReadLine() == "o")
                    {
                        rejouer = true;
                    }
                    else
                    {
                        rejouer = false;
                    }
                } while (rejouer);
            }
            else if (choix == 2)
            {
                do
                {
                    partie.jouerPuissance4();
                   affichage.Message("Voulez vous jouer une autre partie de Puissance 4 ? [o/n]");
                    if (Console.ReadLine() == "o")
                    {
                        rejouer = true;
                    }
                    else
                    {
                        rejouer = false;
                    }
                } while (rejouer);
            }
        }


        // -------------------------------------------------Morpion--------------------------------------------------
        public void jouerMorpion()
        {
            GrilleDeMorpion grille = new GrilleDeMorpion(3, 3);
            Affichage affichage = new Affichage();
            int tour = 0;
            int tourJoueur = 1;
            int emplacement;
            while (!grille.victoireJoueur(1) && !grille.victoireJoueur(2) && tour < GrilleDeMorpion.NBR_CASES)
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Joueur " + tourJoueur + " : Veuillez saisir une case");
                while (!int.TryParse(Console.ReadLine(), out emplacement))
                {
                    affichage.Message("Veuillez saisir un nombre");
                }
                while ((emplacement < 1 || emplacement > GrilleDeMorpion.NBR_CASES) || !grille.caseVide(emplacement))
                {
                    if (emplacement < 1 || emplacement > GrilleDeMorpion.NBR_CASES)
                    {
                        affichage.Message("Veuillez choisir une valeur entre 1 et " + GrilleDeMorpion.NBR_CASES);
                        while (!int.TryParse(Console.ReadLine(), out emplacement))
                        {
                            affichage.Message("Veuillez saisir un nombre");
                        }
                    }
                    else
                    {
                        affichage.Message("Veuillez choisir une case non utilisée");
                        while (!int.TryParse(Console.ReadLine(), out emplacement))
                        {
                            affichage.Message("Veuillez saisir un nombre");
                        }
                    }

                }
                grille.deposerJeton(tourJoueur, emplacement);
                if (tourJoueur == 1)
                {
                    tourJoueur = 2;
                }
                else
                {
                    tourJoueur = 1;
                }

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
            GrillePuissance4 jeu = new GrillePuissance4(4, 7);
            Affichage affichage = new Affichage();
            int tour = 0;
            int tourJoueur = 1;
            int emplacement;
            while (!jeu.victoireJoueur(1) && !jeu.victoireJoueur(2) && tour < GrillePuissance4.NBR_CASES)
            {
                affichage.AffichageGrilleConsole(jeu);
                affichage.Message("Joueur " + tourJoueur + " : Veuillez saisir une colonne");
                while (!int.TryParse(Console.ReadLine(), out emplacement))
                {
                    affichage.Message("Veuillez saisir un nombre");
                }
                while ((emplacement < 1 || emplacement > GrillePuissance4.LARGEUR_GRILLE) || !jeu.colonneValide(emplacement))
                {
                    if (emplacement < 1 || emplacement > GrillePuissance4.LARGEUR_GRILLE)
                    {
                        affichage.Message("Veuillez choisir une valeur entre 1 et " + GrillePuissance4.LARGEUR_GRILLE);
                        while (!int.TryParse(Console.ReadLine(), out emplacement))
                        {
                            affichage.Message("Veuillez saisir un nombre");
                        }
                    }
                    else
                    {
                        affichage.Message("Veuillez choisir un colonne non remplie");
                        while (!int.TryParse(Console.ReadLine(), out emplacement))
                        {
                            affichage.Message("Veuillez saisir un nombre");
                        }
                    }

                }
                jeu.deposerJeton(tourJoueur, emplacement);
                if (tourJoueur == 1)
                {
                    tourJoueur = 2;
                }
                else
                {
                    tourJoueur = 1;
                }

                tour++;

            }

            if (jeu.victoireJoueur(1))
            {
                affichage.AffichageGrilleConsole(jeu);
                affichage.Message("Le joueur 1 a gagné");
            }
            else if (jeu.victoireJoueur(2))
            {
                affichage.AffichageGrilleConsole(jeu);
                affichage.Message("Le joueur 2 a gagné");
            }
            else
            {
                affichage.AffichageGrilleConsole(jeu);
                affichage.Message("Match nul");
            }
        }
    }
}