﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerManager : MonoBehaviour {
	public PickPlayerManager pickPlayerManager;
	private Animator anim;
	public bool pickedCharacter;
	public int playerNum;
	CharacterType currentChar = CharacterType.Archer;
	private int pointer = 1;
	private List<CharacterType> characters;
	float timeLeft;
	float delay = 0.2f;
	public Button right_btn;
	public Button left_btn;

	public AudioClip click_sound;
	public AudioClip Pick_sound;
	public AudioClip block_sound;
	// Use this for initialization
	void Start () {
		timeLeft = delay;
		anim = gameObject.GetComponentInChildren<Animator> ();
		characters = new List<CharacterType> ();
		for(int i = 1 ; i < 5; i++ )
		{
			characters.Add ((CharacterType)i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!pickedCharacter)
		{
			if (Input.GetButton ("Jump" + playerNum))
			{
				pickedCharacter = pickPlayerManager.Pick(playerNum, currentChar);
				if(pickedCharacter){
					audio.PlayOneShot (Pick_sound);
					anim.SetBool("pickedCharacter",true);
				} else {
					audio.PlayOneShot (block_sound);
				}
			}
			timeLeft -= Time.deltaTime;
			if (timeLeft > 0) { return; }
			if (Input.GetButtonDown ("left" + playerNum) || (Input.GetAxis("Horizontal" + playerNum) == -1))
			{
				showNextCharLeft();
				timeLeft = delay;
			}
			if (Input.GetButtonDown ("right" + playerNum) || (Input.GetAxis("Horizontal" + playerNum) == 1))
			{
				showNextCharRight();
				timeLeft = delay;
			}
		}
	}

	public void showNextCharRight() 
	{
		audio.PlayOneShot (click_sound);
		pointer++;
		pointer = pointer % 4;
		var fixedPointer = pointer < 0 ? -1 * pointer : pointer;
		CharacterType character = characters[fixedPointer];
		anim.SetTrigger (character.ToString ());
		currentChar = character;
		
	}

	public void showNextCharLeft() 
	{
		audio.PlayOneShot (click_sound);
		pointer--;
		pointer = pointer % 4;
		var fixedPointer = pointer < 0 ? -1 * pointer : pointer;
		CharacterType character = characters[fixedPointer];
		anim.SetTrigger (character.ToString ());
		currentChar = character;
	}

	 
}
