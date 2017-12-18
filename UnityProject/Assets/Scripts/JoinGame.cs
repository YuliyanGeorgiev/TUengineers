using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinGame : MonoBehaviour {

	[SerializeField]
	NetworkManager manager;

	[SerializeField]
	GameObject myCameraObject;

	[SerializeField]
	Button joinButton;

	[SerializeField]
	Canvas canvasObject;

	[SerializeField]
	InputField myInput;

	Camera myCamera;
	Canvas myCanvas;
	Button btn;
	// Use this for initialization
	void Start () {
		myCamera = myCameraObject.transform.GetComponent<Camera> ();
		btn = joinButton.GetComponent<Button> ();
		myCanvas = canvasObject.GetComponent<Canvas> ();

		btn.onClick.RemoveAllListeners ();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick (){
		manager.networkPort = 7777;
		manager.networkAddress = myInput.text;
		manager.StartClient();
		myCamera.enabled = false;
		myCanvas.enabled = false;


	}

}
