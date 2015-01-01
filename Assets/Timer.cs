using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float startTime; 
	private float elapsedTime;
	private float passedTime;
	private int gameTime;

	private bool soundplaying = false;

	public AudioClip TenLastSec;

	void Awake(){ 
		startTime = 0; 
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Timer is called by: " + gameObject.name);
		gameTime = GameObject.Find("LevelManager").GetComponent<LevelManager>().Game_Time;
		soundplaying = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (startTime >= 0 && GameObject.Find("LevelManager").GetComponent<LevelManager>().gameStarted)
		{
			elapsedTime = (int)(Time.time - startTime);
			passedTime = (gameTime - Time.time + startTime);
			Debug.Log ("Gametime is: " + gameTime + " and elapsed time is: " + elapsedTime);
			if ((int)(gameTime - elapsedTime) < 10) {
				if(!soundplaying) {	audio.PlayOneShot(TenLastSec); Debug.Log ("here"); soundplaying = true;}

			}
		}
	}
	void OnTriggerEnter(){ startTime = Time.time; }
	
	void OnTriggerExit(){ startTime = 0; elapsedTime = 0; passedTime = 0; }
	
	void OnGUI(){
		int textNum = (int)(gameTime - elapsedTime);
		string text = textNum.ToString();
		GUI.Label(new Rect(380, 50, 100, 20), 
				(text));
	} 
}
