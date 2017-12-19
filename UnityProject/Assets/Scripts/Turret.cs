using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
 * @author Yuliyan Georgiev 
 * 10.12.2017
 * Turret behaviour script
 */

public class Turret : NetworkBehaviour {

	public float rotSpeed;
    public int range = 15;
    //public float targetDistance;
    private LineRenderer line;
	public GameObject mid;
	public GameObject top;
	public Transform laserOrigin;
    public GameObject bulletSpawn;
    public GameObject bullet;
	public GameObject target;
    public float fireRate;
    private float nextFire;
	[SerializeField]
	LineRenderer laser;
	Quaternion lookRotation;
	public float searchTime;
	float stopSearchTime;
	public Light muzzleFlash;
	float muzzleFlashTime;
    public int health;

	Vector3 midDirection;
	Vector3 topDirection;
	void Start () {
        health = 100;
        line = GetComponent<LineRenderer>();
	}
	
	void Update () {
        RaycastHit hit;
        //Vector3 forward = transform.TransformDirection(Vector3.forward) * range;
		if(target != null) { // so the turret rotates to the target before it checks if it can still see it. Improves tracking.
			midDirection = new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z);
			topDirection = new Vector3(target.transform.position.x - mid.transform.position.x , target.transform.position.y - laserOrigin.position.y, target.transform.position.z - mid.transform.position.z);
		} else if(Time.time > stopSearchTime) {
			if(rotSpeed == 0) {
				midDirection = Quaternion.Euler(0,Time.deltaTime*100,0) * transform.forward;
				topDirection = midDirection;
			} else {
				midDirection = Quaternion.Euler(0,Time.deltaTime*rotSpeed,0) * mid.transform.forward;
				topDirection = midDirection;
			}
		}




		lookRotation = Quaternion.LookRotation(midDirection);
		mid.transform.rotation = lookRotation;
		top.transform.rotation = Quaternion.LookRotation(topDirection);

		if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, range)) {
			if(IsTarget(hit)) {
				stopSearchTime = Time.time + searchTime;
				target = hit.transform.gameObject;
				//targetDistance = hit.distance;
				//Debug.Log(target);
				Fire(target);
			} else {
				target = null; // Target is lost when the turret can't see it

			}
		}
		laser.SetPosition(1, new Vector3(0,0,hit.distance)); // Sets laser length. Too short don't know why!
		if(Time.time > muzzleFlashTime) {
			muzzleFlash.enabled = false;
		}
	}

	void Fire(GameObject target) {
		if(Time.time > nextFire) {
			nextFire = Time.time + fireRate; // Set time for the fire rate
			GameObject spawnedBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation); // Maybe network instantiate?
			//NetworkServer.Spawn(spawnedBullet);
			RpcDoDamage(target);
			muzzleFlash.enabled = true;
			muzzleFlashTime = Time.time + 0.1f;


		}
	}

	[ClientRpc]
	public void RpcDoDamage(GameObject target) {
		if(target.tag=="Player") {
			target.transform.GetComponent<PlayerController>().TakeDamage();
		} else {
			target.transform.GetComponent<Turret>().TakeDamage(); // only other possibility is turret so no need to check tag
		}
	}

    // Check if the target is valid
    bool IsTarget(RaycastHit hit) // Is this still needed?
    {
        return (hit.transform.tag == "Turret" || hit.transform.tag == "Player");
    }

    public void TakeDamage()
    {
        if (health != 0)
        {
            health -= 10;
			top.transform.Rotate(0f, 0f, top.transform.rotation.z - 3);
        }
        else if (health == 0)
        {
            laser.enabled = false;
            GetComponent<Turret>().enabled = false;
        }
    }
}
