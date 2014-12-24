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


	public int up_projectile_angles = 90;
	public int up_right_projectile_angles = 30;
	public int right_projectile_angles = 0;
	public int right_down_projectile_angles = 310;  
	public int down_projectile_angles = 270;
	public int down_left_projectile_angles = 310;
	public int left_projectile_angles = 0;
	public int left_up_projectile_angles = 30;


	public Collider2D playerCollider;
	public Collider2D bulletCollider;
	private float bulletWidth;
	private float bulletHeight;
	private float PlayerHeight;
	private float PlayerWidth;
	private float nextFire;

	private PlayerController playerControls;
	//geting input - omri's addition
	public bool up;
	public bool down;
	public bool left;
	public bool right;
	//animation 
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
	private void setShoot() 
	{
		shooting = true;
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
			if (bullets > 0 && nextFire <= 0)//If there are bullets
			{
				nextFire = 1;
				bullets -= 1;

				whichDirectionToShoot = whichDirToShoot();
				StartCoroutine(fireByDirection (whichDirectionToShoot));
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

	void Update () {

	}


	IEnumerator fireByDirection (Direction x) {
		var dirName =  getDirName(whichDirToAnimate(x));
		anim.SetTrigger("Shoot_" + dirName);

		while (!shooting) {
			yield return null;
		}
		Rigidbody2D BulletInstance;
		BulletInstance = Instantiate(Bullet, ProjectileShootingPoint.position, Quaternion.identity)  as Rigidbody2D;
		Physics2D.IgnoreCollision (BulletInstance.collider2D, transform.collider2D);
		if(! playerControls.faceRight) 
		{
			Flip (BulletInstance);
		}
		shooting = false;
		var angles = 0;
		switch (x)
		{

			case Direction.up://Top
				angles = playerControls.faceRight ? up_projectile_angles : -1 * up_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
				BulletInstance.AddForce (new Vector2 (0,1) * bulletSpeed);
				break;
			case Direction.down://Downs
				angles = playerControls.faceRight ? down_projectile_angles : -1 * down_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
				BulletInstance.AddForce (new Vector2 (0,-1) * bulletSpeed);
				break;
			case Direction.right://Right
				Debug.Log ("shoot right");
				angles = playerControls.faceRight ? right_projectile_angles : -1 * right_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
				BulletInstance.AddForce (new Vector2 (1,0) * bulletSpeed );
				break;
			case Direction.left: //Left
				angles = playerControls.faceRight ? left_projectile_angles : -1 * left_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
				BulletInstance.AddForce (new Vector2 (-1,0) * bulletSpeed);
				break;
			case Direction.up_right://Top-Right
				angles = playerControls.faceRight ? up_right_projectile_angles : -1 * up_right_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
	            BulletInstance.AddForce (new Vector2 (1,(float)0.5) * bulletSpeed);
				Debug.Log ("shoot up-righ");
				break;
			case Direction.up_left://Top-Left
				angles = playerControls.faceRight ? left_up_projectile_angles : -1 * left_up_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
				BulletInstance.AddForce (new Vector2 (-1,(float)0.5) * bulletSpeed);
				break;
			case Direction.down_right://Down-Right
				angles = playerControls.faceRight ? right_down_projectile_angles : -1 * right_down_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
				BulletInstance.AddForce (new Vector2 (1,-1) * bulletSpeed);
				break;
			case Direction.down_left://Down-Left
				angles = playerControls.faceRight ? down_left_projectile_angles : -1 * down_left_projectile_angles;
				BulletInstance.transform.rotation = Quaternion.AngleAxis(angles, Vector3.forward);
				BulletInstance.AddForce (new Vector2 (-1,-1) * bulletSpeed);
				break;

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
		right = Input.GetButton ("right" + playerNumber);
		left = Input.GetButton ("left" + playerNumber);
		up = Input.GetButton ("up" + playerNumber);
		down = Input.GetButton ("down" + playerNumber);

		if(right){
			return up ? Direction.up_right : down ? Direction.down_right : Direction.right;
		}
		if(left) {
			return up ? Direction.up_left : down ? Direction.down_left : Direction.left;
		}
		if(up){
			return Direction.up;
		}
		if(down){
			return Direction.down;
		}
		//if idle
		return playerControls.faceRight ? Direction.right : Direction.left;


	}
		

}



/*
	void positionProjectileShootingPoint(Direction direction)
	{
		var playerCenter = transform.collider2D.bounds.center;

		switch (direction)
		{
			//PlayerHeight  + playerCenter.y
		case Direction.right://Top
			ProjectileShootingPoint.position = new Vector2 ( playerCenter.x , bulletHeight );
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

		default:
			break;
		}
	}
*/
