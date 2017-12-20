using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c) {
		c.transform.parent = this.transform;
	}

	void OnTriggerExit(Collider c) {
		c.transform.parent = null;
	}
}
