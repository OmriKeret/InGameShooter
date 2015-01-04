using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ScoreManager : MonoBehaviour {
	
	public LevelManager levelManager;
	public int numberOfPlayers;
	private static List<Score> scores ;
	//private List<Text> scoreText;
	
	public bool PlayerOneAlive = false;
	public bool PlayerTwoAlive = false;
	public bool PlayerThreeAlive = false;
	public bool PlayerFourAlive = false;
	// Use this for initialization
	void Start () {
		scores = new List<Score>(); 
		//scoreText = new List<Text>();
		for(int i = 0; i < 4 ; i++)
		{
			scores.Add (new Score ());
		}
	}
	void Awake() {
		this.Start ();
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void setNumOfPlayers(int i ) 
	{
		numberOfPlayers = i;
	}
	public int addScoreToPlayer(int playerNum, Status playerStats)
	{

		scores [playerNum - 1].addScore (playerStats);
		return (getScoreForPlayer (playerNum));
	}

	public int getScoreForPlayer(int playerNum) 
	{
		return (scores [playerNum - 1].getScore ());
	}

}