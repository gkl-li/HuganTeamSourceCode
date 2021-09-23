using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR;
using UnityEngine.UI;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{ 
//{
//    public GameObject objectToPlace;
//    public GameObject placementIndicator;
//    public Text debugText;

//    private ARSessionOrigin arOrigin;
//    private ARRaycastManager arRaycastManager;
//    private Pose placementPose;
//    private bool placementPoseIsValid = false;

//    void Start()
//    {
//        arOrigin = FindObjectOfType<ARSessionOrigin>();
//        arRaycastManager = FindObjectOfType<ARRaycastManager>();
//    }

//    void Update()
//    {
//        try
//        {
//            UpdatePlacementPose();
//            UpdatePlacementIndicator();


//            if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//            {
//                PlaceObject();
//            }
//        }
//        catch(Exception e)
//        {
//            debugText.text = e.StackTrace;
//        }
//    }

//    private void PlaceObject()
//    {
//        Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
//    }

//    private void UpdatePlacementIndicator()
//    {
//        debugText.text = ("可放置：" + (placementPoseIsValid ? "Yes": "No"));

//        if (placementPoseIsValid)
//        {
//            placementIndicator.SetActive(true);
//            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
//        }
//        else
//        {
//            placementIndicator.SetActive(false);
//        }
//    }

//    private void UpdatePlacementPose()
//    {
//        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
//        var hits = new List<ARRaycastHit>();
//        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

//        placementPoseIsValid = hits.Count > 0;
//        if (placementPoseIsValid)
//        {
//            placementPose = hits[0].pose;
//            var cameraForward = Camera.main.transform.forward;
//            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
//            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
//        }
//    }
}