using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour {

	[SerializeField]
	NetworkManager manager;

	[SerializeField]
	GameObject myCameraObject;

	[SerializeField]
	Button hostButton;

	[SerializeField]
	Canvas canvasObject;

	Camera myCamera;
	Canvas myCanvas;
	// Use this for initialization
	void Start () {
		myCamera = myCameraObject.transform.GetComponent<Camera> ();
		Button btn = hostButton.GetComponent<Button> ();
		myCanvas = canvasObject.GetComponent<Canvas> ();
		btn.onClick.RemoveAllListeners ();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick (){
		myCamera.enabled = false;
		myCanvas.enabled = false;
		manager.networkAddress = Network.player.ipAddress;
		manager.StartHost();
	}

}
