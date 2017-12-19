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
    private Turret turretScript;
    private PlayerController playerScript;
	RaycastHit hit;

	private void Start() {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		Invoke("DestroyBullet", destroyAfterThisTime);
	}

	void Update() {
		if(Physics.Raycast(transform.position, transform.forward, out hit, 1)) { // 1 is test value, make larger if doesnt collide. Smaller if it explodes before collision
			Explode();
		}
	}
		

	public void Explode() {
		Destroy(this.gameObject); // add cool effect?
	}
}
