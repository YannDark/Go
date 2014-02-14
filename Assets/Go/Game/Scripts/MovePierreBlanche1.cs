using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePierreBlanche1 : MonoBehaviour {
	private GameObject maPiece;

	private enum couleur{
		Blanche,
		Noire
	};
	private couleur color;
	private bool[,] coord;
	private float x,y,z;
	private int cptNoire;
	private int cptBlanche;

	// Use this for initialization
	void Start () {
		color = couleur.Noire;
		coord = new bool [9, 9];
		for (int i=0; i<9; i++) {
			for(int j=0;j<9;j++){
				coord[i,j]=false;
			}
		}
		cptNoire = 1;
		cptBlanche = 1;


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {

			if(color == couleur.Blanche)
			{
				if (cptBlanche>40)
				{
					print ("Plus de pièces blanches");
				}
				else
				{
					print ("Pierre"+color+cptBlanche);
					maPiece = GameObject.Find ("Pierre"+color+cptBlanche);
					PoserPiece();
					cptBlanche++; 
				}
				color = couleur.Noire;
			}
			else
			{
				if (cptNoire>41)
				{
					print ("Plus de pièces noires");
				}
				else
				{
					print ("Pierre"+color+cptNoire);
					maPiece = GameObject.Find ("Pierre"+color+cptNoire);
					PoserPiece();
					cptNoire++;

				}
				color = couleur.Blanche;
			}
		}
	}

	void PoserPiece(){
		do{
			x = Random.Range (0,9);
			y = 0.8f;
			z = Random.Range (0,9);
		}while(coord[(int)x,(int)z] == true);
		
		//maPiece.rigidbody.isKinematic=false;
		//maPiece.rigidbody.useGravity = true;
		coord[(int)x,(int)z] = true;
		maPiece.transform.position = new Vector3(x,y,-z);
	}
}
