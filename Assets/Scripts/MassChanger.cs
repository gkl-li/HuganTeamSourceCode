using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassChanger : MonoBehaviour
{
    public Rigidbody refRigidbody;
    public Text massInfoText;

    public void ChangeMass(Slider s)
    {
        refRigidbody.mass = s.value;
        massInfoText.text = string.Format("玩家重量：{0}kg", s.value);
    }
}
