using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScriptEndGame : MonoBehaviour {

	public Text AztecK;
	public Text ArcherK;
	public Text WizardK;
	public Text RogueK;
	public Text AztecS;
	public Text ArcherS;
	public Text WizardS;
	public Text RogueS;

	LevelManager levelManager;
	PickPlayerData playersData;
	ScoreManager scoreManager;
	private int numPlayers;

	private int winner = 1;
		
	void Awake (){
		playersData = GameObject.Find ("PickPlayerData").GetComponent<PickPlayerData> ();
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();


		}
	void Start() {
		numPlayers = playersData.HowManyPlayers ();
		chooseScene ();
		FillText ();
	}
	//TODO: Make this more readable for the next version - after the deadline.
	public void FillText() {
		var players = playersData.getAllPlayers ();
		foreach(var player in players)
		{

		//get all the scores and update in the players data
			if(player.character == CharacterType.Aztec) {
				AztecK.text = (player.howManyKills).ToString ();
				AztecS.text = (player.score).ToString ();
			}
			if(player.character == CharacterType.Archer) {
				ArcherK.text = (player.howManyKills).ToString ();
				ArcherS.text = (player.score).ToString ();
			}
			if(player.character == CharacterType.Mage) {
				WizardK.text = (player.howManyKills).ToString ();
				WizardS.text = (player.score).ToString ();
			}
			if(player.character == CharacterType.Thief) {
				RogueK.text = (player.howManyKills).ToString ();
				RogueS.text = (player.score).ToString ();
			}
		}

	}

	void chooseScene () {
		int winner = playersData.getWinner ();
		switch (playersData.getPlayer(winner).character) {
		case (CharacterType.Aztec ):
						Application.LoadLevel ("Winner_Is_1");
						break;
		case (CharacterType.Archer ):
						Application.LoadLevel ("Winner_Is_2");
						break;
				case(CharacterType.Mage):
						Application.LoadLevel ("Winner_Is_3");
						break;
				case(CharacterType.Thief):
						Application.LoadLevel ("Winner_Is_4");
						break;
				default:
						Application.LoadLevel ("Winner_Is_4");
						break;
				}

		}
	public void restart() {
		Application.LoadLevel("Dash scene");
		GameObject.Find ("UIManager").GetComponent <UIInGameManager>().restart();
		GameObject.Find ("Timer").GetComponent<Timer>().Reset ();
		DestroyObject (gameObject);
	}

	public void MainMenu() {
		if (audio.isPlaying){
			audio.Stop ();
		}
		DestroyObject (GameObject.Find ("ScoreManager"));
		DestroyObject (GameObject.Find ("PickPlayerData"));
		DestroyObject (GameObject.Find ("LevelManager"));
		Application.LoadLevel (1);
		DestroyObject (gameObject);
	}
}
