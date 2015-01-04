using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		audio.PlayDelayed (2f);
	}
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	public void fadeOut(){
		audio.volume -= 1 * Time.deltaTime;
	
	}
}
