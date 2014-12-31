using UnityEngine;
using System.Collections;

public class PickPlayerData : MonoBehaviour {
	PlayerData[] playersData;
	PlayerData[] playerScores;
	int playerPointer = 0;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	public void insertPlayer(CharacterType character) {
		playersData [playerPointer] = new PlayerData{character = character, playerNum = playerPointer + 1};
		playerPointer++;
	}
	// Use this for initialization
	void Start () {
		MenuData menuData = GameObject.Find("MenuData").GetComponent<MenuData>();
		playersData = new PlayerData[menuData.howManyPlayers];

		//playerScores = new PlayerData[menuData.howManyPlayers];

	}
	public int HowManyPlayers()
	{
		return playersData.Length;
	}

	public PlayerData getPlayer(int playerNum)
	{
		return playersData[playerNum - 1]; 
	}
	// Update is called once per frame
	void Update () {

	}
}
