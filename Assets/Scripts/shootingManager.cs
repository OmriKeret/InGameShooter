using UnityEngine;
using System.Collections;

public class shootingManager : MonoBehaviour {

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
	public Direction direction = Direction.up_right;
	public int bulletSpeed = 1000;
	public static int ShotType = 1;

	public Collider2D playerCollider;
	public Collider2D bulletCollider;
	private float bulletWidth;
	private float bulletHeight;
	private float PlayerHeight;
	private float PlayerWidth;
	private float nextFire;

	//animation - omri's addition
	Animator anim;
	bool shooting;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		ReloadTime = Time.time;
	
		PlayerWidth = playerCollider.bounds.size.x;
		PlayerHeight = playerCollider.bounds.size.y;
		bulletWidth = bulletCollider.bounds.size.x;
		bulletHeight = bulletCollider.bounds.size.y;

	}
	
	// Update is called once per frame
	//If given than a bool "shot fired" is given, then create the projectile.
	void Update () {
		if(Time.time - ReloadTime >= PauseTillReload)
		{
			if(bullets<bulletsAfterReload){
				bullets += 1;
				ReloadTime = Time.time; 
			}

		}
		if (Input.GetButtonDown("fire"))//NEED THE SCRIPT NAME
		{
			positionProjectileShootingPoint(Direction.right);
			if (bullets > 0 && nextFire <= 0)//If there are bullets
			{
				nextFire = 1;
				bullets -= 1;
				Rigidbody2D BulletInstance;
				BulletInstance = Instantiate(Bullet, ProjectileShootingPoint.position, Quaternion.identity)  as Rigidbody2D;

				fireByDirection (direction ,1 ,BulletInstance);
				
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


	void fireByDirection (Direction x, int y, Rigidbody2D BulletInstance) {
		//For each x, there will be a direction, for each y, there will
		// be a "type" of projectile.
		// For now, y always equals 1
		y = 1;

		switch (x)
		{
			case Direction.up://Top
				BulletInstance.AddForce (new Vector2 (0,1) * bulletSpeed);
				break;
			case Direction.down://Down
				BulletInstance.AddForce (new Vector2 (0,-1) * bulletSpeed);
				break;
			case Direction.right://Right
				Debug.Log ("shoot right");
				anim.SetTrigger("Shoot");
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


	void positionProjectileShootingPoint(Direction direction)
	{
		var playerCenter = transform.collider2D.bounds.center;

		switch (direction)
		{
		case Direction.up://Top
			ProjectileShootingPoint.position = new Vector2 ( playerCenter.x , (float)( PlayerHeight + PlayerHeight*0.5 + bulletHeight + playerCenter.y) );
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




		
		
		

}
