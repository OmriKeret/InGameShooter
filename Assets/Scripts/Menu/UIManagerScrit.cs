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
	// Use this for initialization
	void Start () {
		/*var buttons = GameObject.FindObjectsOfType<Button> ();
		foreach (Button btn in buttons) {
			Buttons.Add(btn);
		}*/


	}
	public void MenuEntered() 
	{
		startButton.enabled = true;
		settingsButton.enabled = true;
		tutorialButton.enabled = true;
		QuitButton.enabled = true;
		tutorialButton.SetBool("isHidden", false);
		QuitButton.SetBool("isHidden", false);
		startButton.SetBool("isHidden", false);
		settingsButton.SetBool("isHidden", false);

	}
	public void OpenSettings()
	{
		//startButton.enabled = true;
	//	settingsButton.enabled = true;
		tutorialButton.SetBool("isHidden", true);
		QuitButton.SetBool("isHidden", true);
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
		dialog.enabled = true;
		dialog.SetBool("isHidden", false);
	}
	public void CloseSettings()
	{
		tutorialButton.SetBool("isHidden", false);
		QuitButton.SetBool("isHidden", false);
		startButton.SetBool("isHidden", false);
		settingsButton.SetBool("isHidden", false);
		dialog.SetBool("isHidden", true);
	}

	public void OpenStartGame()
	{
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
		//load scene tutorial
	}

	public void quitGame()
	{
		Application.Quit();
	}
	// Update is called once per frame
	void Update () {

	}
}
