using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	void Start () {
		Debug.Log(Network.player.ipAddress); //Test to see if it returns the correct local ip, needed for multiplayer later
	}

}
