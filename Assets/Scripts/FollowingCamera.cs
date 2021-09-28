using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [System.Serializable]
    public class Limit
    {
        public float min;
        public float max;
    }

    [System.Serializable]
    public class AxisLimits
    {
        public Limit xLimits;
        public Limit yLimits;
        public Limit zLimits;
    }
    public enum GraphicsMode { TWO_D,THREE_D }

    public Transform refTransform;
    public GraphicsMode graphicsMode;
    public AxisLimits axisLimits = new AxisLimits();

    private Vector3 positionOffset;
    private void Start()
    {
        positionOffset = transform.position - refTransform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = positionOffset + refTransform.position;
        this.transform.localPosition = new Vector3(
                Mathf.Min(Mathf.Max(axisLimits.xLimits.min, this.transform.localPosition.x), axisLimits.xLimits.max),
                Mathf.Min(Mathf.Max(axisLimits.yLimits.min, this.transform.localPosition.y), axisLimits.yLimits.max),
                Mathf.Min(Mathf.Max(axisLimits.zLimits.min, this.transform.localPosition.z), axisLimits.zLimits.max)
            );
    }
}
