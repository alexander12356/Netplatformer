﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkStartServer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NetworkManager.singleton.StartServer ();
	}
}
