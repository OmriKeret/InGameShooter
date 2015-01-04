using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class PickPlayerManager : MonoBehaviour {

	MenuData menuData;
	public static int playerNumTurn;
	public PickPlayerData playerData;
	public AudioClip click_sound;
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

	public void start()
	{
		audio.PlayOneShot (click_sound);

		var music = GameObject.Find("MainMenuMusic");
		music.GetComponent<Music> ().fadeOut ();
		AutoFade.LoadLevel ("Dash scene", 1, 1, Color.black);
		Destroy (music);
	}

	public void goBack()
	{

		audio.PlayOneShot (click_sound);
		var music = GameObject.Find("MainMenuMusic");
		Destroy (music);
		var pickData = GameObject.Find ("PickPlayerData");
		Destroy (pickData);
		Application.LoadLevel("MainMenu");
	}
}
