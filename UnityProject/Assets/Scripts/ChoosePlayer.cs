using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour {

	[SerializeField]
	NetworkManager manager;

	[SerializeField]
	Canvas canvasObject;

	[SerializeField]
	GameObject sciencePark;

	[SerializeField]
	GameObject InstructionMenu;

	[SerializeField]
	Button MechanicalButton;

	[SerializeField]
	Button SoftwareButton;

	[SerializeField]
	Button ElectricalButton;

	[SerializeField]
	GameObject myCameraObject;

	[SerializeField]
	InputField myInput;

	[SerializeField]
	GameObject choosePlayer;

	[SerializeField]
	GameObject softwarePrefab;

	[SerializeField]
	GameObject mechanicalPrefab;

	[SerializeField]
	GameObject electricalPrefab;

	Camera myCamera;
	Canvas myCanvas;

	// Use this for initialization
	void Start () {
		myCamera = myCameraObject.transform.GetComponent<Camera> ();
		myCanvas = canvasObject.GetComponent<Canvas> ();

		MechanicalButton.GetComponent<Button> ().onClick.RemoveAllListeners ();
		SoftwareButton.GetComponent<Button> ().onClick.RemoveAllListeners ();
		ElectricalButton.GetComponent<Button> ().onClick.RemoveAllListeners ();

		MechanicalButton.GetComponent<Button> ().onClick.AddListener (mechanicalOnClick);
		SoftwareButton.GetComponent<Button> ().onClick.AddListener (softwareOnClick);
		ElectricalButton.GetComponent<Button> ().onClick.AddListener (electricalOnClick);
	}

	//attach player prefabs here
	void mechanicalOnClick(){
		manager.playerPrefab = mechanicalPrefab;
		startGame();
	}

	void softwareOnClick(){
		manager.playerPrefab = softwarePrefab;
		startGame ();
	}

	void electricalOnClick(){
		manager.playerPrefab = electricalPrefab;
		startGame ();
	}
		
	void startGame(){
		if (JoinGame.isJoin) {
			JoinGame.isJoin = false;
			joinTheGame ();
		}
		if (MenuStart.isHost) {
			MenuStart.isHost = false;
			hostTheGame ();
		}
	}

	void joinTheGame(){
		manager.networkPort = 7777;
		manager.networkAddress = myInput.text;
		manager.StartClient ();
		myCamera.enabled = false;
		myCanvas.enabled = false;
	}

	void hostTheGame(){
		myCamera.enabled = false;
		myCanvas.enabled = false;
		manager.networkAddress = Network.player.ipAddress;
		manager.StartHost();
	}

	// Update is called once per frame
	void Update () {
		choosePlayer.transform.Find ("SoftwareScientist").Rotate(0, 50*Time.deltaTime, 0);
		choosePlayer.transform.Find ("ElectricalEngineer").Rotate(0, 50*Time.deltaTime, 0);
		choosePlayer.transform.Find ("MechanicalEngineer").Rotate(0, 50*Time.deltaTime, 0);

	}
}
