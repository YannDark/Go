using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Notre grille de jeu.
/// Permet d'avoir un appercu global de l'etat a un instant t
/// </summary>
public class Grille{
	// Un tableau contenant l'etat de chaque case
	private couleur[,] grilleCouleur;

	// Un tableau contenant l'influence de chaque coord
	private influences[,] grilleInfluences;

	/// <summary>
	/// Initializes a new instance avec toutes les cases a Indefinie et les influences a 0
	/// </summary>
	public Grille(){
		grilleCouleur = new couleur [9, 9];
		grilleInfluences = new influences[9, 9];
		for (int i=0; i<9; i++) {
			for(int j=0;j<9;j++){
				grilleCouleur[i,j] = couleur.Indefinie;
				grilleInfluences[i,j].influenceNoire = 0;
				grilleInfluences[i,j].influenceBlanche = 0;
			}
		}
	}

	/// <summary>
	/// Sets the value.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	/// <param name="value">Value.</param>
	public void setValue(int x,int z,couleur value)	
	{
		grilleCouleur [x, z] = value;
		majInfluences ();

	}

	/// <summary>
	/// Détermine si la case est prise ou non.
	/// </summary>
	/// <returns><c>true</c>, if taken was ised, <c>false</c> otherwise.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	public bool isTaken(int x,int z){
		if (grilleCouleur [x, z] == couleur.Indefinie)
			return false;
		else
			return true;
	}

	/// <summary>
	/// Gets the grille.
	/// </summary>
	/// <returns>The grille.</returns>
	public couleur[,] getGrille(){
		return grilleCouleur;
	}

	public influences[,] getGrilleInflences(){
		return grilleInfluences;
	}

	/// <summary>
	/// Majs the influences.
	///     0.5 1 0.5   
	/// 0.5  2  3  2  0.5
	///  1   3  10 3   1
	/// 0.5  2  3  2  0.5
	///     0.5 1 0.5
	/// </summary>
	public void majInfluences()
	{
		// on réinit la grille
		for (int i=0; i<9; i++) {
			for(int j=0;j<9;j++){
				grilleInfluences[i,j].influenceNoire = 0;
				grilleInfluences[i,j].influenceBlanche = 0;
			}
		}

		// on alimente la grille
		for (int i=0; i<9; i++) 
		{
			for (int j=0; j<9; j++) 
			{
				if(grilleCouleur [i, j] == couleur.Noire)
				{

					if((i-1>=0)&&(j-2>=0))
						grilleInfluences[i-1,j-2].influenceNoire += 0.5f;
					if(j-2>=0)
						grilleInfluences[i,j-2].influenceNoire += 1;
					if((i+1<=8)&&(j-2>=0))
						grilleInfluences[i+1,j-2].influenceNoire += 0.5f;

					if((i-2>=0)&&(j-1>=0))
						grilleInfluences[i-2,j-1].influenceNoire += 0.5f;
					if((i-1>=0)&&(j-1>=0))
						grilleInfluences[i-1,j-1].influenceNoire += 2;
					if(j-1>=0)
						grilleInfluences[i,j-1].influenceNoire += 3;
					if((i+1<=8)&&(j-1>=0))
						grilleInfluences[i+1,j-1].influenceNoire += 2;
					if((i+2<=8)&&(j-1>=0))
						grilleInfluences[i+2,j-1].influenceNoire += 0.5f;

					if(i-2>=0)
						grilleInfluences[i-2,j].influenceNoire += 1;
					if(i-1>=0)
						grilleInfluences[i-1,j].influenceNoire += 3;

					grilleInfluences[i,j].influenceNoire += 10;

					if(i+1<=8)
						grilleInfluences[i+1,j].influenceNoire += 3;
					if(i+2<=8)
						grilleInfluences[i+2,j].influenceNoire += 1;

					if((i-2>=0)&&(j+1<=8))
						grilleInfluences[i-2,j+1].influenceNoire += 0.5f;
					if((i-1>=0)&&(j+1<=8))
						grilleInfluences[i-1,j+1].influenceNoire += 2;
					if(j+1<=8)
						grilleInfluences[i,j+1].influenceNoire += 3;
					if((i+1<=8)&&(j+1<=8))
						grilleInfluences[i+1,j+1].influenceNoire += 2;
					if((i+2<=8)&&(j+1<=8))
						grilleInfluences[i+2,j+1].influenceNoire += 0.5f;

					if((i-1>=0)&&(j+2<=8))
						grilleInfluences[i-1,j+2].influenceNoire += 0.5f;
					if(j+2<=8)
						grilleInfluences[i,j+2].influenceNoire += 1;
					if((i+1<=8)&&(j+2<=8))
						grilleInfluences[i+1,j+2].influenceNoire += 0.5f;

				}
				else if(grilleCouleur [i, j] == couleur.Blanche)
				{
					
					if((i-1>=0)&&(j-2>=0))
						grilleInfluences[i-1,j-2].influenceBlanche += 0.5f;
					if(j-2>=0)
						grilleInfluences[i,j-2].influenceBlanche += 1;
					if((i+1<=8)&&(j-2>=0))
						grilleInfluences[i+1,j-2].influenceBlanche += 0.5f;
					
					if((i-2>=0)&&(j-1>=0))
						grilleInfluences[i-2,j-1].influenceBlanche += 0.5f;
					if((i-1>=0)&&(j-1>=0))
						grilleInfluences[i-1,j-1].influenceBlanche += 2;
					if(j-1>=0)
						grilleInfluences[i,j-1].influenceBlanche += 3;
					if((i+1<=8)&&(j-1>=0))
						grilleInfluences[i+1,j-1].influenceBlanche += 2;
					if((i+2<=8)&&(j-1>=0))
						grilleInfluences[i+2,j-1].influenceBlanche += 0.5f;
					
					if(i-2>=0)
						grilleInfluences[i-2,j].influenceBlanche += 1;
					if(i-1>=0)
						grilleInfluences[i-1,j].influenceBlanche += 3;
					
					grilleInfluences[i,j].influenceBlanche += 10;
					
					if(i+1<=8)
						grilleInfluences[i+1,j].influenceBlanche += 3;
					if(i+2<=8)
						grilleInfluences[i+2,j].influenceBlanche += 1;
					
					if((i-2>=0)&&(j+1<=8))
						grilleInfluences[i-2,j+1].influenceBlanche += 0.5f;
					if((i-1>=0)&&(j+1<=8))
						grilleInfluences[i-1,j+1].influenceBlanche += 2;
					if(j+1<=8)
						grilleInfluences[i,j+1].influenceBlanche += 3;
					if((i+1<=8)&&(j+1<=8))
						grilleInfluences[i+1,j+1].influenceBlanche += 2;
					if((i+2<=8)&&(j+1<=8))
						grilleInfluences[i+2,j+1].influenceBlanche += 0.5f;
					
					if((i-1>=0)&&(j+2<=8))
						grilleInfluences[i-1,j+2].influenceBlanche += 0.5f;
					if(j+2<=8)
						grilleInfluences[i,j+2].influenceBlanche += 1;
					if((i+1<=8)&&(j+2<=8))
						grilleInfluences[i+1,j+2].influenceBlanche += 0.5f;
					
				}

			}
		}
	}
	

	public void isEye(){
	}
	
}