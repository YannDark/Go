using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
	/// Classe Pierre.
/// </summary>
public class Pierre{

	// identifiants pour la BDD
	private int idPion;
	private int idGoban;

	//les coordonnees x et y de la Pierre
	private coordonnees coord;
	// les coordonnées voisines de notre pierre (haut,bas,gauche,droite)
	private List<coordonnees> listCoordAdjacente;
	// les libertes de notre Pierre (haut,bas,gauche,droite)
	private List<coordonnees> listLibertes;
	// l'etat de notre pierre
	public etat etat;
	// sa couleur
	private couleur couleur;
	// son équivalent graphique sous Unity
	public GameObject objetGraphique;

	/// <summary>
		/// Initializes a new instance of the Pierre class.
	/// </summary>
	public Pierre()
	{
		coord.x = 0;
		coord.y = 0;
		etat = etat.nonPosee;
		couleur = couleur.Indefinie;
		listCoordAdjacente = new List<coordonnees> ();
		listLibertes = new List<coordonnees> ();
	}

	/// <summary>
		/// Gets the list libertes.
	/// </summary>
	/// <returns>The list libertes.</returns>
	public List<coordonnees> getListLibertes(){
		return listLibertes;
	}


	/// <summary>
		/// Gets the coordinate.
	/// </summary>
	/// <returns>The coordinate.</returns>
	public coordonnees getCoord(){
		return coord;
	}

	/// <summary>
		/// Sets the coordinate.
	/// </summary>
	/// <param name="c">les coordonnees</param>
	public void setCoord(coordonnees c){
		coord = c;
	}

	/// <summary>
		/// Gets the etat.
	/// </summary>
	/// <returns>The etat.</returns>
	/// 
	public etat getEtat(){
		return etat;
	}

	/// <summary>
		/// Sets the etat.
	/// </summary>
	/// <param name="e">l'etat de la pierre</param>
	public void setEtat(etat e){
		etat = e;
	}

	/// <summary>
	/// Gets the couleur.
	/// </summary>
	/// <returns>The couleur.</returns>
	public couleur getCouleur(){
		return couleur;
	}
	public void setCouleur(couleur c){
		couleur = c;
	}

	/// <summary>
	/// Gets the objet graphique.
	/// </summary>
	/// <returns>The objet graphique.</returns>
	public GameObject getObjetGraphique(){
		return objetGraphique;
	}

	/// <summary>
	/// Sets the objet graphique.
	/// </summary>
	/// <param name="o">O.</param>
	public void setObjetGraphique(GameObject o){
		objetGraphique = o;
	}
	
	/// <summary>
	/// Poser une pierre sur la grille.
	/// </summary>
	/// <param name="g">la grille</param>
	public void poser(Grille g){
		coordonnees coord;

		// on cherche aleatoirement des coordonnées jusqu'a ce qu'elle soit libre
		do{
			coord.x = Random.Range (0,9);
			coord.y = Random.Range (0,9);
		}while(g.isTaken(coord.x,coord.y));

		// on lui attribue les coordonnees trouvees
		setCoord (coord);

		// on repercute le couleur sur la grille
		if(getCouleur() == couleur.Noire)
			g.setValue(coord.x,coord.y,couleur.Noire);
		else if(getCouleur() == couleur.Blanche)
			g.setValue(coord.x,coord.y,couleur.Blanche);

		// on positionne l'objet graphique sur notre goban
		objetGraphique.renderer.enabled = true;
		objetGraphique.transform.position = new Vector3(coord.x,0.8f,-(coord.y));

		// on récupère ses coordonnes adjacentes
		getListCoordAdjacente (g);
	}

	public void simuler(Grille g,int x,int y){
		coordonnees coord;
		coord.x = x;
		coord.y = y;
		
		// on lui attribue les coordonnees trouvees
		setCoord (coord);
		
		// on repercute le couleur sur la grille
		if(getCouleur() == couleur.Noire)
			g.setValue(coord.x,coord.y,couleur.Noire);
		else if(getCouleur() == couleur.Blanche)
			g.setValue(coord.x,coord.y,couleur.Blanche);


		// on positionne l'objet graphique sur notre goban
		objetGraphique.renderer.enabled = true;
		objetGraphique.transform.position = new Vector3(coord.x,0.8f,-(coord.y));
		
		// on récupère ses coordonnes adjacentes
		getListCoordAdjacente (g);
	}

