using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PickPlayerData : MonoBehaviour {
	List<PlayerData> playersData;
	int playerPointer = 0;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	public void insertPlayer(CharacterType character) {
		playersData.Add( new PlayerData{character = character, playerNum = playerPointer + 1});
		playerPointer++;
	}
	// Use this for initialization
	 void Start () {
	//	MenuData menuData = GameObject.Find("MenuData").GetComponent<MenuData>();
		playersData = new List<PlayerData> ();

		//playerScores = new PlayerData[menuData.howManyPlayers];

	}
	public int HowManyPlayers()
	{
		return playersData.Count;
	}

	public PlayerData getPlayer(int playerNum)
	{
		return playersData[playerNum - 1]; 
	}
	// Update is called once per frame
	void Update () {

	}
}
