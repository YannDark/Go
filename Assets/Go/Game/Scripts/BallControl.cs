using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	public GameObject myBall;
	public Camera myCamera;
	private bool isBring;
	// Use this for initialization
	void Start () {
		isBring = false;
		//followMouse ();

	}
	
	// Update is called once per frame
	void Update () {
		//inputPC ();
		//if(isBring)
			followMouse ();
	}

	void OnMouseUp(){

		//isBring = false;
		//Debug.Log("ok relache");

	}

	void OnMouseDown(){
		isBring = true;
	}

	void inputPC(){
		if (Input.GetKey("left"))
			rigidbody.AddForce (-Vector3.right);
		else if (Input.GetKey("right"))
			rigidbody.AddForce (Vector3.right);

		if (Input.GetKey("up"))
			rigidbody.AddForce (Vector3.forward);
		else if (Input.GetKey("down"))
			rigidbody.AddForce (-Vector3.forward);
	}

	void followMouse(){
		Vector3 vec = myCamera.ScreenToWorldPoint (Input.mousePosition);
		vec.z = 1.0F;
		transform.position = vec;
	}
}
