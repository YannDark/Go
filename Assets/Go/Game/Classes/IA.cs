using System;

public static class NodesIA
{
	public const int MINEVAL = -100000;
	public const int MAXEVAL = 100000;
}

//////////////////////////////////////////////
//	Classe de l'intelligence artificielle	//
//////////////////////////////////////////////

public class IA
{
	private Joueur joueurCourant;
	private int evaluer_cnt;
	
	public IA()
	{
	}
	public void Dispose()
	{
	}
	
	/* Fonction qui calcule le prochain coup / La profondeur représente le niveau de difficulté */
	public void calcIA(Grille grille, Pierre pierre, Goban goban, etatPartie etatPartie, int profondeur)
	{
		int i;
		int j;
		int varTmp;
		int sizeGo = 9; 
		int maxi = -1;
		int maxj = -1;
		int alpha = NodesIA.MINEVAL;
		int beta = NodesIA.MAXEVAL;

		//Mettre le compteur à zéro
		evaluer_cnt = 0;
		
		//On met en place le joueur courant
		joueurCourant = goban.getJoueurEnCours();
		
		//Si la profondeurondeur est nulle ou la partie est finie,
		//on ne fait pas le calcul
		if((profondeur != 0) || ((etatPartie != etatPartie.Termine)))
		{
			//On parcourt les points du go
			for(i = 0; i < sizeGo; i++)
			{
				for(j = 0; j < sizeGo;j++)
				{
					//Si la case est vide
					if(grille.isTaken(i, j))
					{
						//On simule qu'on joue cette case
						pierre.simuler(i, j);
						
						//Lancement de l'algorithme d'IA MiniMax
						varTmp = calcMin(grille, pierre, profondeur - 1, alpha, beta);
						
						//Si ce score est plus grand alors c'est une simulation gagnant par rapport à la précédente
						if(alpha < varTmp)
						{
							//On le choisit
							alpha = varTmp;
							maxi = i;
							maxj = j;
						}
						
						//On annule la simulation
						pierre.annulerSimulation(i, j);
					}
				}
			}
		}
		
		//On jouera le coup maximal à la fin de la simulation
		pierre.poser(maxi, maxj);
	}
	
	/* Fonctions pour de calcul du minimum : Beta */
	public int calcMin(Grille grille, Pierre pierre, int profondeur, int alpha, int beta)
	{
		int i;
		int j;
		int varTmp;
		
		//Si on est à la profondeurondeur voulue, on retourne le score
		if(profondeur == 0)
		{
			varTmp = evaluer(pierre);
			return varTmp;
		}
		
		//Si la partie est finie, on retourne le score
		if(etatPartie == etatPartie.Termine)
		{
			varTmp = evaluer(pierre);
			return varTmp;
		}
		
		//On parcourt le plateau de jeu et on le joue si la case est vide
		for(i = 0; i < 3; i++)
		{
			for(j = 0; j < 3; j++)
			{
				if(grille.isTaken(i, j))
				{
					//On joue le coup
					pierre.simuler(i, j);
					
					varTmp = calcMax(grille, pierre, profondeur - 1, alpha, beta);
					
					//On annule le coup
					pierre.annulerSimulation(i, j);
					
					//Mis a jour de beta
					if(beta > varTmp)
					{
						beta = varTmp;
					}
					
					if(beta <= alpha)
					{
						return beta;
					}
				}
			}
		}
		
		return beta;
	}
	
	/* Fonctions pour de calcul du maximum : Alpha */
	public int calcMax(Grille grille, Pierre pierre, int profondeur, int alpha, int beta)
	{
		int i;
		int j;
		int varTmp;

		//Si on est à la profondeurondeur voulue, on retourne le score
		if(profondeur == 0)
		{
			varTmp = evaluer(pierre);
			return varTmp;
		}

		//Si la partie est finie, on retourne le score
		if(etatPartie == etatPartie.Termine)
		{
			varTmp = evaluer(pierre);
			return varTmp;
		}
		
		for(i = 0; i < 3; i++)
		{
			for(j = 0; j < 3; j++)
			{
				if(grille.isTaken(i, j))
				{
					pierre.simuler(i, j);
					
					varTmp = calcMin(grille, pierre, profondeur - 1, alpha, beta);
					
					pierre.annulerSimulation(i, j);
					
					//Mis a jour de la valeur de alpha
					if(alpha < varTmp)
					{
						alpha = varTmp;
					}
					
					if(beta <= alpha)
					{
						return alpha;
					}
				}
			}
		}
		return alpha;
	}
	
	/* Retourne l'état de la partie et le score */
	public int evaluer(Pierre pierre)
	{
		int score = 0;
		
		int cntjoueur;
		int cntpion;
		int i;
		int j;

		// Incrementer le compteur d'evaluation
		evaluer_cnt++;
		
		//Si le jeu est fini
		if(jeu.getFini())
		{
			//Le joueur en cours a gagné, on retourne 1000 - le nombre de pions
			if(joueur1.gagne() == joueurCourant)
			{
				return 1000 - comptePions(jeu);
			}
			else
			{
				// Le joueur opposé a gagné, on retourne -1000 + le nombre de pions
				return -1000 + comptePions(jeu);
			}
		}
		
		// Compteur de points des points
		
		return score;
	}
}



