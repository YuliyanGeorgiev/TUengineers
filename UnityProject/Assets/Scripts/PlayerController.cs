/* PlayerController.cs
 * D.J.C.P. Hiemstra
 * 21-11-17
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody rb;
	[SerializeField]
	float speed,
	rotSpeed,
	acceleration,
	jumpForce;
	Vector3 velocity;
	bool grounded;

	void Start () {
		rb = transform.GetComponent<Rigidbody>();
	}


	void Update () {
		grounded = Physics.Raycast(transform.position, -transform.up, 1);
		velocity = Vector3.zero;
		if(Input.GetKey(KeyCode.W)) {
			velocity += transform.forward * speed;
		}
		if(Input.GetKey(KeyCode.S)) {
			velocity -= transform.forward * speed;
		}
		if(Input.GetKey(KeyCode.A)) {
			velocity -= transform.right * speed;
		}
		if(Input.GetKey(KeyCode.D)) {
			velocity += transform.right * speed;
		}
		if(Input.GetKey(KeyCode.Space)) {
			velocity += transform.up * jumpForce;
		}
	}

	void FixedUpdate () {
		if(grounded) {
			rb.velocity = Vector3.Lerp(rb.velocity, velocity, acceleration);
		}
		rb.velocity = Vector3.Lerp(rb.velocity, velocity, acceleration);
		transform.Rotate(transform.up * Input.GetAxis("Mouse X") * rotSpeed);
	}
}
