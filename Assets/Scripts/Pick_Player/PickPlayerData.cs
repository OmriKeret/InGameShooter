using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PickPlayerData : MonoBehaviour {
	List<PlayerData> playersData;


	public List<PlayerData> getAllPlayers()
	{
		return playersData;
	}
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	public void insertPlayer(CharacterType character, int playerNumber) {
		playersData.Add( new PlayerData{character = character, playerNum = playerNumber});
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
		foreach (var player in playersData) {
			if( player.playerNum == playerNum) {
				return player;
			}
		}
		return null;
	}
	// Update is called once per frame
	void Update () {

	}
}
