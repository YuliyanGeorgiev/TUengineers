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

public class ConveyorTerminal : NetworkBehaviour, IInteractiveObject {
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
	public Text compileResult;

	void Start () {
		Compile(); // so it compiles the initial settings (words set in editor)
	}

	void Update () {
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

		if (CheckInput())
		{
			SetSuccess();
			SetValues();
		}
		else SetFail();

	}

	public void NetworkCompile() {
		if(Network.isServer) {
			RpcCompile(userDir1.text, userDir2.text, userTime.text);
		} else {
			CmdCompile(userDir1.text, userDir2.text, userTime.text);
			Debug.Log("ich bin client");
		}
	}

	[Command]
	public void CmdCompile(string input1, string input2, string input3) {
		userDir1.text = input1;
		userDir2.text = input2;
		userTime.text = input3;
		//Compile();
		Debug.Log("RPC Test Server");
		RpcCompile(input1, input2, input3);
	}

	[ClientRpc]
	public void RpcCompile(string input1, string input2, string input3) {
		userDir1.text = input1;
		userDir2.text = input2;
		userTime.text = input3;
		Debug.Log("RPC Test Client");
		Compile();
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

	private bool CheckUsrTime()
	{
		string CheckTime = userTime.text;
		char lastL = CheckTime[CheckTime.Length - 1];
		Debug.Log(CheckTime.Remove(CheckTime.Length - 1));
		Debug.Log(CheckTime[CheckTime.Length - 1]);
		return (lastL.ToString() == ";" && float.TryParse(CheckTime.Remove(CheckTime.Length - 1), out time));
	}

	private bool CheckInput()
	{
		return (CheckDir1() && CheckDir2() && CheckInputTime());
	}

	private bool CheckDir1()
	{
		return (userDir1.text.Equals("Right);") || userDir1.text.Equals("Left);"));
	}

	private bool CheckDir2()
	{
		return (userDir2.text.Equals("Right);") || userDir2.text.Equals("Left);"));
	}

	private bool CheckInputTime()
	{
		string CheckTime = userTime.text;
		char lastL = CheckTime[CheckTime.Length - 1];
		return (lastL.ToString() == ";" && float.TryParse(CheckTime.Remove(CheckTime.Length - 1), out time));
	}

	private void SetValues()
	{
		if (userDir1.text.Equals("Left);"))
		{
			speed1 = -1;

		}
		else if (userDir1.text.Equals("Right);"))
		{
			speed1 = 1;
		}

		if (userDir2.text.Equals("Left);"))
		{
			speed2 = -1;
		}
		else if (userDir2.text.Equals("Right);"))
		{
			speed2 = 1;
		}
	}

}
