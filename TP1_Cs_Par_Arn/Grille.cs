using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal abstract class Grille : IGrille
    {
        protected int[,] grille;
        public static int HAUTEUR_GRILLE;
        public static int LARGEUR_GRILLE;
        public static int NBR_CASES;

        public Grille(int hauteur, int largeur)
        {
            grille = new int[hauteur, largeur];
            HAUTEUR_GRILLE = hauteur;
            LARGEUR_GRILLE = largeur;
            NBR_CASES = grille.Length;
        }

        public abstract void deposerJeton(int joueur, int emplaement);
        public abstract bool ligneComplete(int joueur, int ligne);
        public abstract bool colonneComplete(int joueur, int colonne);
        public abstract bool victoireJoueur(int joueur);

        public void affichage()
        {
            for (int i = 0; i < HAUTEUR_GRILLE; i++)
            {
                for (int y = 0; y < LARGEUR_GRILLE; y++)
                {
                    Console.Write(grille[i, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}