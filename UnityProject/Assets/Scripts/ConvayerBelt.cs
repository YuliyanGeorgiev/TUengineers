using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvayerBelt : MonoBehaviour {

    public GameObject turret;
    public InputField userDirection;
    public float speed = 1;
    public string direction;
    private float time = 6;
    

    // Use this for initialization
    void Start () {
        direction = "left";
	}
	
	// Update is called once per frame
	void Update () {
		
        if (time > 1 && direction == "left")
        {
            time -= Time.deltaTime;
            turret.transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (time > 1 && direction == "right")
        {
            time -= Time.deltaTime;
            turret.transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if ( time < 1 && direction == "left")
        {
            time = 6;
            direction = "right";
        }
        else if (time < 1 && direction == "right")
        {
            time = 6;
            direction = "left";
        }
        
        if (turret.transform.position.y < 0.6)
        {
           // Destroy(turret);
        }
    }

    public void setDirection()
    {
        direction = userDirection.text;
        time = 6;
    }

}
