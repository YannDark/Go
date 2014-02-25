using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MovePierreBlanche1 : MonoBehaviour {
	
	// la liste des chaines existantes sur le plateau
	private List<Chaine> listeChaines;

	// la grille de jeu
	private Grille g;

	// le joueur en cours
	private couleur joueurEnCours;

	// le nombre de pierres noires jouéées
	private int cptNoire;
	// le nombre de pierres blanches jouees
	private int cptBlanche;

	// Use this for initialization
	void Start () {

		listeChaines = new List<Chaine> ();
		g = new Grille ();

		joueurEnCours = couleur.Noire;

		cptNoire = 1;
		cptBlanche = 1;


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {

			if(joueurEnCours == couleur.Blanche)
			{
				faitLeMenage(g);

				// si on a plus de pieces
				if (cptBlanche>40)
				{
					Debug.Log ("Plus de pièces blanches");
				}
				else
				{
					// on cree une nouvelle pierre
					Pierre p = new Pierre ();
					// on lui affecte une couleur
					p.setCouleur (couleur.Blanche);
					// on recupere l'object graphique correspondant
					p.setObjetGraphique(GameObject.Find ("Pierre"+joueurEnCours+cptBlanche));
					// on pose la pierre sur la grille
					p.poser (g);

					// on recalcule chaque chaine (libertes + merge)
					recalculerChaines(g,p,listeChaines);
					// on incrémente le compteur de pieces blanches jouees
					cptBlanche++; 
				}
				// on passe au joueur suivant
				joueurEnCours = couleur.Noire;
			}
			else if(joueurEnCours == couleur.Noire)
			{
				faitLeMenage(g);

				// si on a plus de pieces
				if (cptNoire>41)
				{
					Debug.Log ("Plus de pièces noires");
				}
				else
				{
					// on cree une nouvelle pierre
					Pierre p = new Pierre ();
					// on lui affecte une couleur
					p.setCouleur (couleur.Noire);
					// on recupere l'object graphique correspondant
					p.setObjetGraphique(GameObject.Find ("Pierre"+joueurEnCours+cptNoire));
					// on pose la pierre sur la grille
					p.poser (g);
					// on recalcule chaque chaine (libertes + merge)
					recalculerChaines(g,p,listeChaines);
					// on incrémente le compteur de pieces noires jouees
					cptNoire++;
				}
				// on passe au joueur suivant
				joueurEnCours = couleur.Blanche;
			}
		}
	}

	/// <summary>
	/// On redessine toutes les chaines suite a la pose de la pierre
	/// </summary>
	/// <param name="g">la grille</param>
	/// <param name="p">la pierre</param>
	/// <param name="listeChaines">Liste chaines.</param>
	void recalculerChaines(Grille g,Pierre p,List<Chaine>listeChaines)
	{
		// on cherche combien de chaines existantes, notre pierre va rejoindre suite a sa pose
		switch(p.getNbCoordAdjacenteMemeCouleur(g)){
		case(1):
			Chaine c11 = new Chaine();
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(g))
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
			c11.recalculLibertesTotal(g);
			break;
		case(2):
			Chaine c21 = new Chaine();		
			Chaine c22 = new Chaine();
			bool stillAdded = false;
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(g))
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
			c21.recalculLibertesTotal(g);
			break;
		case(3):
			Chaine c31 = new Chaine();		
			Chaine c32 = new Chaine();
			Chaine c33 = new Chaine();		
			int chaineMergees = 0;
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(g))
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
			c31.recalculLibertesTotal(g);
			break;
		case(4):
			Chaine c41 = new Chaine();		
			Chaine c42 = new Chaine();
			Chaine c43 = new Chaine();
			Chaine c44 = new Chaine();
			int chaineMergees4 = 0;
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(g))
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
			c41.recalculLibertesTotal(g);
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
			c5.recalculLibertesTotal(g);
			break;
			
		}

	}

	void faitLeMenage(Grille g){
		Chaine chaineADelete = new Chaine();

		foreach(Chaine c in listeChaines)
		{
			if (c.isTaken()){
				foreach(coordonnees coord in c.getListCoord())
				{
					if (c.getCouleur() == couleur.Noire)
						g.getGrille()[coord.x,coord.y] = couleur.PriseBlanche;
					else
						g.getGrille()[coord.x,coord.y] = couleur.PriseNoire;
				}	
				chaineADelete = c ;
				Debug.Log ("DEGAGE !!!!");
				break;
				
			}
		}
		listeChaines.Remove(chaineADelete);
	}
}
