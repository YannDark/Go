using UnityEngine;
using System.Collections;

public class CameraAnim : MonoBehaviour {

	void endofAnim()
	{
		GameObject.FindWithTag ("GameManager").SendMessage ("endofAnim");
	}
}
