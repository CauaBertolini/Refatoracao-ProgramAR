using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ScenePlacementManager : MonoBehaviour
{
    private GameManager _gameManager;

    public GameObject placementIndicator;

    private ARRaycastManager arRaycast;

    private Pose placementPose;

    private bool placementPoseValid = false;


    void Start()
    {
        _gameManager = GameManager.Instance;

        placementIndicator.SetActive(false);

        arRaycast = GameObject.FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementPose()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycast.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseValid = hits.Count > 0;
        if (placementPoseValid)
            placementPose = hits[0].pose;
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetLocalPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
}
