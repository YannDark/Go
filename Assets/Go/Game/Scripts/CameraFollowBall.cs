using UnityEngine;
using System.Collections;

public class CameraFollowBall : MonoBehaviour {
	
	public GameObject theBall; 
	// Use this for initialization
	void Start () {
		transform.position.Set (theBall.transform.position.x, 
		                        theBall.transform.position.y + 2, 
		                        theBall.transform.position.z -6);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set (theBall.transform.position.x, 
		                        theBall.transform.position.y, 
		                        theBall.transform.position.z);
		}
}
