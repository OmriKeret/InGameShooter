using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class PickPlayerManager : MonoBehaviour {

	MenuData menuData;
	public static int playerNumTurn;
	public Text title;
	public Button aztec;
	public Button archer;
	public Button mage;
	public Button theif;
	public PickPlayerData playerData;

	public List<CharacterType> freeChar;
	// Use this for initialization
	void Start () {
		freeChar = new List<CharacterType> ();
	//	menuData = GameObject.Find("MenuData").GetComponent<MenuData>();
		for(int i = 1 ; i < 5; i++ )
		{
			freeChar.Add ((CharacterType)i);
		}
	}

//	public CharacterType getNextFreeChar(CharacterType e)
//	{
	//	foreach(var char in 
	//}
	public bool Pick(int playerNumber,CharacterType character) 
	{
		if(freeChar.Contains(character)){
			playerData.insertPlayer (character, playerNumber);
			playerNumTurn ++;
			if (playerNumTurn == 5)
				return true;
			freeChar.Remove (character);
			return true;
		}
		return false;
	}
/*	public void PlayerPickAztec(int playerNumber)
	{
	//	aztec.interactable = false;
		playerData.insertPlayer (CharacterType.Aztec, playerNumber);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		freeChar.Remove (CharacterType.Aztec);
		//title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn );
	}
	public void PlayerPickArcher(int playerNumber)
	{
	//	archer.interactable = false;
		playerData.insertPlayer (CharacterType.Archer, playerNumber);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		//title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn);
		freeChar.Remove (CharacterType.Archer);
	}
	public void PlayerPickMage(int playerNumber)
	{
		//mage.interactable = false;
		playerData.insertPlayer (CharacterType.Mage,playerNumber);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		//title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn);
		freeChar.Remove (CharacterType.Mage);
	}
	public void PlayerPickTheif(int playerNumber)
	{
		//theif.interactable = false;
		playerData.insertPlayer (CharacterType.Thief, playerNumber);
		playerNumTurn ++;
		if (playerNumTurn == 5)
			return;
		//title.text = String.Format("Player {0},Pick Your Fighter!",playerNumTurn );
		freeChar.Remove (CharacterType.Thief);
	}*/

	public void start()
	{
		var music = GameObject.Find("MainMenuMusic");
		music.GetComponent<Music> ().fadeOut ();
		AutoFade.LoadLevel ("Dash scene", 1, 1, Color.black);
		Destroy (music);
	}

	public void goBack()
	{
		var pickData = GameObject.Find ("PickPlayerData");
		Destroy (pickData);
		Application.LoadLevel("MainMenu");
	}
}
