﻿using UnityEngine;
using System.Collections;

public class BarrierCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		// A chaque collision avec le goban, la piece n'est plus soumise aux forces
		if (other.tag == "Player")
			other.rigidbody.isKinematic = true;
	}
}
