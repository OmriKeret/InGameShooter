using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


	private shootingManager shootingManager;
	private PlayerController playerController;
	// Use this for initialization
	void Start () {

	}
	void Awake() 
	{
		shootingManager = gameObject.GetComponent<shootingManager> ();
		playerController = gameObject.GetComponent<PlayerController> ();
	}

	public void setPlayerNum (int playerNum) {
		shootingManager.playerNumber = playerNum;
		playerController.playerNumber = playerNum;
	}
}
