using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public GUIStyle button1Texture;
	public GUIStyle button2Texture;

	public float btn1_X;
	public float btn1_Y;
	public float btn1_largeur;
	public float btn1_hauteur;

	public float btn2_X;
	public float btn2_Y;
	public float btn2_largeur;
	public float btn2_hauteur;

	void OnGUI(){
		//Displaying our Background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		// Display our buttons 
		if (GUI.Button (new Rect (Screen.width * btn1_X, Screen.height * btn1_Y, Screen.width * btn1_largeur, Screen.height * btn1_hauteur), "",button1Texture)) {
			print ("Start Game !!!");	
		}
		if (GUI.Button (new Rect (Screen.width * btn2_X, Screen.height * btn2_Y, Screen.width * btn2_largeur, Screen.height * btn2_hauteur), "",button2Texture)) {
			print ("Join a Game");	
		}
	}
}
