using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal abstract class Jeu
    {
        protected Affichage affichage;
        protected List<Joueur> joueurs = new List<Joueur>();

        public Jeu(int nbrJoueurs)
        {
            affichage = new Affichage();
            for(int i = 0; i < nbrJoueurs; i++)
            {
                joueurs.Add(new Joueur(i + 1));
            }
        }

        public abstract void jouer();
    }
}