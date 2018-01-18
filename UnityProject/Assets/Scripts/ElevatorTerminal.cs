/* ConveyorTerminal.cs
 * D.J.C.P. Hiemstra
 * Based on ConvayerBelt.cs by Yuliyan Georgiev
 * 9-12-17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ElevatorTerminal : NetworkBehaviour, IInteractiveObject {
	[SerializeField]
	InputField userInput;
	Transform playerTransform;
	float speed;
	[SerializeField]
	Elevator elevator;
	bool interacting;
	public Text compileResult;
    public AudioSource start;
    public AudioSource shut;

    void Update () {
		if(Input.GetKey(KeyCode.Escape) && interacting) { //always possible needs to change?
            start.Stop();
            shut.Play();
			Release();
		}

		//----------------------Controller---------------------//

		elevator.SetSpeed(speed);
	}

	public void Compile() {
		string CheckTime = userInput.text;
		char lastL = CheckTime[CheckTime.Length - 1];
		if (!(lastL.ToString() == ";" && float.TryParse(CheckTime.Remove(CheckTime.Length - 1), out speed)))
		{ //tryparse returns true if input is a number and changes the time variable
			Debug.Log("Compile Error");
			SetFail();
		}
		else SetSuccess();
	}

	public void NetworkCompile() {
		playerTransform.GetComponent<PlayerCommands>().CmdCompileElevator(userInput.text, this.gameObject);
	}

	[ClientRpc]
	public void RpcCompile(string input) {
		userInput.text = input;
		Debug.Log("RPC Test Client");
		Compile();
	}

	public void Interact(Transform player) {
        start.Play();
		playerTransform = player;
		playerTransform.GetComponent<PlayerController>().enabled = false; // disable playerController
		playerTransform.GetComponent<PlayerVars>().playerCamera.enabled = false; // disable player camera
		this.transform.GetChild(0).gameObject.SetActive(true); // enable terminal camera and input field
		interacting = true;
		playerTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void Release() {
		playerTransform.GetComponent<PlayerController>().enabled = true; // enable playerController
		playerTransform.GetComponent<PlayerVars>().playerCamera.enabled = true; // enable player camera
		this.transform.GetChild(0).gameObject.SetActive(false); // disable terminal camera and input field
		interacting = false;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
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
