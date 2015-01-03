using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class PickPlayerManager : MonoBehaviour {

	MenuData menuData;
	public static int playerNumTurn;
	public Text title;
	public Button aztec;
	public Button archer;
	public Button mage;
	public Button theif;
	public PickPlayerData playerData;

	// Use this for initialization
	void Start () {
	//	menuData = GameObject.Find("MenuData").GetComponent<MenuData>();
		playerNumTurn = 1;
	}
	public void PlayerPickAztec()
	{
		aztec.interactable = false;
		playerData.insertPlayer (CharacterType.aztec);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn );
	}
	public void PlayerPickArcher()
	{
		archer.interactable = false;
		playerData.insertPlayer (CharacterType.archer);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn);
	}
	public void PlayerPickMage()
	{
		mage.interactable = false;
		playerData.insertPlayer (CharacterType.mage);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn);
	}
	public void PlayerPickTheif()
	{
		theif.interactable = false;
		playerData.insertPlayer (CharacterType.thief);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn );
	}

	public void start()
	{
		Application.LoadLevel("Dash scene");
	}

	public void goBack()
	{
		var pickData = GameObject.Find ("PickPlayerData");
		Destroy (pickData);
		Application.LoadLevel("MainMenu");
	}
}
