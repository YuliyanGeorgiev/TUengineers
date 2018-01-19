using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour {

	[SerializeField]
	NetworkManager manager;

	[SerializeField]
	Button hostButton;

	[SerializeField]
	GameObject sciencePark;

	[SerializeField]
	GameObject InstructionMenu;

	[SerializeField]
	Canvas canvasObject;

	Canvas myCanvas;
	public static bool isHost = false;
	// Use this for initialization
	void Start () {
		Button btn = hostButton.GetComponent<Button> ();
		myCanvas = canvasObject.GetComponent<Canvas> ();
		btn.onClick.RemoveAllListeners ();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick (){
		disableCanvasComponents();
		isHost = true;
		sciencePark.GetComponent<MeshRenderer>().enabled = false;
		InstructionMenu.GetComponent<MeshRenderer>().enabled = false;
	}

	//make the unwanted components invisible by turning them 90 degrees
	void disableCanvasComponents(){
		myCanvas.transform.Find ("Join Button").Rotate (0, 90, 0);
		myCanvas.transform.Find ("Host Button").Rotate (0, 90, 0);
		myCanvas.transform.Find ("Instructions Button").Rotate (0, 90, 0);
		myCanvas.transform.Find ("Exit Button").Rotate (0, 90, 0);
		myCanvas.transform.Find ("InputField").Rotate (0, 90, 0);
		myCanvas.transform.Find ("Image").Rotate (0, 90, 0);
		myCanvas.transform.Find ("Mechanical Engineer").Rotate (0, 90, 0);
		myCanvas.transform.Find ("Software Engineer").Rotate (0, 90, 0);
		myCanvas.transform.Find ("Electrical engineer").Rotate (0, 90, 0);
	}
}
