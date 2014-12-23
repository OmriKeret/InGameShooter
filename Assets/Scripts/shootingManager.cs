using UnityEngine;
using System.Collections;
using System;

public class shootingManager : MonoBehaviour {
	public int playerNumber;
	public AudioClip shotSound;
	public AudioClip reloadSound;
	public AudioClip clickSound; // optional "no bullets" click sound
	public int bullets = 5; // how many bullets you have
	public int bulletsAfterReload = 5;
	public float reloadTime = 0.2f; // reload time in seconPlayds
	public Rigidbody2D Bullet;
	public Transform ProjectileShootingPoint;
	public bool reloading = false; //True while reloading.
	public double ReloadTime;
	public float fireRate = 6f;
	public float PauseTillReload = 1.8f;
	public Direction direction = Direction.right;
	public int bulletSpeed = 1000;
	public static int ShotType = 1;

	public Collider2D playerCollider;
	public Collider2D bulletCollider;
	private float bulletWidth;
	private float bulletHeight;
	private float PlayerHeight;
	private float PlayerWidth;
	private float nextFire;

	private PlayerController playerControls;
	//geting input
	public bool up;
	public bool down;
	public bool left;
	public bool right;
	//animation - omri's addition
	Animator anim;
	bool shooting;
	Direction whichDirectionToAnimate;
	Direction whichDirectionToShoot;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerControls = GetComponent<PlayerController> ();
		ReloadTime = Time.time;
	
		PlayerWidth = playerCollider.bounds.size.x;
		PlayerHeight = playerCollider.bounds.size.y;
		bulletWidth = bulletCollider.bounds.size.x;
		bulletHeight = bulletCollider.bounds.size.y;

	}
	void FixedUpdate() {

		if(Time.time - ReloadTime >= PauseTillReload)
		{
			if(bullets<bulletsAfterReload){
				bullets += 1;
				ReloadTime = Time.time; 
			}
			
		}
		if (Input.GetButtonDown("fire" + playerNumber))//NEED THE SCRIPT NAME
		{

			positionProjectileShootingPoint(whichDirectionToShoot);
			if (bullets > 0 && nextFire <= 0)//If there are bullets
			{
				nextFire = 1;
				bullets -= 1;
				Rigidbody2D BulletInstance;
				BulletInstance = Instantiate(Bullet, ProjectileShootingPoint.position, Quaternion.identity)  as Rigidbody2D;
				if(! playerControls.faceRight) 
				{
					Flip (BulletInstance);
				}
				fireByDirection (whichDirectionToShoot ,BulletInstance);
				
				//BulletInstance.AddForce (BallSprite.right * 500);
				//GameObject.Destroy (BulletInstance, 4f); // TODO: Destroy on hit.
			}
			else //Out of Ammo
			{
				if(clickSound) //Empty sound?
				{
					audio.PlayOneShot(clickSound);
				}
			}
			nextFire = -1;
			//nextFire -= Time.deltaTime * fireRate;
			
		}

	}
	// Update is called once per frame
	//If given than a bool "shot fired" is given, then create the projectile.
	void Update () {
		whichDirectionToShoot = whichDirToShoot();
		up = Input.GetButton("up" + playerNumber);
		down = Input.GetButton ("down1");
		left = Input.GetButton("left" + playerNumber);
		right = Input.GetButton ("right" + playerNumber);	
	}


	void fireByDirection (Direction x, Rigidbody2D BulletInstance) {
		//For each x, there will be a direction, for each y, there will
		// be a "type" of projectile.
		// For now, y always equals 1

		var dirName =  getDirName(whichDirToAnimate(x));
		anim.SetTrigger("Shoot_" + dirName);
		switch (x)
		{
			case Direction.up://Top
				BulletInstance.AddForce (new Vector2 (0,1) * bulletSpeed);
				break;
			case Direction.down://Downs
				BulletInstance.AddForce (new Vector2 (0,-1) * bulletSpeed);
				break;
			case Direction.right://Right
				Debug.Log ("shoot right");
				BulletInstance.AddForce (new Vector2 (1,0) * bulletSpeed );
				break;
			case Direction.left: //Left
				BulletInstance.AddForce (new Vector2 (-1,0) * bulletSpeed);
				break;
			case Direction.up_right://Top-Right
	            BulletInstance.AddForce (new Vector2 (1,1) * bulletSpeed);
				Debug.Log ("shoot up-righ");
				break;
			case Direction.up_left://Top-Left
				BulletInstance.AddForce (new Vector2 (-1,1) * bulletSpeed);
				break;
			case Direction.down_right://Down-Right
				BulletInstance.AddForce (new Vector2 (1,-1) * bulletSpeed);
				break;
			case Direction.down_left://Down-Left
				BulletInstance.AddForce (new Vector2 (-1,-1) * bulletSpeed);
				break;

			default:
				break;
		}
	}


	void positionProjectileShootingPoint(Direction direction)
	{
		var playerCenter = transform.collider2D.bounds.center;

		switch (direction)
		{
		case Direction.up://Top
			ProjectileShootingPoint.position = new Vector2 ( playerCenter.x , (float)( PlayerHeight + bulletHeight + playerCenter.y) );
			break;
		/*case Direction.down://Down
			BulletInstance.AddForce (new Vector2 (0,-1) * bulletSpeed);
			break;
		case Direction.right://Right
			Debug.Log ("shoot righ");
			BulletInstance.AddForce (new Vector2 (1,0) * bulletSpeed);
			break;
		case Direction.left: //Left
			BulletInstance.AddForce (new Vector2 (-1,0) * bulletSpeed);
			break;
		case Direction.up_right://Top-Right
			BulletInstance.AddForce (new Vector2 (1,1) * bulletSpeed);
			Debug.Log ("shoot up-righ");
			break;
		case Direction.up_left://Top-Left
			BulletInstance.AddForce (new Vector2 (-1,1) * bulletSpeed);
			break;
		case Direction.down_right://Down-Right
			BulletInstance.AddForce (new Vector2 (1,-1) * bulletSpeed);
			break;
		case Direction.down_left://Down-Left
			BulletInstance.AddForce (new Vector2 (-1,-1) * bulletSpeed);
			break;
	*/
		default:
			break;
		}
	}


	private string getDirName(Direction x) {
		if( (int)x != 4 && (int)x != 8 )
			return  Enum.GetName(typeof(Direction), x);
		if( (int)x ==4 )
			return "right";
		if ((int)x == 8)
			return "down_right";
		return null;
	}

