using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	[SerializeField]
	Transform target;
	[SerializeField]
	float responsiveness,
	distance;
	Vector3 targetpos;

	void Start () {
		transform.parent = null;
		targetpos = transform.position - target.transform.position;
	}
	

	void FixedUpdate () {
		transform.position = Vector3.Lerp(transform.position, target.transform.position, responsiveness);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, responsiveness);
	}
}
