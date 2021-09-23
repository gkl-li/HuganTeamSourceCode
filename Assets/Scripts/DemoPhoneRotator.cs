using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoPhoneRotator : MonoBehaviour
{
    public Transform refPhoneTransform;
    public void AddRotation(Slider s)
    {
        refPhoneTransform.rotation = Quaternion.Euler(0, 0, 90 + s.value);
    }
}
