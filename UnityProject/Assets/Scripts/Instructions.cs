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

	// Use this for initialization
	void Start () {
		Button btn = instructionButton.GetComponent<Button> ();
		btn.onClick.RemoveAllListeners ();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick (){
		canvasObject.GetComponent<Canvas>().enabled = false;
		sciencePark.GetComponent<MeshRenderer>().enabled = false;
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape) && InstructionMenu.GetComponent<MeshRenderer>().isVisible) {
			canvasObject.GetComponent<Canvas>().enabled = true;
			sciencePark.GetComponent<MeshRenderer> ().enabled = true;
		}
	}
}
