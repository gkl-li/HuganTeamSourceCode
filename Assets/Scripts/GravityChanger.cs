using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityChanger : MonoBehaviour
{
    public enum GravityDirection { BOTTOM,TOP,LEFT,RIGHT}
    public static float gravityScale = 1;
    public Text gravityScaleInfoText;
    public static GravityDirection gravityDirection = GravityDirection.BOTTOM;

    public static Vector3 GetAdjustedForce(Vector3 originalForce)
    {
        print(gravityDirection);
        switch (gravityDirection)
        {
            case GravityDirection.BOTTOM:
                return Vector3.Scale(new Vector3(1, 1, 1),originalForce);
            case GravityDirection.TOP:
                return Vector3.Scale(new Vector3(-1, -1, 1), originalForce);
            case GravityDirection.LEFT:
                return new Vector3(1 * originalForce.y, -1 * originalForce.x, 1);
            case GravityDirection.RIGHT:
                return new Vector3(-1 * originalForce.y, 1 * originalForce.x, 1);
            default:
                return Vector3.zero;
        }
    }

    /// <summary>
    /// Returns the angle of the arrow
    /// </summary>
    /// <returns></returns>
    public static float ChangeGravityDirection(GravityChanger.GravityDirection gravityDirection)
    {
        GravityChanger.gravityDirection = gravityDirection;
        switch (gravityDirection)
        {
            case GravityDirection.BOTTOM:
                Physics.gravity = new Vector3(0, -9.81f, 0) * GravityChanger.gravityScale;
                return 0;
            case GravityDirection.TOP:
                Physics.gravity = new Vector3(0, 9.81f, 0) * GravityChanger.gravityScale;
                return 180;
            case GravityDirection.LEFT:
                Physics.gravity = new Vector3(-9.81f, 0, 0) * GravityChanger.gravityScale;
                return 270;
            case GravityDirection.RIGHT:
                Physics.gravity = new Vector3(9.81f, 0, 0) * GravityChanger.gravityScale;
                return 90;
            default:
                return -1;
        }
    }

    public void ChangeGravityScale(Slider s)
    {
        gravityScale = s.value;
        gravityScaleInfoText.text = string.Format("当前重力：{0}倍", gravityScale);
    }
}
