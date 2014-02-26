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

	/// <summary>
	/// Gets the grille inflences.
	/// </summary>
	/// <returns>The grille inflences.</returns>
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

		// on alimente la grille en vérifiant a chaque fois qu'on ne sorte pas du tableau
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

	/// <summary>
	/// On redessine toutes les chaines suite a la pose de la pierre
	/// </summary>
	/// <param name="p">la pierre</param>
	/// <param name="listeChaines">Liste chaines.</param>
	public void recalculerChaines(Pierre p,List<Chaine>listeChaines)
	{
		// on cherche combien de chaines existantes, notre pierre va rejoindre suite a sa pose
		switch(p.getNbCoordAdjacenteMemeCouleur(this)){
		case(1):
			Chaine c11 = new Chaine();
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(this))
				{
					// si on a une correspondance entre les coordonnées adjacente de notre pierre et celles d'une chaine deja existante
					// alors on ajoute la pierre a cette chaine
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur()){
						c.addPierre(p);
						c11 = c;
						break;
					}
				}
			}
			// on recalcule les libertes de la chaine
			c11.recalculLibertesTotal(this);
			break;
		case(2):
			Chaine c21 = new Chaine();		
			Chaine c22 = new Chaine();
			bool stillAdded = false;
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(this))
				{
					// si on a une correspondance entre les coordonnées adjacente de notre pierre et celles d'une chaine deja existante
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur())
					{
						// si c'est la deuxième fois qu'on trouve une correspondance, alors sauvegarde juste la chaine
						if(stillAdded)
						{
							c22 = c;
							break;
						}
						// si on trouve une correspondance pour la première fois
						// on ajoute la pierre a cette chaine et on la sauvegarde
						else
						{
							c.addPierre(p);
							c21 = c;
							stillAdded = true;
							break;
						}
					}
				}
			}
			// on merge la première chaine avec la seconde
			c21.mergeChaine(c22);
			// on supprime la seconde de la liste des chaines
			listeChaines.Remove(c22);
			c22 = null;
			
			// on recalcule les libertes de la chaine nouvellement mergee
			c21.recalculLibertesTotal(this);
			break;
		case(3):
			Chaine c31 = new Chaine();		
			Chaine c32 = new Chaine();
			Chaine c33 = new Chaine();		
			int chaineMergees = 0;
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(this))
				{
					// si on a une correspondance entre les coordonnées adjacente de notre pierre et celles d'une chaine deja existante
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur())
					{
						// si c'est la troisième fois qu'on trouve une correspondance, alors sauvegarde juste la chaine
						if(chaineMergees==2)
						{
							c33 = c;
							break;
						}
						// si c'est la deuxième fois qu'on trouve une correspondance, alors sauvegarde juste la chaine
						else if(chaineMergees==1){
							c32 = c;
							chaineMergees++;
							break;
						}
						// si on trouve une correspondance pour la première fois
						// on ajoute la pierre a cette chaine et on la sauvegarde
						else
						{
							c.addPierre(p);
							c31 = c;
							chaineMergees++;
							break;
						}
					}
				}
			}
			// on merge la première chaine avec la seconde
			c31.mergeChaine(c32);
			// on merge la première chaine avec la troisieme
			c31.mergeChaine(c33);
			// on supprime la seconde de la liste des chaines
			listeChaines.Remove(c32);
			c32 = null;
			// on supprime la troisième de la liste des chaines
			listeChaines.Remove(c33);
			c33 = null;
			// on recalcule les libertes de la chaine nouvellement mergee
			c31.recalculLibertesTotal(this);
			break;
		case(4):
			Chaine c41 = new Chaine();		
			Chaine c42 = new Chaine();
			Chaine c43 = new Chaine();
			Chaine c44 = new Chaine();
			int chaineMergees4 = 0;
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(this))
				{
					// si on a une correspondance entre les coordonnées adjacente de notre pierre et celles d'une chaine deja existante
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur())
					{
						// si c'est la quatrième fois qu'on trouve une correspondance, alors sauvegarde juste la chaine
						if(chaineMergees4==3)
						{
							c44 = c;
							
							break;
						}
						// si c'est la troisième fois qu'on trouve une correspondance, alors sauvegarde juste la chaine
						else if(chaineMergees4==2){
							c43 = c;
							chaineMergees4++;
							break;
						}
						// si c'est la deuxième fois qu'on trouve une correspondance, alors sauvegarde juste la chaine
						else if(chaineMergees4==1){
							c42 = c;
							chaineMergees4++;
							break;
						}
						// si on trouve une correspondance pour la première fois
						// on ajoute la pierre a cette chaine et on la sauvegarde
						else
						{
							c.addPierre(p);
							c41 = c;
							chaineMergees4++;
							break;
						}
					}
				}
			}
			// on merge la première chaine avec la seconde
			c41.mergeChaine(c42);
			// on supprime la seconde de la liste des chaines
			listeChaines.Remove(c42);
			c42 = null;
			// on merge la première chaine avec la troisième
			c41.mergeChaine(c43);
			// on supprime la troisieme de la liste des chaines
			listeChaines.Remove(c43);
			c43 = null;
			// on merge la première chaine avec la quatrieme
			c41.mergeChaine(c44);
			// on supprime la quatrieme de la liste des chaines
			listeChaines.Remove(c44);
			c44 = null;
			c41.recalculLibertesTotal(this);
			break;
		default:
			// si notre pierre ne rejoint aucune chaine
			// alors on crée une nouvelle chaine contenue seulement de cette pierre
			Chaine c5 = new Chaine();
			// on ajoute la pierre a la chaine
			c5.addPierre(p);
			// on ajoute la chaine a la liste des chaines
			listeChaines.Add(c5);
			// on recalcule les libertes de la chaine nouvellement cree
			c5.recalculLibertesTotal(this);
			break;
			
		}
		
	}

	public void faitLeMenage(List<Chaine>listeChaines){
		Chaine chaineADelete = new Chaine();
		
		foreach(Chaine c in listeChaines)
		{
			if (c.isTaken()){
				foreach(coordonnees coord in c.getListCoord())
				{
					if (c.getCouleur() == couleur.Noire)
						this.getGrille()[coord.x,coord.y] = couleur.PriseBlanche;
					else
						this.getGrille()[coord.x,coord.y] = couleur.PriseNoire;
				}	
				chaineADelete = c ;
				Debug.Log ("DEGAGE !!!!");
				break;
				
			}
		}
		chaineADelete.remove ();
		listeChaines.Remove(chaineADelete);
	}

	
}