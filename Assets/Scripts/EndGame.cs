using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	LevelManager levelManager;
	PickPlayerData playersData;
	ScoreManager scoreManager;
	private string text = "";
	public AudioClip FinishMusic;

	private bool gameover = false;

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
			text += "Player" + i + " score is: " + playerData.score;
			Debug.Log ("Player" + i + " score is: " + playerData.score);
			
		}
		//Play Some animation
		audio.PlayOneShot(FinishMusic);
		DestroyObject (GameObject.Find ("ScoreManager"));
		gameover = true;
	}
			
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			gameover = false;
			Application.LoadLevel (0);
		}
	}
	void OnTriggerEnter(){ text = "";}
	
	void OnTriggerExit(){ text = "";}
	
	void OnGUI(){
		GUI.Label(new Rect(600, 200, 200, 40), 
		          (text));
}
}
