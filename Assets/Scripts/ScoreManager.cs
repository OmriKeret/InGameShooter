using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ScoreManager : MonoBehaviour {
	
	
	public int numberOfPlayers;
	private static List<Score> scores ;
	private List<Text> scoreText;
	
	public static bool PlayerOneAlive = false;
	public static bool PlayerTwoAlive = false;
	public static bool PlayerThreeAlive = false;
	public static bool PlayerFourAlive = false;
	// Use this for initialization
	void Start () {
		scores = new List<Score>(); 
		scoreText = new List<Text>();
		for(int i = 0; i < 4 ; i++)
		{
			scores.Add (new Score ());
		}
		var texts = gameObject.GetComponentsInChildren<Text> ();
		foreach (Text scoretxt in texts) {
			scoreText.Add(scoretxt);
		}
		
	}
	void Awake() {
		this.Start ();
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {


	}
	
	public void addScoreToPlayer(int playerNum, Status playerStats)
	{
		Debug.Log ("I got here, Status is " + playerStats +" and playerNumber is "+ playerNum);
		scores [playerNum - 1].addScore (playerStats);
		showScoresForPlayers (numberOfPlayers);
		showScoresForPlayers (numberOfPlayers);
	}

	public int getScoreForPlayer(int playerNum) 
	{
		return scores [playerNum - 1].getScore ();
	}
	
	public void showScoresForPlayers(int playersNum) 
	{
		for(int i = 0; i < playersNum; i++) 
		{
			scoreText[i].text = String.Format("Player {0} Score: {1}",i + 1,  scores[i].getScore());
		}
		
		for (int i = playersNum; i < 4; i++ ) 
		{
			scoreText[i].text = null;
		}

	}
}