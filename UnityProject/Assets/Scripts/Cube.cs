using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IInteractiveObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact(Transform hand) {
		transform.GetComponent<Rigidbody>().isKinematic = true;
		transform.parent = hand.transform;
		transform.position = new Vector3(transform.position.x, hand.transform.position.y, transform.position.z);
		transform.rotation = hand.rotation;
	}

	public void Release() {
		transform.parent = null;
		transform.GetComponent<Rigidbody>().isKinematic = false;

	}
}
