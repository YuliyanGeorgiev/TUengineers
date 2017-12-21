/* Elevator.cs
 * D.J.C.P. Hiemstra
 * Based on Elevator.cs by Yuliyan Georgiev
 * 9-12-17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Elevator : NetworkBehaviour {
	[SerializeField]
	float lowerheight, upperheight;
	GameObject platform;
	[SyncVar]
	float speed, height;

	void Start () {
		platform = transform.Find("MovingPart").gameObject;
	}

	void Update () {
		platform.transform.position += platform.transform.forward*speed*Time.deltaTime;
		height = Mathf.Clamp(platform.transform.localPosition.y, lowerheight, upperheight);
		platform.transform.localPosition = new Vector3(platform.transform.localPosition.x, height, platform.transform.localPosition.z);
	}

    public void SetSpeed(float newSpeed) {
		if(isServer) {
			speed = newSpeed/100;
		}
    }
}
