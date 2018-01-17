using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalActivator : MonoBehaviour {

    public GameObject main;
    public GameObject terminal;
    Camera mainCam;
    Camera termCAm;
    private float fireRate;
    private float nextFire;
    public AudioSource start;

    private void Start()
    {
        start.Play();
        mainCam = main.GetComponent<Camera>();
        termCAm = terminal.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            mainCam.enabled = true;
            termCAm.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        mainCam.enabled = false;
        termCAm.enabled = true;
    }
}
