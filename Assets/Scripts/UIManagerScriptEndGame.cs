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

	public AudioClip click_sound;
	LevelManager levelManager;
	PickPlayerData playersData;
	ScoreManager scoreManager;
	private int numPlayers;

	private int winner = 1;
	public static bool loaded_scene = false;
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
			if(player.character == CharacterType.Rough) {
				RogueK.text = (player.howManyKills).ToString ();
				RogueS.text = (player.score).ToString ();
			}
		}

	}

	void chooseScene () {
		if (loaded_scene) {
						return;
				}
		int winner = playersData.getWinner ();
		switch (playersData.getPlayer(winner).character) {
				case (CharacterType.Aztec ):
						Application.LoadLevel ("Winner_Is_1");
						loaded_scene = true;
						break;
				case (CharacterType.Archer ):
						Application.LoadLevel ("Winner_Is_2");
						loaded_scene = true;
						break;
				case(CharacterType.Mage):
						Application.LoadLevel ("Winner_Is_3");
						loaded_scene = true;
						break;
				case(CharacterType.Rough):
						Application.LoadLevel ("Winner_Is_4");
						loaded_scene = true;
						break;
				default:
						Application.LoadLevel ("Winner_Is_4");
						loaded_scene = true;
						break;
				}

		}
	public void restart() {
		audio.PlayOneShot (click_sound);
		loaded_scene = false;
		Application.LoadLevel("Dash scene");
		GameObject.Find ("UIManager").GetComponent <UIInGameManager>().restart();
		GameObject.Find ("TimerText").GetComponent<Timer>().Reset ();
		DestroyObject (gameObject);
	}

	public void MainMenu() {
		audio.PlayOneShot (click_sound);
		loaded_scene = false;
		if (audio.isPlaying){
			audio.Stop ();
		}
		var playersDataToDes = GameObject.Find ("PickPlayerData");
		var scoreManagerToDes = GameObject.Find ("ScoreManager");
		var levelManagerToDes = GameObject.Find ("LevelManager");
		Destroy (playersDataToDes);
		Destroy (scoreManagerToDes);
		Destroy (levelManagerToDes);
		Application.LoadLevel (1);
		DestroyObject (gameObject);
	}
}
