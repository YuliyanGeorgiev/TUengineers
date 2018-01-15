using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PickUp : MonoBehaviour, IInteractiveObject
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(Transform player)
    {
        transform.parent = player;
        transform.position = player.position + player.transform.forward;
        transform.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        transform.parent = null;
        transform.GetComponent<Rigidbody>().isKinematic = false;
    }
}