using UnityEngine;
using System.Collections;

public class PlayerData  {
	public int howManyKills {
				get;
				set;
		}

	public int playerNum {
				get;
				set;
	}
	public CharacterType character {
				get;
				set;
		}

	public int killingSpree {
				get;
				set;
		}

	public int score {
		get;
		set;
	}

	public void reset()
	{
		score = 0;
		killingSpree = 0;
		howManyKills = 0;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
