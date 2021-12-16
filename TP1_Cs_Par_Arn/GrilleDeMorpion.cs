using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal class GrilleDeMorpion : Grille
    {
        public GrilleDeMorpion(int hauteur, int largeur) : base(hauteur, largeur)
        {
        }

        public bool caseVide(int emplacement)
        {
            emplacement = emplacement - 1;
            if (grille[emplacement / LARGEUR_GRILLE, emplacement % LARGEUR_GRILLE] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void deposerJeton(int joueur, int numeroCase)
        {
            numeroCase = numeroCase - 1;
            grille[numeroCase / LARGEUR_GRILLE, numeroCase % LARGEUR_GRILLE] = joueur;
        }

        public bool ligneComplete(int joueur, int ligne)
        {
            for (int i = 0; i < LARGEUR_GRILLE; i++)
            {
                if (grille[ligne, i] != joueur)
                {
                    return false;
                }
            }
            return true;
        }

        public bool colonneComplete(int joueur, int colonne)
        {
            for (int i = 0; i < HAUTEUR_GRILLE; i++)
            {
                if (grille[i, colonne] != joueur)
                {
                    return false;
                }
            }
            return true;
        }

        public bool diagonaleComplete(int joueur, int diagonale)
        {
            if (diagonale == 1)
            {
                if ((grille[0, 0] == joueur) && (grille[1, 1] == joueur) && (grille[2, 2] == joueur))
                {
                    return true;
                }
                return false;
            }
            else
            {
                if ((grille[2, 2] == joueur) && (grille[1, 1] == joueur) && (grille[0, 0] == joueur))
                {
                    return true;
                }
                return false;
            }
        }

        public bool victoireJoueur(int joueur)
        {
            for (int i = 0; i < LARGEUR_GRILLE; i++)
            {
                if (ligneComplete(joueur, i))
                {
                    return true;
                }
            }
            for (int i = 0; i < HAUTEUR_GRILLE; i++)
            {
                if (colonneComplete(joueur, i))
                {
                    return true;
                }
            }
            if (diagonaleComplete(joueur, 1) || diagonaleComplete(joueur, 2))
            {
                return true;
            }
            return false;
        }
    }
}