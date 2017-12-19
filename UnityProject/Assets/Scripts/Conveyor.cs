/* Conveyor.cs
 * D.J.C.P. Hiemstra
 * Based on ConvayerBelt.cs by Yuliyan Georgiev
 * 9-12-17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Conveyor : NetworkBehaviour {
	[SerializeField]
	Transform[] wheels;

	List<Transform> products = new List<Transform>(); //a list of everything that lies on the conveyor
	[SyncVar]
	float speed;

	void Update () {
		foreach(Transform product in products) {
			product.position += speed * transform.right * Time.deltaTime; // move every product in the products list (negative speed to reverse direction, Time.deltaTime to have same movement speed for different fps)
		}

		foreach(Transform wheel in wheels) {
			wheel.transform.Rotate(transform.up*speed*Time.deltaTime*30);
		}
	}

	void OnTriggerEnter(Collider c) { // if something enters the trigger collider of the conveyor, it gets added to the products list
		if(!products.Contains(c.transform)){
			products.Add(c.transform);
		}
	}

	void OnTriggerExit(Collider c) { // remove product from the list if it leaves the conveyor trigger
		products.Remove(c.transform);
	}

	public void SetSpeed (float newSpeed) {
		if(isServer) {
			speed = newSpeed;
		}
	}
}
