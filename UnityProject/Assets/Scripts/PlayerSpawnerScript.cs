using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour {

	// Use this for initialization
	public  GameObject[] playerPrefabs;
	ChoosePlayer menu;

	void Start () {
		menu = GameObject.Find ("Choose Player").transform.GetComponent <ChoosePlayer>();
		GameObject player = (GameObject)Instantiate(playerPrefabs[menu.choice], transform.position, transform.rotation);

	}
}
