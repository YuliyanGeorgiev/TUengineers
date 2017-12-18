using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour {

	Canvas menuCanvas;

	Camera menuCamera;


	// Use this for initialization
	void Start () {
		menuCanvas = GameObject.Find ("Menu").transform.Find ("Canvas").GetComponent<Canvas> (); 	
		menuCamera = GameObject.Find ("Menu").transform.Find ("Camera").GetComponent<Camera> (); 	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)) {
			menuCanvas.enabled = true;
			menuCamera.enabled = true;
		}
	}
}
