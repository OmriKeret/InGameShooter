using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	private float startTime; 
	private float elapsedTime;
	private float passedTime;
	
	private int textNum;
	private string text;
	
	private bool calledFadeOut;
	//public GUIText guitext = gameObject.GUIText;
	//private int gameTime;
	
	public int GameTime;
	
	private bool gameStarted = false;
	
	void Awake(){ 
		startTime = 0; 
		calledFadeOut = false;
	}	
	//public void Reset() {
	//	startTime = Time.time;
	//}
	// Use this for initialization
	void Start () {
		//soundplaying = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "Dash scene" && !gameStarted) {
			gameStarted = true;
			startTime = Time.time;
		}
		//Game Ended
		if ((Time.time >= GameTime + startTime) && gameStarted && !calledFadeOut) {
			calledFadeOut = true;
			AutoFade.LoadLevel ("EndGame", 8, 1, Color.black);
			gameObject.GetComponent<Text>().text = "";
			//this.StopAllCoroutines ();
			//Reset ();
			
			
			//GameObject.Find ("TimerText").GetComponent<Text>().text = text;
			//GUI.Label (new Rect (380, 50, 100, 20), 
			//          (text));
			//guiText.text = text;
			//return text;
			
			
			
		}
		
		
		//Game running
		if (startTime >= 0 && gameStarted) {
			elapsedTime = (int)(Time.time - startTime);
			passedTime = (GameTime - Time.time + startTime);
			//if ((int)(GameTime - elapsedTime) <= 10/* && ((int)GameTime - elapsedTime > 0)*/) {
			
			//if (!soundplaying) {
			//		audio.Play ();
			//		soundplaying = true;
			//}
			
			//}
			
			
			
		} 
		if (Application.loadedLevelName == "Dash scene" && gameStarted) {
			int textNum = (int)(GameTime - elapsedTime);
			text = textNum.ToString ();
			if(textNum < 0) {return;}
			gameObject.GetComponent<Text> ().text = text;
		}
		//if (Application.loadedLevelName != "Dash scene") {
		//DestroyObject(gameObject);
		//	}
	}
	
	//public string showTime(){
	//				
	//}
	
	
	//void OnTriggerEnter(){ }
	
	//void OnTriggerExit(){ }
	
	/*void OnGUI(){
		if (gameStarted) {
			int textNum = (int)(GameTime - elapsedTime);
			text = textNum.ToString ();
			GUI.Label (new Rect (380, 50, 100, 20), 
			(text));
			//guiText.text = text;
		}
	} */
	
	public void Reset () {
		startTime = 0;
		elapsedTime = 0;
		passedTime = 0;
		//soundplaying = false;
		gameStarted = false;
		audio.Stop ();
		startTime = Time.time;
		
	}
}