	/// <summary>
	/// Détermine les coordonnées de l'intersection en haut de notre pierre
	/// </summary>
	/// <param name="g">la grille</param>
	public void setCoordHaut(Grille g){
		coordonnees haut;
		haut.x = this.getCoord ().x;
		haut.y = this.getCoord ().y - 1;

		// si on ne sort pas du plateau on ajoute notre cordonnée a la liste des coordonnées adjacentes
		if (haut.y >= 0) {
			listCoordAdjacente.Add (haut);
			// si cette coordonnée est libre, on l'ajoute aussi a la liste des libertes de notre Pierre
			if (g.getGrille () [haut.x, haut.y] == couleur.Indefinie)
				listLibertes.Add (haut);
		}
	}
	/// <summary>
	/// Détermine les coordonnées de l'intersection en bas de notre pierre
	/// </summary>
	/// <param name="g">la grille</param>
	public void setCoordBas(Grille g){
		coordonnees bas;
		bas.x = this.getCoord ().x;
		bas.y = this.getCoord ().y + 1;

		// si on ne sort pas du plateau on ajoute notre cordonnée a la liste des coordonnées adjacentes
		if (bas.y <= 8) {
			listCoordAdjacente.Add (bas);
			// si cette coordonnée est libre, on l'ajoute aussi a la liste des libertes de notre Pierre
			if(g.getGrille()[bas.x,bas.y] == couleur.Indefinie)
				listLibertes.Add (bas);
		}
			
	}

	/// <summary>
	/// Détermine les coordonnées de l'intersection a gauche de notre pierre
	/// </summary>
	/// <param name="g">la grille</param>
	public void setCoordGauche(Grille g){
		coordonnees gauche;
		gauche.x = this.getCoord ().x -1;
		gauche.y = this.getCoord ().y;

		// si on ne sort pas du plateau on ajoute notre cordonnée a la liste des coordonnées adjacentes
		if (gauche.x >= 0) {
			listCoordAdjacente.Add (gauche);
			// si cette coordonnée est libre, on l'ajoute aussi a la liste des libertes de notre Pierre
			if(g.getGrille()[gauche.x,gauche.y] == couleur.Indefinie)
				listLibertes.Add (gauche);
		}
	}

	/// <summary>
	/// Détermine les coordonnées de l'intersection a droite de notre pierre
	/// </summary>
	/// <param name="g">la grille</param>
	public void setCoordDroite(Grille g){
		coordonnees droite;
		droite.x = this.getCoord ().x+1;
		droite.y = this.getCoord ().y ;

		// si on ne sort pas du plateau on ajoute notre cordonnée a la liste des coordonnées adjacentes
		if (droite.x <= 8) {
			listCoordAdjacente.Add (droite);
			// si cette coordonnée est libre, on l'ajoute aussi a la liste des libertes de notre Pierre
			if(g.getGrille()[droite.x,droite.y] == couleur.Indefinie)
				listLibertes.Add (droite);

		}

	}
	/// <summary>
	/// Gets the list coordinate adjacente.
	/// </summary>
	/// <returns>The list coordinate adjacente.</returns>
	/// <param name="g">la grille</param>
	public List<coordonnees> getListCoordAdjacente(Grille g){
		// on vide les listes
		listCoordAdjacente.Clear ();
		listLibertes.Clear ();

		// on determine les coordonnees adjacentes
		setCoordHaut(g);
		setCoordBas(g);
		setCoordGauche(g);
		setCoordDroite(g);


		return listCoordAdjacente;
	}

	/// <summary>
	/// Donne le nombre de points d'attache potentiels d'une chaine de meme couleur
	/// </summary>
	/// <returns>le nombre de points d'attache</returns>
	/// <param name="g">la grille</param>
	public int getNbCoordAdjacenteMemeCouleur(Grille g){
		int cpt = 0;

		// pour chaque coordonnée adjacente, on increment le compteur si elle est de meme couleur que notre pierre
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

	/// <summary>
	/// Remove la pierre de notre goban.
	/// </summary>
	public void remove(){
		objetGraphique.transform.position = new Vector3(50f,0.8f,-50f);
	}

	/// <summary>
	/// Gets the identifier goban.
	/// </summary>
	/// <returns>The identifier goban.</returns>
	public int getIdGoban(){
		return idGoban;
	}

	/// <summary>
	/// Sets the identifier goban.
	/// </summary>
	/// <param name="id">Identifier.</param>
	public void setIdGoban(int id){
		idGoban = id;
	}


}