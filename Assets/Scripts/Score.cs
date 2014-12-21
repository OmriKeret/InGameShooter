using UnityEngine;
using System.Collections;

public class Score {

	private int currentScore;
	// Use this for initialization
	void Start () {
		currentScore = 0;
	}
	
	public int getScore()
	{
		return currentScore;
	}

	public void addScore(Status stat)
	{
		currentScore = currentScore + (int)stat * 1;
	}

}
