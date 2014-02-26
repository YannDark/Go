using System.Collections.Generic;

public class Chaine{
	private List<Pierre> pierreComposantChaine;
	private List<coordonnees> listCoord;
	private couleur couleur;
	private int libertesTotal;
	
	
	public Chaine(){
		pierreComposantChaine = null;
		listCoord = null;
		couleur = couleur.Noire;
	}
	
	public void calculerLiberteTotal(){
		int i=0;
		while (i < pierreComposantChaine.Count) {
			libertesTotal =+ pierreComposantChaine[i].getLibertes();
			i++;		
		}
		
	}
	
	public int getLibertesTotal(){
		return libertesTotal;
	}
	public void addPierre(Pierre p){
		pierreComposantChaine.Add (p);
		listCoord.Add (p.getCoord ());
		libertesTotal =+ p.getLibertes();
	}
	
	public void mergeChaine(Chaine c)
	{
		if (c.couleur == couleur)
		{
			foreach (coordonnees coord in c.listCoord) 
				listCoord.Add (coord);
			
			foreach (Pierre p in c.pierreComposantChaine)
				pierreComposantChaine.Add (p);
			
			
			libertesTotal =+ c.getLibertesTotal ();
			c = null;
			
		}
	}
	
	public List<coordonnees> getListCoord()
	{
		return listCoord;
	}
	
	
	
	public bool isPierreAdjacente(Pierre p)
	{
		coordonnees haut;
		coordonnees bas;
		coordonnees gauche;
		coordonnees droite;
		
		haut.x = p.getCoord ().x;
		haut.y = p.getCoord ().y + 1;
		
		bas.x = p.getCoord ().x;
		bas.y = p.getCoord ().y - 1;
		
		gauche.x = p.getCoord ().x -1;
		gauche.y = p.getCoord ().y;
		
		droite.x = p.getCoord ().x+1;
		droite.y = p.getCoord ().y ;
		
		if ((listCoord.Contains (haut) ||
		     listCoord.Contains (bas) ||
		     listCoord.Contains (gauche) ||
		     listCoord.Contains (droite)) &&
		    couleur == p.getCouleur ()) 
		{
			addPierre(p);
			return true;
		}
		else
			return false;
	}
	
}
