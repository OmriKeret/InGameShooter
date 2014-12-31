using UnityEngine;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour {
	PickPlayerData playersData;
	public Rigidbody2D Aztec;
	public Rigidbody2D Archer;
	public Rigidbody2D Mage;
	public Rigidbody2D Theif;
	public Transform player1Respawn;
	public Transform player2Respawn;
	public Transform player3Respawn;
	public Transform player4Respawn;
	public ScoreManager scoreManager;
	public float timeToRespawn;
	
	public AudioClip FirstKill;
	public AudioClip SecondKill;
	public AudioClip ThirdKill;
	public AudioClip FourthKill;
	public AudioClip FifthKill;
	public AudioClip SixthKill;
	public AudioClip SeventhKill;
	public AudioClip Dead;
	public AudioClip FinishMusic;
	public AudioClip FiveLastSec;
	
	private float startTime = 0;
	private float elapsedTime;
	public int Gametime;
	
	// Use this for initialization
	void Start () {
		
		playersData = GameObject.Find("PickPlayerData").GetComponent<PickPlayerData>();
	}
	
	void Awake() {
		playersData = GameObject.Find("PickPlayerData").GetComponent<PickPlayerData>();
		int numPlayers = playersData.HowManyPlayers();
		for(int i = 1 ; i <= numPlayers ; i++ ) {
			Revive(i);
		}
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Update() {
		//TODO: Remove these revive key codes.
		if (Input.GetKey (KeyCode.C)) {	Revive (1);}
		if (Input.GetKey (KeyCode.X)) {	Revive (2);}
		if (Time.time >= Gametime && (Application.loadedLevelName == "Dash scene")) {
			elapsedTime = Time.time - startTime;
			Application.LoadLevel ("EndGame");
			this.StopAllCoroutines ();
		}
		//HOW TO Make the game restart correctly? 
		//if (Time.time >= Gametime && (Application.loadedLevelName == "EndGame")) {
		//Gametime += (int)Time.time;
		//}
	}
	
	
	
	public void resetData()	{
		int numPlayers = playersData.HowManyPlayers();
		//get all the scores and update in the players data
		for(int i = 1 ; i <= numPlayers ; i++ ) {
			var playerData = playersData.getPlayer (i);
			playerData.score = 0;
			playerData.killingSpree = 0;
		}
	}
	
	public void Revive(int playerNum) 
	{
		resetPlayerSpree (playerNum);
		StartCoroutine(ReviveLogic (playerNum));
	}
	public void gotKill(int playerNum)
	{
		addOneToSpree(playerNum);
		var playerData = playersData.getPlayer (playerNum);
		var killingSpree = getPlayerSpree (playerNum);
		Status stats = getStatus(killingSpree);
		scoreManager.addScoreToPlayer (playerNum,stats);
	}
	
	public void addOneToSpree(int playerNum)
	{
		var playerData = playersData.getPlayer (playerNum);
		playerData.killingSpree ++;
	}
	public int getPlayerSpree(int playerNum)
	{
		var playerData = playersData.getPlayer (playerNum);
		return playerData.killingSpree;
	}
	
	public void resetPlayerSpree(int playerNum)
	{
		var playerData = playersData.getPlayer (playerNum);
		playerData.killingSpree = 0;
	}
	private IEnumerator ReviveLogic(int playerNum) {
		var playerData = playersData.getPlayer (playerNum);
		var characterToInstantiate = playerData.character == CharacterType.aztec ? Aztec : 
			playerData.character == CharacterType.archer ? Archer :
				playerData.character == CharacterType.mage ? Mage : Theif;
		var whereToInstantiate = playerNum == 1 ? player1Respawn : playerNum == 2 ? player2Respawn : 
			playerNum == 3 ? player3Respawn : player4Respawn;
		yield return new WaitForSeconds (timeToRespawn);
		Rigidbody2D PlayerInstance = Instantiate(characterToInstantiate, whereToInstantiate.position, 
		                                         Quaternion.identity) as Rigidbody2D;
		var playerManager = PlayerInstance.GetComponent<PlayerManager> ();
		playerManager.setPlayerNum (playerNum);
	}
	
	//public void endLevel()
	//{
	//	int numPlayers = playersData.HowManyPlayers();
		//get all the scores and update in the players data
	//	for(int i = 1 ; i <= numPlayers ; i++ ) {
	//		var playerData = playersData.getPlayer (i);
	//		playerData.score = scoreManager.getScoreForPlayer(i);
	//	}
		
//}
	private Status getStatus (int killingSpree) {
		Status status;
		switch (killingSpree) {
		case (0):
			status = Status.NoKill;
			break;
		case (1):
			status = Status.FirstKill;
			audio.PlayOneShot(FirstKill);
			break;
		case (2):
			status = Status.DoubleKill;
			audio.PlayOneShot(SecondKill);
			break;
		case (3):
			status = Status.TripleKill;
			audio.PlayOneShot(ThirdKill);
			break;
		case (4):
			status = Status.QuadraKill;
			audio.PlayOneShot(FourthKill);
			break;
		case (5):
			status = Status.PentaKill;
			audio.PlayOneShot(FifthKill);
			break;
		case (6):
			status = Status.GodLike;
			audio.PlayOneShot(SixthKill);
			break;
		default: 
			status = Status.MegaMaster;
			audio.PlayOneShot(SeventhKill);
			break;
		}
		
		return status;
	}
}
