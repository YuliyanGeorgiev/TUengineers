using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour {


    public InputField userDirection;
    public float speed = 1;
    public string direction;
    private int level1 = 5;
    private int levelGr = 0;


    // Use this for initialization
    void Start()
    {
        direction = "up";
    }

    // Update is called once per frame
    void Update()
    {

        if (direction == "up" && transform.position.y <= level1)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (direction == "down" && transform.position.y >= levelGr)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }

    public void setDirection()
    {
        direction = userDirection.text;
    }
}
