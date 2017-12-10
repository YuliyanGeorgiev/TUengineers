using UnityEngine;

/*
 * @author Yuliyan Georgiev 
 * 10.12.2017
 * Turret behaviour script
 */
public class Turret : MonoBehaviour {

	public float rotSpeed;
    public int range = 15;
    //public float targetDistance;
    private LineRenderer line;
    public Transform mid;
    public Transform top;
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

	Vector3 direction;
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	void Update () {
        RaycastHit hit;
        //Vector3 forward = transform.TransformDirection(Vector3.forward) * range;
		if(target != null) { // so the turret rotates to the target before it checks if it can still see it. Improves tracking.
			direction = new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z);
		} else if(Time.time > stopSearchTime) {
			if(rotSpeed == 0) {
				direction = Quaternion.Euler(0,Time.deltaTime*100,0) * transform.forward;
			} else {
				direction = Quaternion.Euler(0,Time.deltaTime*rotSpeed,0) * laserOrigin.forward;
			}
		}




		lookRotation = Quaternion.LookRotation(direction);
		mid.rotation = lookRotation;

		if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, range)) {
			if(IsTarget(hit)) {
				stopSearchTime = Time.time + searchTime;
				target = hit.transform.gameObject;
				//targetDistance = hit.distance;
				//Debug.Log(target);
				Fire();
			} else {
				target = null; // Target is lost when the turret can't see it

			}
		}
		laser.SetPosition(1, new Vector3(0,0,hit.distance)); // Sets laser length. Too short don't know why!
		if(Time.time > muzzleFlashTime) {
			muzzleFlash.enabled = false;
		}
	}

	void Fire() {
		if(Time.time > nextFire) {
			nextFire = Time.time + fireRate; // Set time for the fire rate
			Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			muzzleFlash.enabled = true;
			muzzleFlashTime = Time.time + 0.1f;
		}
	}

    // Check if the target is valid
    bool IsTarget(RaycastHit hit) // Is this still needed?
    {
        return (hit.transform.tag == "Turret" || hit.transform.tag == "Player");
    }
}
