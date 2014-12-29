using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerManager : MonoBehaviour {
	
	private shootingManager shootingManager;
	private PlayerController playerController;
	private LevelManager levelManager;
	public int lives = 1;
	private Animator anim;
	public AudioClip DeadSound;
	private int kills = 0;
	public int playerNumber;
	public Text playerKillingSpree;
	public bool Dead;
	void Awake()
	{
		shootingManager = gameObject.GetComponent<shootingManager>();
		playerController = gameObject.GetComponent<PlayerController>();
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		anim = GetComponent<Animator> ();
	}
	
	void OnCollisionEnter2D(Collision2D collided) {
		Projectile bulletCollidedWith = collided.gameObject.GetComponent<Projectile> ();
		if (collided.gameObject.tag == "Bullet") {
			float bulletNumber = bulletCollidedWith.getBulletNumber ();
			Dead = playerController.isDisabled;
			if(Dead) return;
			if (lives > 1) {
				lives -= 1;
			}
			else {

				if (playerNumber != bulletNumber)
				{
					audio.PlayOneShot(DeadSound);
					levelManager.gotKill((int)bulletNumber);
					levelManager.Revive(playerNumber);
					anim.SetTrigger("Die");
					disablePlayer();
				}	
			}
		}	
	}
	void Update() 
	{

	}


	private void Die() {
		DestroyObject (gameObject);
	}

	

	public int getPlayerNumber () {
		Debug.Log (this.playerNumber);
		return this.playerNumber;
	}
	public void setPlayerNum (int playerNum) {
		shootingManager.playerNumber = playerNum;
		playerController.playerNumber = playerNum;
		playerNumber = playerNum;
	}
	
	private void disablePlayer() {
		shootingManager.Disable();
		playerController.Disable();
	}

	private void EnablePlayer() {
		shootingManager.Enable();
		playerController.Enable();
		anim.SetBool ("Revivng", false);
	}
	public void addKill() 
	{
		kills++;
		playerKillingSpree.text = String.Format("X{0}",kills);
	}

	public bool isDead()
	{
		return Dead;
	}
}
