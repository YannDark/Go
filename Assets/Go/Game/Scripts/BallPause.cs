using UnityEngine;
using System.Collections;

public class BallPause : MonoBehaviour {
	// Les variables qui vont contenir les informations de vitesse de la balle
	private Vector3 saveVelocity;
	private Vector3 saveAngularVelocity;

	//La fonction pour entrer et sortir de la pause
	void PauseGame(bool isPause){

		//si on est en pause, on sauvegarde les vitesses juste avant la pause
		if (isPause) {
						saveVelocity = rigidbody.velocity;
						saveAngularVelocity = rigidbody.angularVelocity;
						rigidbody.isKinematic = true;
				}
		//sinon on sort de la pause et on relance le jeu avec les valeurs antérieures
		else {
			rigidbody.isKinematic = false;
			rigidbody.velocity = saveVelocity;
			rigidbody.angularVelocity = saveAngularVelocity;
			rigidbody.WakeUp();
		}
	}



}
