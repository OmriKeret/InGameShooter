﻿using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	LevelManager levelManager;
	PickPlayerData playersData;
	ScoreManager scoreManager;

	public Texture2D button_reset;
	public Texture2D button_MainMenu;

	public static int winner = 1;

	//void Awake() 
	//{
	//	playersData = GameObject.Find ("PickPlayerData").GetComponent<PickPlayerData> ();
	//	scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	//	DontDestroyOnLoad (gameObject);

	//}

	// Use this for initialization
	void Start () {
	}
			
	
	// Update is called once per frame
	void Update () {
		/*levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		int numPlayers = playersData.HowManyPlayers ();
		//get all the scores and update in the players data
		for(int i = 1 ; i <= numPlayers ; i++ ) {
			var playerData = playersData.getPlayer (i);
			playerData.score = scoreManager.getScoreForPlayer(i);
			if (scoreManager.getScoreForPlayer(i) >= scoreManager.getScoreForPlayer(winner)) { winner = i;}
			//text += "Player " + i + " score is: " + playerData.score + " !";
			//text += "\n";
			
		}
		switch (winner) {
		case (1):
			//stop ();
			Application.LoadLevel ("Winner_Is_1");
			break;
		case (2):
			//stop ();
			Application.LoadLevel ("Winner_Is_2");
			break;
		case(3):
			//stop ();
			Application.LoadLevel ("Winner_Is_3");
			break;
		case(4):
			//stop ();
			Application.LoadLevel ("Winner_Is_4");
			break;
		default:
			Application.LoadLevel ("Winner_Is_1");
			break;
		}
		if (Application.loadedLevelName == "Winner_Is_1" || Application.loadedLevelName == "Winner_Is_2" ||
						Application.loadedLevelName == "Winner_Is_3" || Application.loadedLevelName == "Winner_Is_4") {
			if(!audio.isPlaying) {
				audio.Play();
			}
				}*/
	}
	IEnumerator wait() {
		yield return new WaitForSeconds (2);
	}
	void stop() {
		if (audio.isPlaying){
			audio.Stop ();
		}
		DestroyObject (GameObject.Find ("ScoreManager"));
		DestroyObject (GameObject.Find ("PickPlayerData"));
		DestroyObject (GameObject.Find ("LevelManager"));
		//return;
		//gameover = true;
		}
	void OnTriggerEnter(){ }
	
	void OnTriggerExit(){ }
	
	void OnGUI(){
		/*//GUI.Label(new Rect(400, 50, 200, 100), 
		       //  (text + " and the winner is: " + winner.ToString()));
		if (Application.loadedLevelName == "Winner_Is_1" || Application.loadedLevelName == "Winner_Is_2" ||
			Application.loadedLevelName == "Winner_Is_3" || Application.loadedLevelName == "Winner_Is_4") {
			//GUI.Box(new Rect(300,50,300,100), "THE WINNER IS PLAYER " + 
			  //      winner.ToString () + " \nWITH " + scoreManager.getScoreForPlayer(winner) +
			    //    " POINTS!!!");

			if (GUI.Button (new Rect (440, 620, 100, 50), button_MainMenu)) {
				//stop ();
				Application.LoadLevel (1);
				DestroyObject (gameObject);
			}
			if(GUI.Button (new Rect(840,620,100,50), button_reset)) {
				Application.LoadLevel("Dash scene");
				GameObject.Find ("UIManager").GetComponent <UIInGameManager>().restart();
				GameObject.Find ("Timer").GetComponent<Timer>().Reset ();
				DestroyObject (gameObject);

			}
		}*/
}
}
