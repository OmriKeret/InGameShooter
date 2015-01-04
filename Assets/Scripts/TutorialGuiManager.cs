using UnityEngine;
using System.Collections;

public class TutorialGuiManager : MonoBehaviour {

	public AudioClip click_sound;
	// Use this for initialization
	void Start () {
	
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
