using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerActivator : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if(isLocalPlayer) {
			transform.GetComponent<PlayerController>().enabled = true;
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
