﻿using UnityEngine;
using System.Collections;

public class UIInGameManager : MonoBehaviour {
	public Animator MenuDialog;
	private bool menuOpen = false;
	public LevelManager levelManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(menuOpen){
				CloseMenu();
				menuOpen = false;
			} else {

				OpenMenu();
				menuOpen = true;
			}
		}
	}

	public void OpenMenu()
	{
		MenuDialog.enabled = true;
		MenuDialog.SetBool("isHidden", false);
	//	Time.timeScale = 0F;

	}



	public void CloseMenu()
	{
		MenuDialog.SetBool("isHidden", true);
		Time.timeScale = 1F;
	}


	public void ExitGame()
	{
		Time.timeScale = 1F;
		var pickData = GameObject.Find ("LevelManager");
		Destroy (pickData);
		Application.LoadLevel("MainMenu");
	}

	public void restart()
	{
		Time.timeScale = 1F;
		levelManager.resetData ();

		Application.LoadLevel("Dash scene");
	}
}
