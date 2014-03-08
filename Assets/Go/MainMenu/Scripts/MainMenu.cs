using UnityEngine;
using System.Collections;
using UnityEditor;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public static string pseudo = "";
	public static string numeroPartie = "";

	//connexion à la BDD
	private ConnectionBDD bdd;

	void OnGUI(){
		bdd = new ConnectionBDD();
		//Displaying our Background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);


		var groupWidth = 160;
		var groupHeight = 280;

		var screenWidth = Screen.width;
		var screenHeight = Screen.height;

		var groupX = ( screenWidth - groupWidth ) / 2;
		var groupY = ( screenHeight - groupHeight ) / 2;

		GUI.BeginGroup(new Rect( groupX, groupY, groupWidth, groupHeight ) );
		GUI.Box(new Rect( 0, 0, groupWidth, groupHeight ), "Jeu de Go" );

		GUI.Label(new Rect( 10, 30, 140, 30 ), "Pseudo *" );

		pseudo = GUI.TextField (new Rect (10, 60, 140, 30), pseudo, 25);
		if ( GUI.Button(new Rect( 10, 100, 140, 30 ), "Nouvelle partie" ) )
		{
			if(bdd == null){
				print ("error with database connexion");
			}
			else{
				if(pseudo != ""){
					if (bdd.getIdJoueurWithPseudo(pseudo) == 0)
						bdd.InsertJoueur(pseudo);
					bdd.InsertPartie(bdd.getIdJoueurWithPseudo(pseudo));
					bdd.InsertGoban (bdd.getLastIdPartieInserted(),bdd.getIdJoueurWithPseudo(pseudo));
					MovePierreBlanche1.pseudoNoir = pseudo;
					MovePierreBlanche1.idJoueurNoir = bdd.getIdJoueurWithPseudo(pseudo);
					MovePierreBlanche1.idPartie = bdd.getLastIdPartieInserted();
					MovePierreBlanche1.idGoban = bdd.getLastIdGobanInserted();
					Application.LoadLevel("Game");
					print ("Insertion réussi en théorie");
				}
				else{
					if(EditorUtility.DisplayDialog("Hey wait...", "Please enter your own pseudo", "Ok", "")) 
						print ("pseudo is empty buddy");
				}

			}
			//
		}


		GUI.Label(new Rect( 10, 170, 140, 30 ), "Partie à rejoindre" );		
		numeroPartie = GUI.TextField (new Rect (10, 200, 140, 30), numeroPartie, 25);
		if ( GUI.Button(new Rect( 10, 240, 140, 30 ), "Rejoindre une partie" ) )
		{
			if(numeroPartie != "" && numeroPartie != "0" && pseudo != ""){
				if (bdd.isPartieFull(int.Parse(numeroPartie)))
				{
					if(EditorUtility.DisplayDialog("Hey wait...", "This Game is still playing by 2 players !", "Ok", "")) 
						print ("Partie " + numeroPartie + " still playing");
				}
				else
				{
					print ("on est bon pour le numéro de partie");
					if (bdd.getIdJoueurWithPseudo(pseudo) == 0)
						bdd.InsertJoueur(pseudo);
					bdd.joinGame(int.Parse(numeroPartie),bdd.getIdJoueurWithPseudo(pseudo));
					
					MovePierreBlanche1.pseudoNoir = bdd.GetPseudoWithIdPartie(int.Parse(numeroPartie));
					if (MovePierreBlanche1.pseudoNoir != "")
					{
						MovePierreBlanche1.pseudoBlanc = pseudo;
						MovePierreBlanche1.idJoueurBlanc = bdd.getIdJoueurWithPseudo(pseudo);
						MovePierreBlanche1.idJoueurNoir = bdd.getIdJoueurWithPseudo(MovePierreBlanche1.pseudoNoir);
						MovePierreBlanche1.idGoban = bdd.getIdGoban(int.Parse(numeroPartie),MovePierreBlanche1.idJoueurNoir);
						MovePierreBlanche1.idPartie = int.Parse (numeroPartie);

						Application.LoadLevel("Game");
					}
					else
						if(EditorUtility.DisplayDialog("Hey wait...", "This Game ID doesn't exist !", "Ok", "")) 
							print ("No idPartie-idJoueurNoir Matching");
				}

			}
			else{
				if(EditorUtility.DisplayDialog("Hey wait...", "Please enter your own pseudo and enter a correct game number", "Ok", "")) 
					print ("pseudo is empty buddy");
			}
		}

		GUI.EndGroup();
	}


}