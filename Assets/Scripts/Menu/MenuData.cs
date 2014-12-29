using UnityEngine;
using System.Collections;

public class MenuData : MonoBehaviour {
	public int howManyPlayers;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	public void twoPlayers()
	{
		howManyPlayers = 2;
		Application.LoadLevel("PickPlayerScene");
	}

	public void threePlayers()
	{
		howManyPlayers = 3;
		Application.LoadLevel("PickPlayerScene");
	}

	public void fourPlayers()
	{
		howManyPlayers = 4;
		Application.LoadLevel("PickPlayerScene");
	}
}
