using UnityEngine;

/*
 * @author Yuliyan Georgiev 
 * 10.12.2017
 * Turret behaviour script
 */

public class Turret : MonoBehaviour {

    public int range = 15;
    public float targetDistance;
    private LineRenderer line;
    public Transform mid;
    public Transform top;
    public GameObject bulletSpawn;
    public GameObject bullet;
    public Rigidbody target;
    public float fireRate;
    private float nextFire;

	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	void Update () {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * range;

        if (Physics.Raycast(transform.position, forward, out hit, range) && IsTarget(hit) && Time.time > nextFire)
        {
            target = hit.rigidbody;

            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = lookRotation.eulerAngles;
            mid.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
            //top.rotation = Quaternion.Euler(rotation.x, 0f, 0f);

            nextFire = Time.time + fireRate; // Set time for the fire rate
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            targetDistance = hit.distance;
            Debug.Log(target);
        }
        Debug.DrawRay(transform.position, forward, Color.red);
	}

    // Check if the raget is valid
    bool IsTarget(RaycastHit hit)
    {
        return (hit.transform.tag == "Turret" || hit.transform.tag == "Player");
    }
}
