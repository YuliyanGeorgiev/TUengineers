using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PickUp : NetworkBehaviour, IInteractiveObject
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
        //transform.parent = player;
        //transform.position = player.position + player.transform.forward;
        //transform.GetComponent<Rigidbody>().isKinematic = true;
		if(!isServer) {
			CmdPickUp(player.gameObject);
			Debug.Log("HelloClient");
		} else {
			RpcPickUp(player.gameObject);
			Debug.Log("helloserver");
		}
    }

	[Command]
	public void CmdPickUp(GameObject player) {
		RpcPickUp(player);
		transform.parent = player.transform;
		transform.position = player.transform.position + player.transform.forward;
		transform.GetComponent<Rigidbody>().isKinematic = true;
	}
		

	[ClientRpc]
	public void RpcPickUp(GameObject player) {
		transform.parent = player.transform;
		transform.position = player.transform.position + player.transform.forward;
		transform.GetComponent<Rigidbody>().isKinematic = true;
	}

    public void Release()
    {
        transform.parent = null;
        transform.GetComponent<Rigidbody>().isKinematic = false;
    }
}