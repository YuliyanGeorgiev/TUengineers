using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

	[SerializeField]
	Button ExitButton;


	Button btn;
	void Start () {
		btn = ExitButton.GetComponent<Button> ();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick(){
		Application.Quit ();
	}

}
