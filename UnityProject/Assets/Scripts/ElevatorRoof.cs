﻿using System.Collections;
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
			Destroy(c.transform.GetComponent<BoxCollider>());
			foreach(Transform child in c.transform.GetComponentsInChildren<Transform>()) {
				if(child.name == "Mid" || child.name == "Top" || child.name == "Base") {
					child.gameObject.AddComponent<Rigidbody>();
					child.gameObject.AddComponent<BoxCollider>();
					child.GetComponent<BoxCollider>().size*=0.5f;
					child.parent = null;
					child.gameObject.AddComponent<PickUp>();
					child.tag = "Interactive";
				}
			}
		}
	}

	void OnTriggerExit(Collider c) {
		c.transform.parent = null;
	}
}
