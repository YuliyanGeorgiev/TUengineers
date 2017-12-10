/* Bullet.cs
 * D.J.C.P. Hiemstra
 * Based on Mover.cs by Yuliyan Georgiev
 * 10-12-17
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField]
	float destroyAfterThisTime;
	public float speed;

	private void Start() {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		Invoke("DestroyBullet", destroyAfterThisTime);
	}

	private void OnCollisionEnter(Collision c) {
		DestroyBullet();
	}

	void DestroyBullet() {
		Destroy(gameObject);
	}
}
