using UnityEngine;
using System.Collections;

public class BarrierCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
						other.SendMessage ("RestartPosition");
	}
}
