using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Animator mainCam;

    public BoxCollider camCheckPoint;

    public LevelController001 levelController;

    bool modeTogger = false;


    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController001>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            modeTogger = !modeTogger;
        }

        if (modeTogger)
        {
            levelController.levelState = LevelController001.LevelState.ThreeD;
            mainCam.Play("2Dto3D");
        }
        else if (levelController.levelState == LevelController001.LevelState.ThreeD)
        {
            levelController.levelState = LevelController001.LevelState.TwoD;
            mainCam.Play("3Dto2D");
        }

    }
}
