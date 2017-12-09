/* Elevator.cs
 * D.J.C.P. Hiemstra
 * Based on Elevator.cs by Yuliyan Georgiev
 * 9-12-17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour {
	float speed;
	[SerializeField]
	Rigidbody rb;

    void FixedUpdate() {
		//rb.MovePosition(rb.transform.position + rb.transform.up * -speed * 10000);
		rb.velocity = rb.transform.forward * speed;
    }

    public void SetSpeed(float newSpeed) {
		speed = newSpeed;
    }
}