/*	private void moveHorizontal(Rigidbody2D bullet) {
		float move = Input.GetAxis ("Horizontal" + playerNumber);
		if (move > 0 && !faceRight)
			Flip (bullet);
		else if (move < 0 && faceRight)
			Flip (bullet);
	}*/
	void Flip(Rigidbody2D bullet)
	{
		Vector3 theScale = bullet.transform.localScale;
		theScale.x *= -1;
		bullet.transform.localScale = theScale;
	}

	private Direction whichDirToAnimate(Direction dir)
		{
		if (dir == Direction.left)
						return Direction.right;
		if (dir == Direction.up_left)
						return Direction.up_right;
		if (dir == Direction.down_left)
						return Direction.down_right;
		return dir;
		}

	private Direction whichDirToShoot(){
		if(Input.GetButton("right" + playerNumber) && Input.GetButtonDown("down" + playerNumber) )
		{
			Debug.Log ("push down_right");
			if(Input.GetButton("down" + playerNumber)) 
			{
				Debug.Log ("push down_right");
				return Direction.down_right;
			}
			if(Input.GetButton("up" + playerNumber))
			{
				Debug.Log ("push right_up");
				return Direction.up_right;
			}
			return Direction.right;
		}
		if(Input.GetButton("left" + playerNumber))
		{
			if(Input.GetButton("down" + playerNumber)) 
			{
				Debug.Log ("push left_down");
				return Direction.down_left;
			}
			if(Input.GetButton("up" + playerNumber))
			{
				return Direction.up_left;
			}
			return Direction.left;
		}
		if(Input.GetButton("up" + playerNumber))
		{
			return Direction.up;
		}
		if(Input.GetButton("down" + playerNumber))
		{
			return Direction.down;
		}
		return playerControls.faceRight ? Direction.right : Direction.left;
	}
		
		
		

}
