using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal interface IGrille
    {
        public void deposerJeton(int joueur, int emplacement);

        public bool ligneComplete(int joueur, int ligne);

        public bool colonneComplete(int joueur, int colonne);

        public bool victoireJoueur(int joueur);

        public void affichage();
    }
}