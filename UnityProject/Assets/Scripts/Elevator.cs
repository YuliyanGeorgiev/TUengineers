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
	[SerializeField]
	float lowerheight, upperheight;
	GameObject platform;
	float speed;

	void Start () {
		platform = transform.Find("MovingPart").gameObject;
	}

	void Update () {
		platform.transform.position += platform.transform.forward*speed*Time.deltaTime;
		platform.transform.localPosition = new Vector3(platform.transform.localPosition.x, Mathf.Clamp(platform.transform.localPosition.y, lowerheight, upperheight), platform.transform.localPosition.z);
	}

    public void SetSpeed(float newSpeed) {
		speed = newSpeed;
    }
}
