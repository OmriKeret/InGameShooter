using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	LevelManager levelManager;
	PickPlayerData playersData;
	ScoreManager scoreManager;
	private string text = "";
	public AudioClip FinishMusic;

	public static bool gameover = false;
	public static int winner = 0;

	void Awake() 
	{
		playersData = GameObject.Find("PickPlayerData").GetComponent<PickPlayerData>();
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
	}

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		int numPlayers = playersData.HowManyPlayers ();
		Debug.Log ("there were " + numPlayers + " players");
		//get all the scores and update in the players data
		for(int i = 1 ; i <= numPlayers ; i++ ) {
			var playerData = playersData.getPlayer (i);
			playerData.score = scoreManager.getScoreForPlayer(i);
			if (playerData.score >= winner) { winner = i;}
			text += "Player " + i + " score is: " + playerData.score + " !";
			text += "\n";
			//Debug.Log ("Player" + i + " score is: " + playerData.score);
			
		}
		//Find highest score for displaying the right screen
		for (int i = 1; i <= numPlayers; i++) {
			//if (scoreManager.getScoreForPlayer(i) > 
				}
		//Play Some animation
		switch (winner) {
		case (1):
			stop ();
			//Application.LoadLevel ("Winner_is_1");
			break;
		case (2):
			stop ();
			//Application.LoadLevel ("Winner_is_2");
			break;
		case(3):
			stop ();
			//Application.LoadLevel ("Winner_is_3");
			break;
		case(4):
			stop ();
			//Application.LoadLevel ("Winner_is_4");
			break;
				}

	}
			
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			gameover = false;
			Application.LoadLevel (0);
		}
	}
	void stop() {
		audio.PlayOneShot(FinishMusic);
		DestroyObject (GameObject.Find ("ScoreManager"));
		gameover = true;
		}
	void OnTriggerEnter(){ text = "";}
	
	void OnTriggerExit(){ text = "";}
	
	void OnGUI(){
		GUI.Label(new Rect(400, 50, 200, 100), 
		          (text + " and the winner is: " + winner.ToString()));
}
}
