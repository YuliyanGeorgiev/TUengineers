using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {



	[SerializeField]
	Button instructionButton;

	[SerializeField]
	Canvas canvasObject;

	[SerializeField]
	GameObject sciencePark;

	[SerializeField]
	GameObject InstructionMenu;

	public static bool setBool;

	// Use this for initialization
	void Start () {
		Button btn = instructionButton.GetComponent<Button> ();
		setBool = false;
		btn.onClick.RemoveAllListeners ();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick (){
		canvasObject.GetComponent<Canvas>().enabled = false;
		sciencePark.GetComponent<MeshRenderer>().enabled = false;
		setBool = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape) && setBool) {
			canvasObject.GetComponent<Canvas>().enabled = true;
			sciencePark.GetComponent<MeshRenderer> ().enabled = true;
			setBool = false;
		}
	}
}
