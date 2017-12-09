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
	Transform rightHand,
	leftHand;
	[SerializeField]
	float speed,
	rotSpeed,
	acceleration,
	jumpForce;
	Vector3 velocity;
	bool grounded;
	Animator anim;
	GameObject holdingObject;
	RaycastHit hit;
	[SerializeField]
	Camera playerCamera;

	bool carry;
	bool run;

	void Start () {
		rb = transform.GetComponent<Rigidbody>();
		anim = transform.GetComponent<Animator>();
	}


	void Update () {
		//grounded = Physics.Raycast(transform.position + transform.up, -transform.up, 1f);
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
		if(velocity != Vector3.zero) { 
			run = true; //play run animation
		} else {
			run = false; //stop run animation
		}
		if(Input.GetKey(KeyCode.Space)) {
			if(grounded) {
				velocity += transform.up * jumpForce;
			}
		}

		carry = Input.GetKey(KeyCode.Mouse0); //carry = true if mousebutton is pressed

		anim.SetBool("run", run);
		anim.SetBool("carry", carry);

		if(carry && holdingObject==null) {
			if(Physics.Raycast((leftHand.position + rightHand.position)/2-transform.up, transform.forward, out hit, 0.1f)) {
				if(hit.transform.tag == "Interactive") {
					holdingObject = hit.transform.gameObject;
					holdingObject.transform.GetComponent<IInteractiveObject>().Interact(this.transform);
				}
			}
		}
		if(!carry && holdingObject!=null) {
			holdingObject.GetComponent<IInteractiveObject>().Release();
			holdingObject = null;
		}

	}

	void FixedUpdate () {
		grounded = Physics.Raycast(transform.position + transform.up, -transform.up, 1f);
		rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(velocity.x, rb.velocity.y + velocity.y, velocity.z), acceleration);
		transform.Rotate(transform.up * Input.GetAxis("Mouse X") * rotSpeed);
	}
}
