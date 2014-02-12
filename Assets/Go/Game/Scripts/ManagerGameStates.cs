using UnityEngine;
using System.Collections;

public class ManagerGameStates : MonoBehaviour {
	// La variable state contient l'état actuel de la machine
	private GameState state;
	// on stocke la référence de la balle
	private GameObject theBall;
	// le nom du prochain niveau
	public string nextLevel;

	// On définit tous les états de la machine à état dans GameState
	enum GameState{
		Menu,
		Intro,
		Game,
		Pause,
		End,
		Switch
	}

	public ManagerGameStates(){
		state = GameState.Menu;
	}
	
	// Update is called once per frame
	void Start () {
		// on récupère la balle grace a son tag
		theBall = GameObject.FindWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		switch (state) {
		case GameState.Menu:
			break;
		case GameState.Intro:
			Camera.main.animation.Play("CameraCircle");
			break;
		case GameState.Game:
			// on met le jeu en pause si on appuie sur "p"
			if (Input.GetKeyDown("p"))
				StateChange(GameState.Pause);
			break;
		case GameState.Pause:
			// on remet le jeu en route si on appuie sur "p"
			if (Input.GetKeyDown("p"))
				StateChange(GameState.Game);
			break;
		case GameState.End:
			break;
		case GameState.Switch:
			break;
		}
	}

	void StateChange(GameState newState){
		state = newState;

		switch (state) {
		case GameState.Menu:
			break;
		case GameState.Intro:
			break;
		case GameState.Game:
			//theBall.GetComponent(BallPause).PauseGame(false);
			break;
		case GameState.Pause:
			//theBall.GetComponent(BallPause).PauseGame(true);
			break;
		case GameState.End:
			//theBall.GetComponent(BallPause).PauseGame(true);
			break;
		case GameState.Switch:
			break;
		}
	}

	void endofAnim(){
		if (state == GameState.Intro)
			StateChange (GameState.Game);
		else 
			StateChange (GameState.Switch);

	}
}
