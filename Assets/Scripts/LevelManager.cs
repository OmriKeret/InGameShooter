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
	public AudioClip EightKill;
	public AudioClip NineKill;
	public AudioClip TenKill;

	private System.Random randomNumber;
	
	// Use this for initialization
	void Start () {
	}
	
	void Awake() {
		playersData = GameObject.Find("PickPlayerData").GetComponent<PickPlayerData>();
		int numPlayers = playersData.HowManyPlayers();
		for(int i = 1 ; i <= numPlayers ; i++ ) {
			Revive(i);
		}
		DontDestroyOnLoad(transform.gameObject);
		scoreManager.setNumOfPlayers (numPlayers);
		randomNumber = new System.Random();
	}
	
	void Update() {
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

		var popUp = playSoundByStatus(stats);
		var score = scoreManager.addScoreToPlayer (playerNum,stats);

		var player = getPlayerObject (playerNum);
		PlayerManager playerManager = player.GetComponent<PlayerManager> ();
		playerManager.showScore (score);
		playerManager.popUp (popUp);

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
		var characterToInstantiate = playerData.character == CharacterType.Aztec ? Aztec : 
			playerData.character == CharacterType.Archer ? Archer :
				playerData.character == CharacterType.Mage ? Mage : Theif;
		var whereToInstantiate = playerNum == 1 ? player1Respawn : playerNum == 2 ? player2Respawn : 
			playerNum == 3 ? player3Respawn : player4Respawn;
		yield return new WaitForSeconds (timeToRespawn);
		Rigidbody2D PlayerInstance = Instantiate(characterToInstantiate, whereToInstantiate.position, 
		                                         Quaternion.identity) as Rigidbody2D;
		var playerManager = PlayerInstance.GetComponent<PlayerManager> ();
		playerManager.setPlayerNum (playerNum);
		var score = scoreManager.getScoreForPlayer (playerNum);
		playerManager.showScore (score);
	}
	private Status getStatus (int killingSpree) {
		Status status;

		switch (killingSpree) {
		case (0):
			status = Status.NoKill;
			break;
		case (1):
			status = Status.FirstKill;
			break;
		case (2):
			status = Status.DoubleKill;
			break;
		case (3):
			status = Status.TripleKill;
			break;
		case (4):
			status = Status.QuadraKill;
				break;
		case (5):
			status = Status.PentaKill;
			//PlayRandom ();
				break;
		case (6):
			status = Status.GodLike;
				break;
		default: 
			status = Status.MegaMaster;
				break;
		}
		
		return status;
	}

	private GameObject getPlayerObject(int playerNum) 
	{
		CharacterType character = playersData.getPlayer(playerNum).character;
		string characterName = character.ToString();
		return GameObject.Find(characterName + "(Clone)");
	}

	PopUpStatus playSoundByStatus(Status status)
	{
		switch (status) {
		case (Status.FirstKill):
			audio.PlayOneShot(FirstKill);
			return PopUpStatus.FirstKill;

		case (Status.DoubleKill):
			//SecondKill.Play ();
			audio.PlayOneShot(SecondKill);
			return PopUpStatus.DoubleKill;

		case (Status.TripleKill):
			audio.PlayOneShot(ThirdKill);
			return PopUpStatus.TripleKill;


		default: 
			var pop = PlayRandom ();
			return pop;

		}
		//return PopUpStatus.FirstKill;
	}
	PopUpStatus PlayRandom () {

		switch (randomNumber.Next(1,8)) {
			case (1):
				audio.PlayOneShot(FourthKill);
				return PopUpStatus.BRUTAL;

			case(2) :
				audio.PlayOneShot(FifthKill);
				return PopUpStatus.GLORY_DEATH;

			case(3):
				audio.PlayOneShot(SixthKill);
				return PopUpStatus.KILLER;
	
			case(4):
				audio.PlayOneShot(SeventhKill);
				return PopUpStatus.KILLTASTIC;
		
			case(5):
				audio.PlayOneShot(EightKill);
				return PopUpStatus.OH_SNAP;
		
			case(6):
				audio.PlayOneShot(NineKill);
				return PopUpStatus.U_MAD;
		
			case(7):
				audio.PlayOneShot(TenKill);
				return PopUpStatus.WOW;
		
			default:
			audio.PlayOneShot(TenKill);
			return PopUpStatus.WOW;
				//return PopUpStatus.FirstKill;

		}
		}
}
