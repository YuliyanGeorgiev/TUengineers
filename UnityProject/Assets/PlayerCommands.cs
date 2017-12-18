using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	[Command]
	public void CmdCompileConveyor(string input1, string input2, string input3, GameObject terminal) {
		//Compile();
		Debug.Log("RPC Test Server");
		terminal.GetComponent<ConveyorTerminal>().RpcCompile(input1, input2, input3);
		//terminal.GetComponent
	}
}
