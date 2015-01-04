using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.anyKey) || (!audio.isPlaying) || Time.time >= 15) {
			Debug.Log ("Movie scene ends now.");
			Application.LoadLevel ("MainMenu");
			DestroyObject (gameObject);


		}
		//if (Time.time >= 16) {
		//	Application.LoadLevel ("MainMenu");
		//}

	}
}
