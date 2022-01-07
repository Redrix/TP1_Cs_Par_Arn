using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal class JeuMorpion: Jeu
    {
        protected GrilleDeMorpion grille = new GrilleDeMorpion(3, 3);
        public JeuMorpion(int nbrJoueurs) : base(nbrJoueurs)
        {
            
        }
        public override void jouer()
        {
            int tour = 0;
            while (!victoire() && tour < grille.NBR_CASES)
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Joueur " + joueurs[tour % joueurs.Count].numero + " : Veuillez saisir une case");
                int emplacement = Entree.GetUserIntInput(grille.NBR_CASES);

                while (!grille.caseVide(emplacement))
                {
                    affichage.Message("Veuillez choisir une case non utilisée");
                    emplacement = Entree.GetUserIntInput(grille.NBR_CASES);
                }

                grille.deposerJeton(joueurs[tour % joueurs.Count].numero, emplacement);
                tour++;

            }


        }

        public bool victoire()
        {
            foreach (Joueur joueur in joueurs)
            {
                for (int i = 0; i < grille.LARGEUR_GRILLE; i++)
                {
                    if (grille.ligneComplete(joueur.numero, i))
                    {
                        affichage.AffichageGrilleConsole(grille);
                        affichage.Message("Le joueur " + joueur.numero + " a gagné ! ");
                        return true;
                    }
                }
                for (int i = 0; i < grille.HAUTEUR_GRILLE; i++)
                {
                    if (grille.colonneComplete(joueur.numero, i))
                    {
                        affichage.AffichageGrilleConsole(grille);
                        affichage.Message("Le joueur " + joueur.numero + " a gagné ! ");
                        return true;
                    }
                }
                if (grille.diagonaleComplete(joueur.numero, 1) || grille.diagonaleComplete(joueur.numero, 2))
                {
                    affichage.AffichageGrilleConsole(grille);
                    affichage.Message("Le joueur " + joueur.numero + " a gagné ! ");
                    return true;
                }
            }
            return false;
        }
    }
}
