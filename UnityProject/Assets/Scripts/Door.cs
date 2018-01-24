using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Socket input;

    void Update()
    {
        if (input.output)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Open()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, transform.localScale.y, 0.2f), Time.deltaTime);
    }

    void Close()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, transform.localScale.y, 1), Time.deltaTime);
    }
}