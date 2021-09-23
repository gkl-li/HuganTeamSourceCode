using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DrawController : MonoBehaviour
{
    public enum InputMode { MOUSE, FINGER }

    public InputMode inputMode;
    public LineRenderer lineRenderer;
    public Rigidbody refRigidBody;
    public float forceMagnitude = 10;
    private List<Vector3> positions;
    private float secondsSinceLastAction = float.MaxValue/2;

    void Start()
    {
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        positions = new List<Vector3>();
    }

    public void ClearDrawn()
    {
        positions.Clear();
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        secondsSinceLastAction += Time.deltaTime;
        if (secondsSinceLastAction < ForceInputDisabler.disablingSeconds)
        {
            return;
        }
        else if (GetEndDrawCondition(inputMode))
        {
            var force = CalculateResultingDirection() * ForceMagnitudeChanger.forceMagnitude;
            refRigidBody.AddForce(force);
            ClearDrawn();
            secondsSinceLastAction = 0;
        }
        else if (GetIsDrawingCondition(inputMode))
        {
            AddPoint();
        }
    }


    bool GetEndDrawCondition(InputMode inputMode)
    {
        if (inputMode == InputMode.FINGER)
            return Input.GetTouch(0).phase == TouchPhase.Ended;
        else if (inputMode == InputMode.MOUSE)
            return Input.GetMouseButtonUp(0);
        else
            return false;
    }

    bool GetIsDrawingCondition(InputMode inputMode)
    {
        if (inputMode == InputMode.FINGER)
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
        else if (inputMode == InputMode.MOUSE)
            return Input.GetMouseButton(0);
        else
            return false;
    }

    Vector3 CalculateResultingDirection()
    {
        var startPosition = positions[0];
        var endPosition = positions[lineRenderer.positionCount-1];
        var relativePosition = (endPosition - startPosition);
        return new Vector3(-relativePosition.x,relativePosition.y,relativePosition.z);
    }


    void AddPoint()
    {
        var position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        positions.Add(position);
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPosition(positions.Count - 1, position);
    }
}