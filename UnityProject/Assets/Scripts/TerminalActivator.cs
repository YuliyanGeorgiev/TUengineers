using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalActivator : MonoBehaviour {

    public GameObject main;
    public GameObject terminal;
    Camera mainCam;
    Camera termCAm;
    public GameObject bullet;
    public Transform bulletSpawn;
    private float fireRate;
    private float nextFire;

    private void Start()
    {
        mainCam = main.GetComponent<Camera>();
        termCAm = terminal.GetComponent<Camera>();
        fireRate = 0.25f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            mainCam.enabled = true;
            termCAm.enabled = false;
        }
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    private void OnMouseDown()
    {
        mainCam.enabled = false;
        termCAm.enabled = true;
    }
}
