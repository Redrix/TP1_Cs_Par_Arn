using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal abstract class Grille
    {
        protected int[,] grille;
        public readonly int HAUTEUR_GRILLE;
        public readonly int LARGEUR_GRILLE;
        public readonly int NBR_CASES;

        public Grille(int hauteur, int largeur)
        {
            grille = new int[hauteur, largeur];
            HAUTEUR_GRILLE = hauteur;
            LARGEUR_GRILLE = largeur;
            NBR_CASES = grille.Length;
        }

        public int[,] GetGrille()
        {
            return grille;
        }
    }
}