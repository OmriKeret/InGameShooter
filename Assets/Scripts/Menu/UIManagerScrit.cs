using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


public class UIManagerScrit : MonoBehaviour {
	private List<Button> Buttons ;
	public Animator startButton;
	public Animator settingsButton;
	public Animator dialog;
	public Animator howManyPlayersDialog;
	public Animator tutorialButton;
	public Animator QuitButton;
	public AudioClip click_sound;
	public AudioClip Title_sound;
	// Use this for initialization
	void Start () {
		/*var buttons = GameObject.FindObjectsOfType<Button> ();
		foreach (Button btn in buttons) {
			Buttons.Add(btn);
		}*/
		audio.PlayOneShot (Title_sound);

	}


	public void MenuEntered() 
	{
		//audio.PlayOneShot (Title_sound);
		//startButton.enabled = true;
	//	settingsButton.enabled = true;
	//	tutorialButton.enabled = true;
	//	QuitButton.enabled = true;
	//	tutorialButton.SetBool("isHidden", false);
	//	QuitButton.SetBool("isHidden", false);
	//	startButton.SetBool("isHidden", false);
	//	settingsButton.SetBool("isHidden", false);

	}
	public void OpenSettings()
	{
		//startButton.enabled = true;
	//	settingsButton.enabled = true;
		audio.PlayOneShot (click_sound);
		tutorialButton.SetBool("isHidden", true);
		QuitButton.SetBool("isHidden", true);
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
		dialog.enabled = true;
		dialog.SetBool("isHidden", false);
	}
	public void CloseSettings()
	{
		audio.PlayOneShot (click_sound);
		tutorialButton.SetBool("isHidden", false);
		QuitButton.SetBool("isHidden", false);
		startButton.SetBool("isHidden", false);
		settingsButton.SetBool("isHidden", false);
		dialog.SetBool("isHidden", true);
	}

	public void OpenStartGame()
	{
		audio.PlayOneShot (click_sound);
		Application.LoadLevel("PickPlayerScene");
		startButton.enabled = true;
		settingsButton.enabled = true;
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
		howManyPlayersDialog.enabled = true;
		howManyPlayersDialog.SetBool("isHidden", false);
	}
	public void CloseHowManyPlayers()
	{
		startButton.SetBool("isHidden", false);
		settingsButton.SetBool("isHidden", false);
		howManyPlayersDialog.SetBool("isHidden", true);
	}
	public void OpenTutorial()
	{
		audio.PlayOneShot (click_sound);
		//load scene tutorial
	}

	public void quitGame()
	{
		Application.Quit();
	}

}
