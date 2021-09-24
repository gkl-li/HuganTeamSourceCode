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
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.BOTTOM);
            }
            else if (Input.acceleration.y > 0.8f && Input.acceleration.y < 1f)
            {
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.TOP);
            }
            else if (Input.acceleration.x < -0.8f && Input.acceleration.x > -1f)
            {
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.LEFT);
            }
            else if (Input.acceleration.x > 0.8f && Input.acceleration.x < 1f)
            {
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.RIGHT);
            }
        }
        else
        {
            if (modZAxisAngle > 75 && modZAxisAngle < 105)
            {
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.BOTTOM);
            }
            else if (modZAxisAngle > 165 && modZAxisAngle < 195)
            {
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.RIGHT);
            }
            else if (modZAxisAngle > 255 && modZAxisAngle < 285)
            {
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.TOP);
            }
            else if (modZAxisAngle > 345 || modZAxisAngle < 15)
            {
                oldAngles.z = GravityChanger.ChangeGravityDirection(GravityChanger.GravityDirection.LEFT);
            }
        }
        gravityDirectionIndicator.rectTransform.rotation = Quaternion.Euler(new Vector3(oldAngles.x, oldAngles.y, -124+ oldAngles.z));
    }
}
