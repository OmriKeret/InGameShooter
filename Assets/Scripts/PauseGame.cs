using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	private bool isOpen;
	private void pauseTime()
	{
		if(!isOpen)
		{
			Time.timeScale = 0F;
			isOpen = true;
		}

	}
	private void resumeTime()
	{
		isOpen = false;
	}
}
