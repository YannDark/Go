using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chaine {
	private List<Pierre> pierreComposantChaine;
	private List<coordonnees> listCoord;
	private List<coordonnees> listLibertes;
	private couleur couleur;
	private int libertesTotal;
	
	
	public Chaine(){
		pierreComposantChaine = new List<Pierre>();
		listCoord = new List<coordonnees>();
		listLibertes = new List<coordonnees>();
		couleur = couleur.Indefinie;
	}

	
	public void recalculLibertesTotal(Grille g){
		Debug.Log (" pierreComposantChaine : " + pierreComposantChaine.Count);
		listLibertes.Clear();
		foreach (Pierre p in pierreComposantChaine) 
		{
			p.getListCoordAdjacente(g);
			Debug.Log (" Pierre : (" + p.getCoord().x + ";" + p.getCoord().y + ") => " +  p.getListLibertes().Count);
			foreach(coordonnees coord in p.getListLibertes())
			{
				if(listLibertes.Contains(coord)==false)
					listLibertes.Add (coord);
			}

		}

		Debug.Log (" lib totales : " + listLibertes.Count);

	}


	public void setLibertesTotal(int libertes)
	{
		libertesTotal = libertes;
	}

	public void addPierre(Pierre p){
		couleur = p.getCouleur ();
		pierreComposantChaine.Add (p);
		listCoord.Add (p.getCoord ());
	}
	
	public void mergeChaine(Chaine c)
	{
		if (c.couleur == couleur)
		{
			foreach (coordonnees coord in c.listCoord) 
				listCoord.Add (coord);
			
			foreach (Pierre p in c.pierreComposantChaine)
				pierreComposantChaine.Add (p);
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

	public bool isTaken(){
		if (getListLibertes().Count == 0)
			return true;
		else
			return false;
	}

	public void remove(){
		foreach (Pierre p in pierreComposantChaine) {
			p.remove ();
			pierreComposantChaine.Remove(p);
		}

			
	}

	public List<coordonnees> getListLibertes(){
		return listLibertes;
	}
	
	
	

	
}
