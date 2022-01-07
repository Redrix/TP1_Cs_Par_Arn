using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Cs_Par_Arn
{
    internal class JeuPuissance4 : Jeu
    {
        protected GrillePuissance4 grille = new GrillePuissance4(4, 7);
        public JeuPuissance4(int nbrJoueurs) : base(nbrJoueurs)
        {

        }

        public override void jouer()
        {
            int tour = 0;
            while (!victoire() && tour < grille.NBR_CASES)
            {
                affichage.AffichageGrilleConsole(grille);
                affichage.Message("Joueur " + joueurs[tour % joueurs.Count].numero + " : Veuillez saisir une colonne");
                int emplacement = Entree.GetUserIntInput(grille.LARGEUR_GRILLE);
                while (!grille.colonneValide(emplacement))
                {
                    affichage.Message("Veuillez choisir un colonne non remplie");
                    while (!int.TryParse(Console.ReadLine(), out emplacement))
                    {
                        affichage.Message("Veuillez saisir un nombre");
                        emplacement = Entree.GetUserIntInput(grille.LARGEUR_GRILLE);
                    }
                }
                grille.deposerJeton(joueurs[tour % joueurs.Count].numero, emplacement);
                tour++;

            }
        }

        public bool victoire()
        {
            foreach (Joueur joueur in joueurs)
            {
                for (int i = 0; i < grille.HAUTEUR_GRILLE; i++)
                {
                    if (grille.ligneComplete(joueur.numero, i))
                    {
                        affichage.AffichageGrilleConsole(grille);
                        affichage.Message("Le joueur " + joueur.numero + " a gagné ! ");
                        return true;
                    }
                }
                for (int i = 0; i < grille.LARGEUR_GRILLE; i++)
                {
                    if (grille.colonneComplete(joueur.numero, i))
                    {
                        affichage.AffichageGrilleConsole(grille);
                        affichage.Message("Le joueur " + joueur.numero + " a gagné ! ");
                        return true;
                    }
                }
                if (grille.diagonalComplete(joueur.numero))
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
