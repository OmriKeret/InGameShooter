﻿using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
