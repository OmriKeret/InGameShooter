using UnityEngine;
using System.Collections;

public class DebugingGamePad : MonoBehaviour {
	public float Horizontal;
	public float Vertical;
	public bool right;
	public int playerNum;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Horizontal = Input.GetAxisRaw ("Horizontal4");
		Vertical = Input.GetAxis ("Vertical4");
		//right = Input.GetButtonDown("check");
	}
}
