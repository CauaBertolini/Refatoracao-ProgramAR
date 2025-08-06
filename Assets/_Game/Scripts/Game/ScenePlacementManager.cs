using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ScenePlacementManager : MonoBehaviour
{
    public GameControll gameControll;

    public GameObject placementIndicator;
    public GameObject tutorial;

    private ARRaycastManager arRaycast;

    private Pose placementPose;

    private bool placementPoseValid = false;


    void Start()
    {
        switch (GlobalControll.levelType)
        {
            case 0: placementIndicator = Instantiate(Resources.Load<GameObject>($"Levels/BLevel{GlobalControll.levelID}"), new Vector3(), new Quaternion()); break;
            case 1: placementIndicator = Instantiate(Resources.Load<GameObject>($"Levels/GLevel{GlobalControll.levelID}"), new Vector3(), new Quaternion()); break;
        }

        placementIndicator.SetActive(false);

        arRaycast = GameObject.FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        
        if (placementPoseValid && Input.touchCount > 0)
        {
            gameControll.enabled = true;

            StartCoroutine(CallTutorial());
        }
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

    private IEnumerator CallTutorial()
    {
        yield return new WaitForSeconds(.5f);

        if (GlobalControll.runTutorial)
            tutorial.SetActive(true);

        Destroy(this);
    }
}
