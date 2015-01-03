using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	//public int MovieTime;
		//public AudioClip EndOfMovie;
	//public AudioClip StartOfMovie;

	//public Animator animation;

	// Use this for initialization
	void Start () {
		//startTime = (int)Time.time;
		//audio.PlayOneShot(StartOfMovie);
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.anyKey) || (!audio.isPlaying)) {
			Debug.Log ("Movie ends now.");
			Application.LoadLevel ("MainMenu");
		}
		//if (Time.time >= 2) {
		//	animation["animationn"].speed = 0;
		//		}
		//if (Time.time >= MovieTime) {
		//	Stop ();
	//}

	}
	private void Stop() {
		//audio.PlayOneShot (EndOfMovie);
		//animation.StopPlayback();
		//Animationn.StopPlayback ();
		//AnimatorOverrideController.Destroy ();
		//yield return new WaitForSeconds (2);
		//audio.Stop ();


	}
}
