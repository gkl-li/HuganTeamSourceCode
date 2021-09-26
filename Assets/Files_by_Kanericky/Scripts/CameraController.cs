using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Camera mainCam;

    [SerializeField]
    public Vector3 camOriginPos, camTargetPos;

    [SerializeField]
    public Vector3 camOriginRot, camTargetRot;

    public float lerpPara = .2f;

    public Animator camAnimController;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            camAnimController.Play("2Dto3D");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            camAnimController.Play("3Dto2D");
        }
    }
}
