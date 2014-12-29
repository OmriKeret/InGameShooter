using UnityEngine;
using System.Collections;

public class GuiFollowPlayer : MonoBehaviour {

	private PlayerController playerController;
	private bool faceRight = true;
	// Use this for initialization
	void Start () {
		playerController = GetComponentInParent <PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	//	faceRight = playerController.faceRight;
	//	if(!faceRight)
	//	{
	//		Flip ();
	//	}

	}

	void Flip()
	{
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
