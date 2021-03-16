using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Mover>())
        {
            UIHandler.instance.HandlePills(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Mover>())
        {
            UIHandler.instance.HandlePills(false);
        }


    }
}
