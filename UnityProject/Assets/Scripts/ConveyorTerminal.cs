/* ConveyorTerminal.cs
 * D.J.C.P. Hiemstra
 * Based on ConvayerBelt.cs by Yuliyan Georgiev
 * 9-12-17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorTerminal : MonoBehaviour, IInteractiveObject {
	[SerializeField]
	InputField userDir1, userDir2, userTime;
	Transform playerTransform;
	float t;
	float speed1;
	float speed2;
	float time;
	[SerializeField]
	Conveyor conveyor;
	bool interacting;

	void Update () {
		Compile();
		if(Input.GetKey(KeyCode.Escape) && interacting) { //always possible needs to change?
			Release();
		}

		//----------------------Controller---------------------//
		if(t > time) {
			t = 0;
		}
		if(t < time/2) {
			conveyor.SetSpeed(speed1);
		}
		if(t > time/2) {
			conveyor.SetSpeed(speed2);
		}
		t+= Time.deltaTime;
	}

	public void Compile() {
		//time = userTime.text;
		if(!float.TryParse(userTime.text, out time)) { //tryparse returns true if input is a number and changes the time variable
			//Doesn't compile!
		}

		if(userDir1.text.Equals("Left")) {
			speed1 = -1;
		} else if(userDir1.text.Equals("Right")) {
			speed1 = 1;
		} else {
			//Doesn't compile!
		}

		if(userDir2.text.Equals("Left")) {
			speed2 = -1;
		} else if(userDir2.text.Equals("Right")) {
			speed2 = 1;
		} else {
			//Doesn't compile!
		}
	}

	public void Interact(Transform player) {
		playerTransform = player;
		playerTransform.GetComponent<PlayerController>().enabled = false; // disable playerController
		playerTransform.GetComponent<PlayerVars>().playerCamera.enabled = false; // disable player camera
		this.transform.GetChild(0).gameObject.SetActive(true); // enable terminal camera and input field
		interacting = true;
	}

	public void Release() {
		playerTransform.GetComponent<PlayerController>().enabled = true; // enable playerController
		playerTransform.GetComponent<PlayerVars>().playerCamera.enabled = true; // enable player camera
		this.transform.GetChild(0).gameObject.SetActive(false); // disable terminal camera and input field
		interacting = false;
	}
}
