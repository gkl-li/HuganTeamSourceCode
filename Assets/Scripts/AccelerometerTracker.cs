using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometerTracker : MonoBehaviour
{
    public RawImage gravityDirectionIndicator;
    public DemoPhoneRotator demoPhoneRotator;
    public bool useAccelerometer;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        SetGravityDirection();
    }

    void SetGravityDirection()
    {
        var oldAngles = gravityDirectionIndicator.rectTransform.rotation.eulerAngles;
        var modZAxisAngle = (demoPhoneRotator.refPhoneTransform.rotation.eulerAngles.z+360) % 360;
        if (useAccelerometer)
        {
            if (Input.acceleration.y < -0.8f && Input.acceleration.y > -1f)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124;
            }
            else if (Input.acceleration.y > 0.8f && Input.acceleration.y < 1f)
            {
                Physics.gravity = new Vector3(0, 9.81f, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124 + 180;
            }
            else if (Input.acceleration.x < -0.8f && Input.acceleration.x > -1f)
            {
                Physics.gravity = new Vector3(-9.81f, 0, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124 + 270;
            }
            else if (Input.acceleration.x > 0.8f && Input.acceleration.x < 1f)
            {
                Physics.gravity = new Vector3(9.81f, 0, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124 + 90;
            }
        }
        else
        {
            if (modZAxisAngle > 75 && modZAxisAngle < 105)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124;
            }
            else if (modZAxisAngle > 165 && modZAxisAngle < 195)
            {
                Physics.gravity = new Vector3(9.81f, 0, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124 + 90;
            }
            else if (modZAxisAngle > 255 && modZAxisAngle < 285)
            {
                Physics.gravity = new Vector3(0, 9.81f, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124 + 180;
            }
            else if (modZAxisAngle > 345 || modZAxisAngle < 15)
            {
                Physics.gravity = new Vector3(-9.81f, 0, 0) * GravityChanger.gravityScale;
                oldAngles.z = -124 + 270;
            }
        }
        gravityDirectionIndicator.rectTransform.rotation = Quaternion.Euler(new Vector3(oldAngles.x, oldAngles.y, oldAngles.z));
    }
}
