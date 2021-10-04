using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapRotator : MonoBehaviour
{
    public LevelController001 levelController;
    public Collider playerCollider;
    public Rigidbody playerRig;
    public Transform levelMap;

    static int[] rotateIndex = { 0, 1, 2, 3 };
    int currentRotateIndex = rotateIndex[0];

    bool isSwitching = false;

    private void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController001>();
    }

    private void Update()
    {
        if ( (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) && !isSwitching && levelController.levelState == LevelController001.LevelState.ThreeD)
        {
            
            isSwitching = true;

            if(playerCollider != null)
                playerCollider.enabled = false;

            playerRig.useGravity = false;

            StartCoroutine(Switching());
            
            currentRotateIndex = (currentRotateIndex + 1) % 4;
        }
    }

    IEnumerator Switching()
    {   
        
        int rotateDir = Input.GetKeyDown(KeyCode.Q) ? 1 : -1;
        levelMap.DORotate(new Vector3(0, 90 * rotateDir, 0), .5f, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.6f);

        isSwitching = false;
        playerCollider.enabled = true;
        playerRig.useGravity = true;

    }

}
