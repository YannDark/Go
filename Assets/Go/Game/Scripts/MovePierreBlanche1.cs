using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MovePierreBlanche1 : MonoBehaviour {

	private List<Pierre> listePierreNoires;
	private List<Pierre> listePierreBlanches;
	private List<Chaine> listeChaines;

	private Grille g;
	private Chaine c;

	private couleur joueurEnCours;
	
	private int cptNoire;
	private int cptBlanche;

	// Use this for initialization
	void Start () {

		listePierreNoires = new List<Pierre>();
		listePierreBlanches = new List<Pierre>();
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
				if (cptBlanche>40)
				{
					print ("Plus de pièces blanches");
				}
				else
				{
					Pierre p = new Pierre ();
					p.setCouleur (couleur.Blanche);
					p.setObjetGraphique(GameObject.Find ("Pierre"+joueurEnCours+cptBlanche));
					p.poser (g);
					//p.setLibertes(p.getListCoordAdjacente(g).Count);
					//print ("lib : " + p.getLibertes());
					recalculerChaines(g,p,listeChaines);

					/*foreach(Chaine c in listeChaines)
					{
						if (c.isTaken()){
							c.remove();
							listeChaines.Remove(c);
						}
					}*/

					listePierreBlanches.Add(p);
					print(p.getCouleur() + " " + listePierreBlanches.Count.ToString() + " (x="+p.getCoord().x + ";y=" +-p.getCoord().y+")");
					cptBlanche++; 
				}
				joueurEnCours = couleur.Noire;
			}
			else if(joueurEnCours == couleur.Noire)
			{
				if (cptNoire>41)
				{
					print ("Plus de pièces noires");
				}
				else
				{
					Pierre p = new Pierre ();
					p.setCouleur (couleur.Noire);
					p.setObjetGraphique(GameObject.Find ("Pierre"+joueurEnCours+cptNoire));
					p.poser (g);
					recalculerChaines(g,p,listeChaines);
					
					/*foreach(Chaine c in listeChaines)
					{

						if (c.isTaken()){
							c.remove();
							listeChaines.Remove(c);
						}
					}*/
						
							

					listePierreNoires.Add(p);
					print(p.getCouleur() + " " + listePierreNoires.Count.ToString()+ " (x="+p.getCoord().x + ";y=" +-p.getCoord().y+")");
					cptNoire++;

				}
				joueurEnCours = couleur.Blanche;
			}
		}
	}

	void recalculerChaines(Grille g,Pierre p,List<Chaine>listeChaines)
	{
		switch(p.getNbCoordAdjacenteMemeCouleur(g)){
		case(1):
			Chaine c11 = new Chaine();
			foreach (Chaine c in listeChaines)
			{	
				foreach(coordonnees coord in p.getListCoordAdjacente(g))
				{
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur()){
						c.addPierre(p);
						c11 = c;
						break;
					}
				}
			}
			Debug.Log ("switch 1");
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
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur())
					{
						if(stillAdded)
						{
							c22 = c;
							break;
						}
						else
						{
							c.addPierre(p);
							c21 = c;
							stillAdded = true;
						}
					}
				}
			}
			Debug.Log ("switch 2");
			c21.mergeChaine(c22);
			listeChaines.Remove(c22);
			c22 = null;
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
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur())
					{
						if(chaineMergees==2)
						{
							c33 = c;
							break;
						}
						else if(chaineMergees==1){
							c32 = c;
							
							chaineMergees++;
						}
						else
						{
							c.addPierre(p);
							c31 = c;
							chaineMergees++;
						}
					}
				}
			}
			Debug.Log ("switch 3");
			c31.mergeChaine(c32);
			c31.mergeChaine(c33);
			listeChaines.Remove(c32);
			c32 = null;
			listeChaines.Remove(c33);
			c33 = null;
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
					if(c.getListCoord().Contains(coord) && p.getCouleur() == c.getCouleur())
					{
						if(chaineMergees4==3)
						{
							c44 = c;
							
							break;
						}
						else if(chaineMergees4==2){
							c43 = c;
							chaineMergees4++;
						}
						else if(chaineMergees4==1){
							c42 = c;
							chaineMergees4++;
						}
						else
						{
							c.addPierre(p);
							c41 = c;
							chaineMergees4++;
						}
					}
				}
			}
			Debug.Log ("switch 4");
			c41.mergeChaine(c42);
			listeChaines.Remove(c42);
			c42 = null;
			c41.mergeChaine(c43);
			listeChaines.Remove(c43);
			c43 = null;
			c41.mergeChaine(c44);
			listeChaines.Remove(c44);
			c44 = null;
			c41.recalculLibertesTotal(g);
			break;
		default:
			Chaine c5 = new Chaine();
			c5.addPierre(p);
			listeChaines.Add(c5);
			c5.recalculLibertesTotal(g);
			break;
			
		}

	}
}
