using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject ItemToPlace;
    private ARPlaneManager planeManager;

    private GameObject spawnedObject;
    private ARRaycastManager arRayManager;
    private Vector2 touchPosition;
    private Vector3 addedPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        arRayManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchposition)
    {
        if (Input.touchCount > 0)
        {
            touchposition = Input.GetTouch(0).position;
            return true;
        }

        touchposition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchposition))
            return;

        if (arRayManager.Raycast(touchposition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(ItemToPlace, hitPose.position, hitPose.rotation);   
                planeManager.enabled = false;
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
                
            }
        }
    }
}
