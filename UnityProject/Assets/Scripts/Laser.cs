using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	RaycastHit hit;
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast(transform.position, transform.forward, out hit, 500)) {
			this.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0,0,hit.distance)); // Sets laser length. Too short don't know why!
		}
	}
}
