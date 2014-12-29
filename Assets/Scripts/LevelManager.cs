using UnityEngine;
using System.Collections;

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

	public float timeToRespawn;
	// Use this for initialization
	void Start () {
		//playersData = GameObject.Find("PickPlayerData").GetComponent<PickPlayerData>();
	}

	void Awake() 
	{
		playersData = GameObject.Find("PickPlayerData").GetComponent<PickPlayerData>();
		int numPlayers = playersData.HowManyPlayers();
		for(int i = 1 ; i <= numPlayers ; i++ ) {
			Revive(i);
		}
	}

	void Update() {

		if (Input.GetKey (KeyCode.C)) {
			Revive(1);
				}
	}
	public void Revive(int playerNum) 
	{
		StartCoroutine(ReviveLogic (playerNum));
	}

	private IEnumerator ReviveLogic(int playerNum) 
	{
		var playerData = playersData.getPlayer (playerNum);
		var characterToInstantiate = playerData.character == CharacterType.aztec ? Aztec : playerData.character == CharacterType.archer ? Archer :
			playerData.character == CharacterType.mage ? Mage : Theif;
		var whereToInstantiate = playerNum == 1 ? player1Respawn : playerNum == 2 ? player2Respawn : playerNum == 3 ? player3Respawn : player4Respawn;
		yield return new WaitForSeconds (timeToRespawn);
		Rigidbody2D PlayerInstance = Instantiate(characterToInstantiate, whereToInstantiate.position, Quaternion.identity) as Rigidbody2D;
		var playerManager = PlayerInstance.GetComponent<PlayerManager> ();
		playerManager.setPlayerNum (playerNum);
	}


}
