using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotator : MonoBehaviour
{
    public Animator mapRotateAnim;

    static int[] rotateIndex = { 0, 1, 2, 3 };
    int currentRotateIndex = rotateIndex[0];

    bool isSwitching = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isSwitching)
        {
            isSwitching = true;

            StartCoroutine(Switching());
            
            currentRotateIndex = (currentRotateIndex + 1) % 4;
        }
    }

    IEnumerator Switching()
    {

        switch (currentRotateIndex)
        {

            case 0:
                mapRotateAnim.Play("Rotate01");
                break;

            case 1:
                mapRotateAnim.Play("Rotate02");
                break;

            case 2:
                mapRotateAnim.Play("Rotate03");
                break;

            case 3:
                mapRotateAnim.Play("Rotate04");
                break;
        }

        yield return new WaitForSeconds(.2f);

        isSwitching = false;

    }

}
