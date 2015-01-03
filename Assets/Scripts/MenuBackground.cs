using UnityEngine;
using System.Collections;

public class MenuBackground : MonoBehaviour {

	public UIManagerScrit UIManager;
	// Use this for initialization
	void Start () {
		UIManager = GameObject.Find("UIManager").GetComponent<UIManagerScrit>();
	}

	private void MenuEntered()
	{
		UIManager.MenuEntered ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
