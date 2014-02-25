using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Notre grille de jeu.
/// Permet d'avoir un appercu global de l'etat a un instant t
/// </summary>
public class Grille{
	// Un tableau contenant l'etat de chaque case
	private couleur[,] grille;

	/// <summary>
	/// Initializes a new instance avec toutes les cases a Indefinie
	/// </summary>
	public Grille(){
		grille = new couleur [9, 9];
		for (int i=0; i<9; i++) {
			for(int j=0;j<9;j++){
				grille[i,j]=couleur.Indefinie;
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
		grille [x, z] = value;
	}

	/// <summary>
	/// Détermine si la case est prise ou non.
	/// </summary>
	/// <returns><c>true</c>, if taken was ised, <c>false</c> otherwise.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	public bool isTaken(int x,int z){
		if (grille [x, z] == couleur.Indefinie)
			return false;
		else
			return true;
	}

	/// <summary>
	/// Gets the grille.
	/// </summary>
	/// <returns>The grille.</returns>
	public couleur[,] getGrille(){
		return grille;
	}
	

	public void isEye(){
	}
	
}