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
	// Use this for initialization
	void Start () {
		/*var buttons = GameObject.FindObjectsOfType<Button> ();
		foreach (Button btn in buttons) {
			Buttons.Add(btn);
		}
		*/

	}
	public void OpenSettings()
	{
		startButton.enabled = true;
		settingsButton.enabled = true;
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
		dialog.enabled = true;
		dialog.SetBool("isHidden", false);
	}
	public void CloseSettings()
	{
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
	// Update is called once per frame
	void Update () {

	}
}
