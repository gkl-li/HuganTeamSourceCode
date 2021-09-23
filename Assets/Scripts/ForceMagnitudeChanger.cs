using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceMagnitudeChanger : MonoBehaviour
{
    public static float forceMagnitude = 100;
    public Text infoText;
    public void ChangeForceMagnitude(Slider s)
    {
        forceMagnitude = s.value;
        infoText.text = string.Format("风力：{0}N", forceMagnitude);
    }
}
