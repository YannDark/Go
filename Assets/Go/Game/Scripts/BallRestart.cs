using UnityEngine;
using System.Collections;

public class BallRestart : MonoBehaviour {
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	

	// Update is called once per frame
	void RestartPosition () {
		transform.position = startPosition;
	}
}
