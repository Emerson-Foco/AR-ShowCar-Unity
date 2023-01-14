using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject toShowInTruePlace;
    public GameObject buttonToPlace;
    
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private GameObject _lastGameObject;
    private bool _haveAGameObject = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        //
        if (_haveAGameObject && !toShowInTruePlace.activeSelf)
        {
            toShowInTruePlace.SetActive(true);
        }
        else if (!_haveAGameObject && toShowInTruePlace.activeSelf)
        {
            toShowInTruePlace.SetActive(false);
        }
        
        //
        if (_haveAGameObject && buttonToPlace.activeSelf)
        {
            buttonToPlace.SetActive(false);
        }
        else if (!_haveAGameObject && !buttonToPlace.activeSelf)
        {
            buttonToPlace.SetActive(true);
        }
    }

    public void ActionToPlace()
    {
        if (placementPoseIsValid)
        {
            PlaceObject();
        }
    }

    public void PlaceObject()
    {
        if (_haveAGameObject)
        {
            Destroy(_lastGameObject);
            _haveAGameObject = false;
        }
        else
        {
            _lastGameObject = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
            _haveAGameObject = true;
        }
        
        
    }

    private void UpdatePlacementIndicator()
    {
        if (_haveAGameObject)
        {
            if (placementIndicator.activeSelf)
            {
                placementIndicator.SetActive(false);
            }
        }
        
        else
        {
            if (placementPoseIsValid)
            {
                placementIndicator.SetActive(true);
                placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
            }
            else
            {
                placementIndicator.SetActive(false);
            }
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, TrackableType.AllTypes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
