using UnityEngine;

public class Pierre{
	private int libertes;
	private coordonnees coord;
	public etat etat;
	private couleur couleur;
	public GameObject objetGraphique;
	
	public Pierre()
	{
		libertes = 0;
		coord.x = 0;
		coord.y = 0;
		etat = etat.nonPosee;
		couleur = couleur.Noire;
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
			g.setValue(coord.x,coord.y,'N');
		else if(getCouleur() == couleur.Blanche)
			g.setValue(coord.x,coord.y,'B');
		
		objetGraphique.transform.position = new Vector3(coord.x,0.8f,-(coord.y));
	}
	
	public bool isChaineAdjacente(Chaine c)
	{
		coordonnees haut;
		coordonnees bas;
		coordonnees gauche;
		coordonnees droite;
		
		
		haut.x = this.getCoord ().x;
		haut.y = this.getCoord ().y + 1;
		
		bas.x = this.getCoord ().x;
		bas.y = this.getCoord ().y - 1;
		
		gauche.x = this.getCoord ().x -1;
		gauche.y = this.getCoord ().y;
		
		droite.x = this.getCoord ().x+1;
		droite.y = this.getCoord ().y ;
		
		if ((c.getListCoord().Contains (haut) ||
		     c.getListCoord().Contains (bas) ||
		     c.getListCoord().Contains (gauche) ||
		     c.getListCoord().Contains (droite)) &&
		    couleur == this.getCouleur ()) 
		{
			c.addPierre(this);
			return true;
		}
		else
			return false;
	}
	
}