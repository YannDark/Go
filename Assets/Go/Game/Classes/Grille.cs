using System.Collections;
using System.Collections.Generic;

public class Grille{
	private couleur[,] grille;
	
	public Grille(){
		grille = new couleur [9, 9];
		for (int i=0; i<9; i++) {
			for(int j=0;j<9;j++){
				grille[i,j]=couleur.Indefinie;
			}
		}
	}
	
	public void setValue(int x,int z,couleur value)
	{
		grille [x, z] = value;
	}
	
	public bool isTaken(int x,int z){
		if (grille [x, z] == couleur.Blanche)
			return true;
		else if (grille [x, z] == couleur.Noire)
			return true;
		else
			return false;
	}

	public couleur[,] getGrille(){
		return grille;
	}
	

	public void isEye(){
	}
	
}