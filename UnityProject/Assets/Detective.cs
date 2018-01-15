using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detective : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

		if(Physics.Raycast(transform.position, -1*transform.up, out hit, 0.2f))
        {
            Debug.Log(hit.transform.name);
        }
	}
}
