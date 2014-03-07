using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MovePierreBlanche1 : MonoBehaviour {

	//notre IA
	private IA ia;
	// connection a la BDD
	private ConnectionBDD cnxBDD;

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

	// les scores
	private GameObject scoreNoir;
	private GameObject scoreBlanc;


	// les pseudos
	public static string pseudoNoir;
	public static string pseudoBlanc;
	// Use this for initialization
	void Start () {
		Debug.Log (MainMenu.numeroPartie);
		Debug.Log (MainMenu.pseudo);
		ia = new IA ();
		listeChaines = new List<Chaine> ();
		g = new Grille ();

		joueurEnCours = couleur.Noire;

		cptNoire = 1;
		cptBlanche = 1;

		scoreNoir = GameObject.Find ("GUI Text J1");
		scoreNoir.guiText.text = "Joueur Noir\n" + pseudoNoir + "\nPoints : 0";

		scoreBlanc = GameObject.Find ("GUI Text J2");
		scoreBlanc.guiText.text = "Joueur Blanc\n" + pseudoBlanc + "\nPoints : 0";



		/*cnxBDD = new connectionBDD ();

		if(cnxBDD.OpenConnection ()==true)
			Debug.Log("Ca ping !");
		else
			Debug.Log("Ca ping pas du tout !");*/


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {

			if(joueurEnCours == couleur.Blanche)
			{
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
					g.recalculerChaines(p,listeChaines);

					// on compte le score
					int sb = ia.evaluer(g,p);
					scoreBlanc.guiText.text = "Joueur Blanc\nPoints : " + sb;

					// on incrémente le compteur de pieces blanches jouees
					cptBlanche++; 
				}
				// on enlève les pierres prises
				g.faitLeMenage(listeChaines,joueurEnCours);
				// on passe au joueur suivant
				joueurEnCours = couleur.Noire;
			}
			else if(joueurEnCours == couleur.Noire)
			{
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
					g.recalculerChaines(p,listeChaines);
					// on compte le score
					int sn = ia.evaluer(g,p);
					scoreNoir.guiText.text = "Joueur Noir\nPoints : " + sn;
					// on incrémente le compteur de pieces noires jouees
					cptNoire++;
				}
				// on enlève les pierres prises
				g.faitLeMenage(listeChaines,joueurEnCours);
				// on passe au joueur suivant
				joueurEnCours = couleur.Blanche;
			}
		}
	}





}
