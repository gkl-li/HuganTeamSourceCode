using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    public bool isDoorOpen;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isDoorOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isDoorOpen = false;
        }
    }

}
