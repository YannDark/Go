using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MovePierreBlanche1 : MonoBehaviour {

	private List<Pierre> listePierreNoires;
	private List<Pierre> listePierreBlanches;

	private Grille g;
	private Chaine c;

	private couleur joueurEnCours;
	
	private int cptNoire;
	private int cptBlanche;

	// Use this for initialization
	void Start () {

		listePierreNoires = new List<Pierre>();
		listePierreBlanches = new List<Pierre>();
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

					listePierreBlanches.Add(p);
					print(p.getCouleur() + " " + listePierreBlanches.Count.ToString() + " (x="+p.getCoord().x + ";y=" +-p.getCoord().y+")");
					cptBlanche++; 
				}
				joueurEnCours = couleur.Noire;
			}
			else
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
					listePierreNoires.Add(p);

					print(p.getCouleur() + " " + listePierreNoires.Count.ToString()+ " (x="+p.getCoord().x + ";y=" +-p.getCoord().y+")");
					cptNoire++;

				}
				joueurEnCours = couleur.Blanche;
			}
		}
	}
}
