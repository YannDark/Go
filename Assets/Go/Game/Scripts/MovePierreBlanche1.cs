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

					recalculerChaines(g,p,listeChaines);








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
					p.setObjetGraphique(GameObject.Find ("Pierre"+joueurEnCours+cptBlanche));
					p.poser (g);

					recalculerChaines(g,p,listeChaines);
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
		switch(p.getListCoordAdjacente(g).Count){
		case(1):
			Chaine c11 = new Chaine();
			foreach (Chaine c in listeChaines)
			{	
				if(c.getListCoord().Contains(p.getListCoordAdjacente(g)[0])){
					c.addPierre(p);
					c11 = c;
					break;
				}
			}
			print (p.getListCoordAdjacente(g).Count.ToString() + " : " + c11.getPierreComposantChaine().Count.ToString());
			break;
		case(2):
			Chaine c21 = new Chaine();		
			Chaine c22 = new Chaine();
			bool stillAdded = false;
			foreach (Chaine c in listeChaines)
			{	
				if(c.getListCoord().Contains(p.getListCoordAdjacente(g)[0])||
				   c.getListCoord().Contains(p.getListCoordAdjacente(g)[1]))
				{
					if(stillAdded)
					{
						c22 = c;
						listeChaines.Remove(c);
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
			c21.mergeChaine(c22);
			c22 = null;
			print (p.getListCoordAdjacente(g).Count + " : " + c21.getPierreComposantChaine().Count);
			break;
		case(3):
			Chaine c31 = new Chaine();		
			Chaine c32 = new Chaine();
			Chaine c33 = new Chaine();		
			int chaineMergees = 0;
			foreach (Chaine c in listeChaines)
			{	
				if(c.getListCoord().Contains(p.getListCoordAdjacente(g)[0])||
				   c.getListCoord().Contains(p.getListCoordAdjacente(g)[1])||
				   c.getListCoord().Contains(p.getListCoordAdjacente(g)[2]))
				{
					if(chaineMergees==2)
					{
						c33 = c;
						//listeChaines.Remove(c);
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
			
			c31.mergeChaine(c32);
			listeChaines.Remove(c32);	
			c31.mergeChaine(c33);
			listeChaines.Remove(c33);	
			print (p.getListCoordAdjacente(g).Count + " : " +  c31.getPierreComposantChaine().Count);
			break;
		case(4):
			Chaine c41 = new Chaine();		
			Chaine c42 = new Chaine();
			Chaine c43 = new Chaine();
			Chaine c44 = new Chaine();
			int chaineMergees4 = 0;
			foreach (Chaine c in listeChaines)
			{	
				if(c.getListCoord().Contains(p.getListCoordAdjacente(g)[0])||
				   c.getListCoord().Contains(p.getListCoordAdjacente(g)[1])||
				   c.getListCoord().Contains(p.getListCoordAdjacente(g)[2])||
				   c.getListCoord().Contains(p.getListCoordAdjacente(g)[3]))
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
			
			c41.mergeChaine(c42);
			listeChaines.Remove(c42);
			c41.mergeChaine(c43);
			listeChaines.Remove(c43);
			c41.mergeChaine(c44);
			listeChaines.Remove(c44);
			print (p.getListCoordAdjacente(g).Count + " : " + c41.getPierreComposantChaine().Count);
			break;
		default:
			Chaine c5 = new Chaine();
			c5.addPierre(p);
			listeChaines.Add(c5);
			break;
			
		}
		}
}
