using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckPoint : MonoBehaviour
{
    public Camera mainCam;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            mainCam.orthographicSize = 30;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        mainCam.orthographicSize = 20;
    }
}
