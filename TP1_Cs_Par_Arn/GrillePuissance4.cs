using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class GrillePuissance4 : Grille
    {
        public GrillePuissance4(int hauteur, int largeur) : base(hauteur, largeur)
        {
        }

        public bool colonneValide(int colonne)
        {
            colonne = colonne - 1;
            if (grille[0, colonne] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        override public void deposerJeton(int joueur, int colonne)
        {
            colonne = colonne - 1;
            for (int i = 0; i < HAUTEUR_GRILLE; i++)
            {
                if (grille[i, colonne] == 0)
                {
                    if (i + 1 < HAUTEUR_GRILLE)
                    {
                        if (grille[i + 1, colonne] != 0)
                        {
                            grille[i, colonne] = joueur;
                        }
                    }
                }
            }
            if (grille[HAUTEUR_GRILLE - 1, colonne] == 0)
            {
                grille[HAUTEUR_GRILLE - 1, colonne] = joueur;
            }
        }

        override public bool ligneComplete(int joueur, int ligne)
        {
            int compteur = 0;
            for (int i = 0; i < LARGEUR_GRILLE; i++)
            {
                if (grille[ligne, i] == joueur)
                {
                    compteur++;
                }
                else
                {
                    compteur = 0;
                }
                if (compteur == 4)
                {
                    return true;
                }
            }
            return false;
        }

        override public bool colonneComplete(int joueur, int colonne)
        {
            int compteur = 0;
            for (int i = 0; i < HAUTEUR_GRILLE; i++)
            {
                if (grille[i, colonne] == joueur)
                {
                    compteur++;
                }
                else
                {
                    compteur = 0;
                }
                if (compteur == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool diagonalComplete(int joueur)
        {
            for (int i = 0; i < NBR_CASES; i++)
            {
                int ligne = i / LARGEUR_GRILLE;
                int colonne = i % LARGEUR_GRILLE;
                int compteur1 = 0;
                int compteur2 = 0;
                if (grille[ligne, colonne] == joueur)
                {
                    compteur1++;
                    compteur2++;
                }
                for (int j = 1; j <= 4; j++)
                {
                    if (ligne + j < HAUTEUR_GRILLE && colonne + j < LARGEUR_GRILLE)
                    {
                        if (grille[ligne + j, colonne + j] == joueur)
                        {
                            compteur1++;
                        }
                    }
                    if (ligne - j >= 0 && colonne + j < LARGEUR_GRILLE)
                    {
                        if (grille[ligne - j, colonne + j] == joueur)
                        {
                            compteur2++;
                        }
                    }
                }
                if (compteur1 == 4 || compteur2 == 4)
                {
                    return true;
                }
                compteur1 = 0;
                compteur2 = 0;
            }
            return false;
        }

        override public bool victoireJoueur(int joueur)
        {
            for (int i = 0; i < HAUTEUR_GRILLE; i++)
            {
                if (ligneComplete(joueur, i))
                {
                    return true;
                }
            }
            for (int i = 0; i < LARGEUR_GRILLE; i++)
            {
                if (colonneComplete(joueur, i))
                {
                    return true;
                }
            }
            if (diagonalComplete(joueur))
            {
                return true;
            }
            return false;
        }
    }
}