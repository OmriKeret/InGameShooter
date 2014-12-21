using UnityEngine;
using System.Collections;

public static class MultiClickInput {
	
	// Default time in seconds for which to detect double clicking of a key.
	public const float DefaultTimeThreshold = 0.5f;
	
	private static string _multiClickAnchorKey;
	private static float _multiClickAnchorTime;
	private static int _multiClickCount;
	
	public static void CancelMultiClick() {
		_multiClickAnchorKey = null;
	}
	
	public static int GetMultiClickKeyCount(string key, float timeThreshold) {
		if (Input.GetButtonDown(key)) {
			// Do we need to cancel the last multi-click operation for this key?
			if (_multiClickAnchorKey == key)
				if (Time.time - _multiClickAnchorTime > timeThreshold)
					CancelMultiClick();
			
			_multiClickAnchorTime = Time.time;
			
			// Has button been pressed for first time?
			if (_multiClickAnchorKey != key) {
				_multiClickAnchorKey = key;
				_multiClickCount = 1;
			}
			else {
				// Okay, so this is a multi-click operation!
				++_multiClickCount;
			}
			return _multiClickCount;
		}
		return 0;
	}
	
	public static int GetMultiClickKeyCount(string key) {
		return GetMultiClickKeyCount(key, DefaultTimeThreshold);
	}
	
	public static bool HasDoubleClickedKey(string key, float timeThreshold) {
		return GetMultiClickKeyCount(key, timeThreshold) == 2;
	}
	
	public static bool HasDoubleClickedKey(string key) {
		return HasDoubleClickedKey(key, DefaultTimeThreshold);
	}
	
}