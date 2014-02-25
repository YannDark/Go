using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Chaine = ensemble continu de pierres.
/// </summary>
public class Chaine {
	// les pierres composant la chaine
	private List<Pierre> pierreComposantChaine;
	// toutes les coordonnes composant la chaine
	private List<coordonnees> listCoord;
	// toutes les libertes de notre chaine
	private List<coordonnees> listLibertes;
	// sa couleur
	private couleur couleur;
	
	/// <summary>
	/// Initializes a new instance of the Chaine class.
	/// </summary>
	public Chaine(){
		pierreComposantChaine = new List<Pierre>();
		listCoord = new List<coordonnees>();
		listLibertes = new List<coordonnees>();
		couleur = couleur.Indefinie;
	}

	/// <summary>
	/// Recalculs le nombre de libertes de la chaine
	/// </summary>
	/// <param name="g">la grille</param>
	public void recalculLibertesTotal(Grille g){
		Debug.Log (" pierreComposantChaine : " + pierreComposantChaine.Count);

		// on vide la liste avant traitement
		listLibertes.Clear();

		// pour chaque pierre dans notre chaine
		foreach (Pierre p in pierreComposantChaine) 
		{
			// on recupere la liste des coordonnes adjacentes
			p.getListCoordAdjacente(g);
			//Debug.Log (" Pierre : (" + p.getCoord().x + ";" + p.getCoord().y + ") => " +  p.getListLibertes().Count);

			// pour chaque pierre et chacune de ses libertes
			foreach(coordonnees coord in p.getListLibertes())
			{
				// si ses libertes ne sont pas dans la liste des libertes de la chaine, alors on l'ajoute
				if(listLibertes.Contains(coord)==false)
					listLibertes.Add (coord);
			}

		}

		Debug.Log (" lib totales : " + listLibertes.Count);

	}


	/// <summary>
	/// Adds the pierre a la Chaine.
	/// </summary>
	/// <param name="p">la pierre a ajouter</param>
	public void addPierre(Pierre p)
	{
		couleur = p.getCouleur ();
		// on ajoute la pierre a la liste des pierre de notre chaine
		pierreComposantChaine.Add (p);
		// on ajoute ses coordonnes a la liste des coordonnes
		listCoord.Add (p.getCoord ());
	}

	/// <summary>
	/// Merges 2 chaines
	/// </summary>
	/// <param name="c"> la chaine a merger avec notre chaine courante</param>
	public void mergeChaine(Chaine c)
	{
		// on merge seulement si elles sont de meme couleur
		if (c.couleur == couleur)
		{
			// on ajoute toutes ses coordonnées a la liste des coordonnées de la chaine pere
			foreach (coordonnees coord in c.listCoord) 
				listCoord.Add (coord);

			// on ajoute toutes ses pierres a la liste des pierres de la chaine pere
			foreach (Pierre p in c.pierreComposantChaine)
				pierreComposantChaine.Add (p);
		}
	}

	/// <summary>
	/// Gets la liste des coordonnes
	/// </summary>
	/// <returns>The la liste des coordonnes.</returns>
	public List<coordonnees> getListCoord()
	{
		return listCoord;
	}

	/// <summary>
	/// Gets the couleur.
	/// </summary>
	/// <returns>The couleur.</returns>
	public couleur getCouleur()
	{
		return couleur;
	}

	/// <summary>
	/// Gets the pierre composant chaine.
	/// </summary>
	/// <returns>The pierre composant chaine.</returns>
	public List<Pierre> getPierreComposantChaine(){
		return pierreComposantChaine;
	}

	/// <summary>
	/// Determine si une chaine est prise ou non
	/// </summary>
	/// <returns><c>true</c>, if taken, <c>false</c> otherwise.</returns>
	public bool isTaken(){
		if (getListLibertes().Count == 0)
			return true;
		else
			return false;
	}


	/// <summary>
	/// Remove la chaine
	/// </summary>
	public void remove(){
		foreach (Pierre p in pierreComposantChaine) {
			p.remove ();
		}
	}

	/// <summary>
	/// Gets the list of libertes.
	/// </summary>
	/// <returns>The list libertes.</returns>
	public List<coordonnees> getListLibertes(){
		return listLibertes;
	}
	
	
	

	
}
