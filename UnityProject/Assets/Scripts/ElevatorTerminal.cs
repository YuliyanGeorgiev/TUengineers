/* ConveyorTerminal.cs
 * D.J.C.P. Hiemstra
 * Based on ConvayerBelt.cs by Yuliyan Georgiev
 * 9-12-17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorTerminal : MonoBehaviour, IInteractiveObject {
	[SerializeField]
	InputField userInput;
	Transform playerTransform;
	float speed;
	[SerializeField]
	Elevator elevator;
	bool interacting;
    public Text compileResult;

	void Update () {
		if(Input.GetKey(KeyCode.Escape) && interacting) { //always possible needs to change?
			Release();
		}

		//----------------------Controller---------------------//
		 
		elevator.SetSpeed(speed);
	}

	public void Compile() {
		if(!float.TryParse(userInput.text, out speed)) { //tryparse returns true if input is a number and changes the time variable
			Debug.Log("Compile Error");
            SetFail();
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

    private void SetSuccess()
    {
        compileResult.text = "SUCCESS";
        compileResult.color = Color.green;
    }

    private void SetFail()
    {
        compileResult.text = "ERROR";
        compileResult.color = Color.red;
    }
}
