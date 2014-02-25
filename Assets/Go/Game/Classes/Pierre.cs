using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pierre{
	// Fields
	private int idPion;
	private int idGoban;

	private coordonnees coord;
	private List<coordonnees> listCoordAdjacente;
	private List<coordonnees> listLibertes;
	public etat etat;
	private couleur couleur;
	public GameObject objetGraphique;

	// Constructor without arguments.
	public Pierre()
	{
		coord.x = 0;
		coord.y = 0;
		etat = etat.nonPosee;
		couleur = couleur.Indefinie;
		listCoordAdjacente = new List<coordonnees> ();
		listLibertes = new List<coordonnees> ();
	}

	public int getIdGoban(){
		return idGoban;
	}
	public void setIdGoban(int id){
		idGoban = id;
	}

	public List<coordonnees> getListLibertes(){
		return listLibertes;
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
		
		getListCoordAdjacente (g);
	}
	
	
	public void setCoordHaut(Grille g){
		coordonnees haut;
		haut.x = this.getCoord ().x;
		haut.y = this.getCoord ().y - 1;
		
		if (haut.y >= 0) {
			listCoordAdjacente.Add (haut);
			//Debug.Log("haut :" + g.getGrille()[haut.x,haut.y].ToString());
			if (g.getGrille () [haut.x, haut.y] == couleur.Indefinie)
				listLibertes.Add (haut);
		}
	}
	
	public void setCoordBas(Grille g){
		coordonnees bas;
		bas.x = this.getCoord ().x;
		bas.y = this.getCoord ().y + 1;
		
		if (bas.y <= 8) {
			listCoordAdjacente.Add (bas);
			//Debug.Log("bas :" + g.getGrille()[bas.x,bas.y].ToString());
			if(g.getGrille()[bas.x,bas.y] == couleur.Indefinie)
				listLibertes.Add (bas);
		}
		
	}
	
	public void setCoordGauche(Grille g){
		coordonnees gauche;
		gauche.x = this.getCoord ().x -1;
		gauche.y = this.getCoord ().y;
		
		if (gauche.x >= 0) {
			listCoordAdjacente.Add (gauche);
			//Debug.Log("gauche :" + g.getGrille()[gauche.x,gauche.y].ToString());
			if(g.getGrille()[gauche.x,gauche.y] == couleur.Indefinie)
				listLibertes.Add (gauche);
		}
	}
	
	public void setCoordDroite(Grille g){
		coordonnees droite;
		droite.x = this.getCoord ().x+1;
		droite.y = this.getCoord ().y ;
		
		if (droite.x <= 8) {
			listCoordAdjacente.Add (droite);
			//Debug.Log("droite :" + g.getGrille()[droite.x,droite.y].ToString());
			if(g.getGrille()[droite.x,droite.y] == couleur.Indefinie)
				listLibertes.Add (droite);
			
		}
		
	}
	
	public List<coordonnees> getListCoordAdjacente(Grille g){
		listCoordAdjacente.Clear ();
		listLibertes.Clear ();
		
		setCoordHaut(g);
		setCoordBas(g);
		setCoordGauche(g);
		setCoordDroite(g);
		
		
		return listCoordAdjacente;
	}
	
	public int getNbCoordAdjacenteMemeCouleur(Grille g){
		int cpt = 0;
		
		List<coordonnees> liste = getListCoordAdjacente(g);
		foreach(coordonnees c in liste)
		{
			if(g.getGrille()[c.x,c.y] == getCouleur())
			{
				cpt++;
			}
		}
		return cpt;
	}
	
	public void remove(){
		objetGraphique.SetActive (false);
	}
	

	
}