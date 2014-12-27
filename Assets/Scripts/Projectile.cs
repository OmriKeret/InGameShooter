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
}
				
	
	

