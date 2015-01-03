using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float startTime; 
	private float elapsedTime;
	private float passedTime;
	//private int gameTime;

	private bool soundplaying = false;
	public int GameTime;
	
	private bool gameStarted = false;

	void Awake(){ 
		startTime = 0; 
	
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Timer is called by: " + gameObject.name);
		//gameTime = GameObject.Find("LevelManager").GetComponent<LevelManager>().Game_Time;
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
			//elapsedTime = Time.time - startTime;
			Application.LoadLevel ("EndGame");
			this.StopAllCoroutines ();
			Reset ();
		}
		 

		if (startTime >= 0 && gameStarted) {
			elapsedTime = (int)(Time.time - startTime);
			passedTime = (GameTime - Time.time + startTime);
			//Debug.Log ("Gametime is: " + GameTime + " and elapsed time is: " + elapsedTime);
			if ((int)(GameTime - elapsedTime) < 10 && ((int)GameTime - elapsedTime > 0)) {
				if (!soundplaying) {
					audio.Play ();
					//Debug.Log ("here");
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
			string text = textNum.ToString ();
			GUI.Label (new Rect (380, 50, 100, 20), 
			(text));
		}
	} 
	void Reset () {
		startTime = 0;
		elapsedTime = 0;
		passedTime = 0;
		soundplaying = false;
		gameStarted = false;
		audio.Stop ();

	}
}
