using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	private int playerNumber;
	private float bulletNumber; 
	private bool Bullet_locked = false;
	private Animator anim;
	private PlayerManager playerManager;
	
	public Transform Blood_Hit;
	public Transform Broken_Arrow;
	
	public void SetBulletNumber (Vector2 V) {
		if (V.y == Time.time && !Bullet_locked) {//Same time frame in which it was created.
			bulletNumber = V.x;
			Bullet_locked = true;
		}
		
	}
	void Start () {
		
		anim = GetComponent<Animator> ();


	}
	void OnCollisionEnter2D(Collision2D collided) {
		if (collided.gameObject.tag != "Player") {
			anim.SetTrigger("break");
		}
		if (collided.gameObject.tag == "Player") {
			playerNumber = collided.gameObject.GetComponent<PlayerManager> ().getPlayerNumber();
			var isThisPlayerDead = collided.gameObject.GetComponent<PlayerManager> ().isDead();
			if (playerNumber != bulletNumber && !isThisPlayerDead) {
				anim.SetTrigger("hitPlayer");
				playerManager.addKill();
			}
		}
		if (collided.gameObject.tag == "Bullet") {
			anim.SetTrigger("break");

		}
		
	}
	public float getBulletNumber ()
	{
		return this.bulletNumber;
	}
	
	//public float movementSpeed = 1;
	// Update is called once per frame
	void Update () {
		leftScreen ();
	}
	
	private void leftScreen(){
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).x; 
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,dist)).y; 
		var buttomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).y; 
		// teleport me to the other side of the screen when I reach the edge
		if (transform.position.x > rightBorder) {
			transform.position = new Vector3 (leftBorder, transform.position.y, 0);
		}
		if (transform.position.x < leftBorder) {
			transform.position = new Vector3 (rightBorder, transform.position.y, 0);
		}
		// teleport me to the top or buttom
		if (transform.position.y > topBorder) {
			transform.position = new Vector3 (transform.position.x,buttomBorder, 0);
		}
		if (transform.position.y < buttomBorder) {
			transform.position = new Vector3 (transform.position.x, topBorder, 0);
		}
	}

	private void destoryObject()
	{
		DestroyObject (gameObject);
	}

	public void setPlayerManager(PlayerManager manager) 
	{
		playerManager = manager;
	}
}






