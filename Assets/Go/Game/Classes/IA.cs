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
	public void calcIA(Grille jeu, int profondeur)
	{
		int i;
		int j;
		int varTmp;
		int sizeGo = 9; 
		int maxi = -1;
		int maxj = -1;
		int alpha = NodesIA.MINEVAL;
		int beta = NodesIA.MAXEVAL;
		
		
		//On met en place le joueur courant
		joueurCourant = jeu.getTour();
		
		//Si la profondeurondeur est nulle ou la partie est finie,
		//on ne fait pas le calcul
		if((profondeur != 0) || (!jeu.getFini()))
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
						jeu.jouer(i, j);
						
						//Lancement de l'algorithme d'IA MiniMax
						varTmp = calcMin(jeu, profondeur - 1, alpha, beta);
						
						//Si ce score est plus grand alors c'est une simulation gagnant par rapport à la précédente
						if(alpha < varTmp)
						{
							//On le choisit
							alpha = varTmp;
							maxi = i;
							maxj = j;
						}
						
						//On annule la simulation
						jeu.annulerCoup(i, j);
					}
				}
			}
		}
		
		//On jouera le coup maximal à la fin de la simulation
		jeu.jouer(maxi, maxj);
	}
	
	/* Fonctions pour de calcul du minimum : Beta */
	public int calcMin(Jeu jeu, int profondeur, int alpha, int beta)
	{
		int i;
		int j;
		int varTmp;
		
		//Si on est à la profondeurondeur voulue, on retourne le score
		if(profondeur == 0)
		{
			varTmp = evaluer(jeu);
			return varTmp;
		}
		
		//Si la partie est finie, on retourne le score
		if(jeu.getFini())
		{
			varTmp = evaluer(jeu);
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
					jeu.jouer(i, j);
					
					varTmp = calcMax(jeu, profondeur - 1, alpha, beta);
					
					//On annule le coup
					jeu.annulerCoup(i, j);
					
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
	public int calcMax(Jeu jeu, int profondeur, int alpha, int beta)
	{
		int i;
		int j;
		int varTmp;

		//Si on est à la profondeurondeur voulue, on retourne le score
		if(profondeur == 0)
		{
			varTmp = evaluer(jeu);
			return varTmp;
		}

		//Si la partie est finie, on retourne le score
		if(jeu.getFini())
		{
			varTmp = evaluer(jeu);
			return varTmp;
		}
		
		for(i = 0; i < 3; i++)
		{
			for(j = 0; j < 3;j++)
			{
				if(jeu.estVide(i, j))
				{
					jeu.jouer(i, j);
					
					varTmp = calcMin(jeu, profondeur - 1, alpha, beta);
					
					jeu.annulerCoup(i, j);
					
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
	public int evaluer(jeu jeu)
	{
		int score = 0;
		
		int cntjoueur;
		int cntpion;
		int i;
		int j;
		
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



