using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRoof : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c) {
		if(c.transform.tag == "Turret") {
			c.transform.GetComponent<Turret>().health = 0;
			foreach(Transform child in c.transform.GetComponentsInChildren<Transform>()) {
				child.gameObject.AddComponent<Rigidbody>();
				child.gameObject.AddComponent<BoxCollider>();
				child.parent = null;
			}
		}
	}

	void OnTriggerExit(Collider c) {
		c.transform.parent = null;
	}
}
