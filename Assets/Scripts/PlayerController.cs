using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int playerNumber;
	// DASH parameters
	public float tapDelayBoost = 0.25f;
	public float boostForce = 800;
	private bool canBoost = true;
	public float boostCooldown = 2f;
	private bool isBoosting = false;
	public float boostDuration = 0.15f;


	//normal walking machanisem
	public float maxSpeed = 10f;
	private bool grounded = false;
	public bool faceRight = true;

	//jumping
	private bool doubleJumpeAvilable = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 500;
	public float doubleJumpForce = 300;

	//Animation
	Animator anim;
	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		if (!isBoosting) 
		{
			moveHorizontal ();
		}



	}

	void Update() 
	{


		if (grounded && Input.GetButtonDown ("Jump" + playerNumber) && !isBoosting )
		{
			anim.SetBool("Ground", false);
    			rigidbody2D.AddForce(new Vector2(0, jumpForce));
				doubleJumpeAvilable = true;
			//animation.SetBool("DoubleJump", false);
		} else if (!grounded && doubleJumpeAvilable && Input.GetButtonDown ("Jump" + playerNumber) && !isBoosting) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
 			rigidbody2D.AddForce(new Vector2(0, doubleJumpForce));
			doubleJumpeAvilable = false;
			//animation.SetBool("DoubleJump", true);
		}

		if(MultiClickInput.HasDoubleClickedKey("left" + playerNumber, tapDelayBoost) )
		{
			Dash();
		}
		if(MultiClickInput.HasDoubleClickedKey("right" + playerNumber, tapDelayBoost)  )
		{
			Dash();
		}
		leftScreen ();
	}


	//fliping  the char when moving left or right
	void Flip()
	{
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//calling dash if valid
	private void Dash() {
		if (grounded  && canBoost )
		{
			StartCoroutine(Boost()); //Start the Coroutine called "Boost", and feed it the time we want it to boost us
		}
	}

	//

	IEnumerator Boost() //Coroutine with a single input of a float called boostDur, which we can feed a number when calling
	{
		float time = 0f; //create float to store the time this coroutine is operating
		canBoost = false; //set canBoost to false so that we can't keep boosting while boosting
		float boostForceWithDir = faceRight ? boostForce : -boostForce;

		while(boostDuration > time) //we call this loop every frame while our custom boostDuration is a higher value than the "time" variable in this coroutine
		{
			time += Time.deltaTime; //Increase our "time" variable by the amount of time that it has been since the last update
			rigidbody2D.AddForce(new Vector2(boostForceWithDir ,0 ), ForceMode2D.Force);
			boostForceWithDir = boostForceWithDir/1.2f;
			yield return 0; //go to next frame
		}
		yield return new WaitForSeconds(boostCooldown); //Cooldown time for being able to boost again, if you'd like.
		canBoost = true; //set back to true so that we can boost again.
	}
	

	private void moveHorizontal() {
		float move = Input.GetAxis ("Horizontal" + playerNumber);
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		if (move > 0 && !faceRight)
			Flip ();
		else if (move < 0 && faceRight)
			Flip ();
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
