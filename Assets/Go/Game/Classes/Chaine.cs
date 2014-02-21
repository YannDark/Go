using System.Collections;
using System.Collections.Generic;

public class Chaine {
	private List<Pierre> pierreComposantChaine;
	private List<coordonnees> listCoord;
	private couleur couleur;
	private int libertesTotal;
	
	
	public Chaine(){
		pierreComposantChaine = new List<Pierre>();
		listCoord = new List<coordonnees>();
		couleur = couleur.Indefinie;
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
		couleur = p.getCouleur ();
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
			
		}
	}
	
	public List<coordonnees> getListCoord()
	{
		return listCoord;
	}

	public couleur getCouleur()
	{
		return couleur;
	}

	public List<Pierre> getPierreComposantChaine(){
		return pierreComposantChaine;
	}


	
	
	

	
}
