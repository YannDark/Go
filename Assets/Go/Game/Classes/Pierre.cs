using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pierre{
	private int libertes;
	private coordonnees coord;
	private List<coordonnees> listCoordAdjacente;
	public etat etat;
	private couleur couleur;
	public GameObject objetGraphique;
	
	public Pierre()
	{
		libertes = 0;
		coord.x = 0;
		coord.y = 0;
		etat = etat.nonPosee;
		couleur = couleur.Indefinie;
		listCoordAdjacente = new List<coordonnees> ();
	}
	public int getLibertes(){
		return libertes;
	}
	public void setLibertes(int l){
		libertes = l;
	}
	
	public coordonnees getCoord(){
		return coord;
	}
	public void setCoord(coordonnees c){
		coord = c;
	}
	
	public etat getEtat(){
		return etat;
	}
	public void setEtat(etat e){
		etat = e;
	}
	
	public couleur getCouleur(){
		return couleur;
	}
	public void setCouleur(couleur c){
		couleur = c;
	}
	
	public GameObject getObjetGraphique(){
		return objetGraphique;
	}
	public void setObjetGraphique(GameObject o){
		objetGraphique = o;
	}
	
	
	public void poser(Grille g){
		coordonnees coord;
		
		do{
			coord.x = Random.Range (0,9);
			coord.y = Random.Range (0,9);
		}while(g.isTaken(coord.x,coord.y));
		
		setCoord (coord);

		if(getCouleur() == couleur.Noire)
			g.setValue(coord.x,coord.y,couleur.Noire);
		else if(getCouleur() == couleur.Blanche)
			g.setValue(coord.x,coord.y,couleur.Blanche);
		
		objetGraphique.transform.position = new Vector3(coord.x,0.8f,-(coord.y));
	}


	public void setCoordHaut(Grille g){
		coordonnees haut;
		haut.x = this.getCoord ().x;
		haut.y = this.getCoord ().y + 1;

		if (haut.y <= 8 && g.getGrille () [haut.x, haut.y] == getCouleur ())
			listCoordAdjacente.Add (haut);
	}

	public void setCoordBas(Grille g){
		coordonnees bas;
		bas.x = this.getCoord ().x;
		bas.y = this.getCoord ().y - 1;

		if (bas.y >= 0 && g.getGrille () [bas.x, bas.y] == getCouleur ())
			listCoordAdjacente.Add (bas);
	}

	public void setCoordGauche(Grille g){
		coordonnees gauche;
		gauche.x = this.getCoord ().x -1;
		gauche.y = this.getCoord ().y;

		if (gauche.x >= 0 && g.getGrille () [gauche.x, gauche.y] == getCouleur ())
			listCoordAdjacente.Add (gauche);
	}

	public void setCoordDroite(Grille g){
		coordonnees droite;
		droite.x = this.getCoord ().x+1;
		droite.y = this.getCoord ().y ;

		if (droite.x <= 8 && g.getGrille () [droite.x, droite.y] == getCouleur ())
			listCoordAdjacente.Add (droite);

	}

	public List<coordonnees> getListCoordAdjacente(Grille g){
		listCoordAdjacente.Clear ();

		setCoordHaut(g);
		setCoordBas(g);
		setCoordGauche(g);
		setCoordDroite(g);

		return listCoordAdjacente;
	}

}