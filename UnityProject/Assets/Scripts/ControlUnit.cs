using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUnit : MonoBehaviour
{
    public Socket socket;
    public Elevator elevator;
    public Conveyor conveyor;
    public GameObject light;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (elevator != null)
        {
            if (socket.output)
            {
                elevator.SetSpeed(100);
            }
            else
            {
                elevator.SetSpeed(-100);
            }
        }

        if (conveyor != null)
        {
            if (socket.output)
            {
                conveyor.SetSpeed(1);
            }
        }

        if (socket.output)
        {
            light.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            light.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}