using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	public int MovieTime;
	public AudioClip EndOfMovie;
	public AudioClip StartOfMovie;

	public Animator animation;

	// Use this for initialization
	void Start () {
		//audio.PlayOneShot(StartOfMovie);
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.anyKey) || (Time.time >= MovieTime)) {
			Stop ();
		}
		//if (Time.time >= MovieTime) {
		//	Stop ();
	//}

	}
	private void Stop() {
		//audio.PlayOneShot (EndOfMovie);
		animation.StopPlayback();
		//audio.Stop ();
		this.StopAllCoroutines();
		Application.LoadLevel ("MainMenu");
	}
}
