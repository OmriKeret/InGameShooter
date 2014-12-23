using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ScoreManager : MonoBehaviour {
	
	
	public int numberOfPlayers;
	private List<Score> scores ;
	private List<Text> scoreText;
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
	
	// Update is called once per frame
	void Update () {
		showScoresForPlayers (numberOfPlayers);

	/*	if(Input.GetButtonDown("AddScoreToPlayer1"))
		{
			addScoreToPlayer(1,Status.FirstKill);
		}*/

	/*	if(Input.GetButtonDown("AddScoreToPlayer2"))
		{
			addScoreToPlayer(2,Status.PentaKill);
		}*/
	}

	public void addScoreToPlayer(int playerNum, Status playerStats)
	{
		scores [playerNum - 1].addScore (playerStats);
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