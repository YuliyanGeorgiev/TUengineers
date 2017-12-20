using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDeactivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c) {
		if(c.transform.tag == "Turret") {
			c.transform.GetComponent<Turret>().health = 0;
		}
	}
}
