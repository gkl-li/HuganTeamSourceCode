using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityChanger : MonoBehaviour
{
    public static float gravityScale = 1;
    public Text gravityScaleInfoText;
    public void ChangeGravityScale(Slider s)
    {
        gravityScale = s.value;
        gravityScaleInfoText.text = string.Format("当前重力：{0}倍", gravityScale);
    }
}
