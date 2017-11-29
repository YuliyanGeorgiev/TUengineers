using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	[SerializeField]
	Transform upperTarget,
	lowerTarget;
	[SerializeField]
	float responsiveness,
	distance,
	mouseSensitivity;
	Vector3 targetPos;
	Quaternion targetRot;
	float interp;

	void Start () {
		transform.parent = null;
		interp = 0.5f;
	}

	void Update () {
		interp -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
		interp = Mathf.Clamp(interp, 0, 1);
	}

	void FixedUpdate () {
		targetPos = Vector3.Lerp(lowerTarget.position, upperTarget.position, interp);
		targetRot = Quaternion.Lerp(lowerTarget.rotation, upperTarget.rotation, interp);

		transform.position = Vector3.Lerp(transform.position, targetPos, responsiveness);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, responsiveness);
	}

}
