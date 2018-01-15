using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{

    public Socket input1;
    public Socket input2;
    public bool output;
    public GameObject outputWire;
    GameObject gate;
    public bool isCable;


    void OnTriggerEnter(Collider c)
    {
        gate = c.gameObject;
    }

    void Update()
    {
        if (isCable)
        {
            return;
        }

        if (gate != null)
        {
            if (gate.name == "AND")
            {
                if (input1.output && input2.output)
                {
                    output = true;
                }
                else
                {
                    output = false;
                }
            }
            if (gate.name == "XOR")
            {
                if (input1.output ^ input2.output)
                {
                    output = true;
                }
                else
                {
                    output = false;
                }
            }
            if (gate.name == "INV")
            {
                output = !input1.output;
            }
        }
        else
        {
            output = false;
        }

        if (output)
        {
            outputWire.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            foreach (Transform child in outputWire.transform)
            {
                child.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
        else
        {
            outputWire.transform.GetComponent<MeshRenderer>().material.color = Color.black;
            foreach (Transform child in outputWire.transform)
            {
                child.transform.GetComponent<MeshRenderer>().material.color = Color.black;
            }
        }
    }


    void OnTriggerExit(Collider c)
    {
        if (c.name == "AND" || c.name == "XOR" || c.name == "INV")
        {
            gate = null;
            output = false;
        }
    }
}