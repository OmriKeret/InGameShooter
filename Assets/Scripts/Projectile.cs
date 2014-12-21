using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	void OnTriggerEnter (Collider col)
	{
		Debug.Log ("hit!");
		DestroyObject (gameObject);
	}
	void OnCollisionEnter2D(Collision2D collided) {
			Debug.Log ("destory!");
			DestroyObject (gameObject);

	//	if (collided.gameObject.tag == "Player") {
	//		DestroyObject (gameObject);
	//	}
	}
	void Start () {
		switch (shootingManager.ShotType) {
		case 1:
			Debug.Log ("Archer!");//Should be animated differently
			//change object look, how? Get the instance of the object from
			//shootingManager and alternate it as need be, or get a message?
			break;
		case 2:
			Debug.Log ("Rogue!");
			break;
		case 3:
			Debug.Log ("Warrior!");
			break;
		case 4:
			Debug.Log ("Wizard!");
			break;
		default:
			break;
				}
	}
	//public float movementSpeed = 1;
	// Update is called once per frame
	void Update () {
		//if (true){
		//
		//}
	}


		}
				
	
	

