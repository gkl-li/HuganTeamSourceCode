using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceInputDisabler : MonoBehaviour
{
    public static float disablingSeconds = 0f;
    public Text infoText;
    public void ChangeDisablingSeconds(Slider s)
    {
        disablingSeconds = s.value;
        infoText.text = string.Format("刮风冷却时间：{0}秒", s.value);
    }
}
