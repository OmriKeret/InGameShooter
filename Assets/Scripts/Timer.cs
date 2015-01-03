using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float startTime; 
	private float elapsedTime;
	private float passedTime;

	private int textNum;
	private string text;

	//public GUIText guitext = gameObject.GUIText;
	//private int gameTime;

	private bool soundplaying = false;
	public int GameTime;
	
	private bool gameStarted = false;

	void Awake(){ 
		startTime = 0; 
	
	}
	//public void Reset() {
	//	startTime = Time.time;
	//}
	// Use this for initialization
	void Start () {
		soundplaying = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "Dash scene" && !gameStarted) {
			gameStarted = true;
			startTime = Time.time;
				}
		//Game Ended
		 if ((Time.time >= GameTime + startTime) && gameStarted) {
			Application.LoadLevel ("EndGame");
			//this.StopAllCoroutines ();
			Reset ();
		}
		 
		//Game running
		if (startTime >= 0 && gameStarted) {
			elapsedTime = (int)(Time.time - startTime);
			passedTime = (GameTime - Time.time + startTime);
			if ((int)(GameTime - elapsedTime) <= 10/* && ((int)GameTime - elapsedTime > 0)*/) {
				if (!soundplaying) {
					audio.Play ();
					soundplaying = true;
				}

			}



		}

				
	}
	void OnTriggerEnter(){ }
	
	void OnTriggerExit(){ }
	
	void OnGUI(){
		if (gameStarted) {
			int textNum = (int)(GameTime - elapsedTime);
			text = textNum.ToString ();
			GUI.Label (new Rect (380, 50, 100, 20), 
			(text));
			//guiText.text = text;
		}
	} 

	public void Reset () {
		startTime = 0;
		elapsedTime = 0;
		passedTime = 0;
		soundplaying = false;
		gameStarted = false;
		audio.Stop ();
		startTime = Time.time;

	}
}
