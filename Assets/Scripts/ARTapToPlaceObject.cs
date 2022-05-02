using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;
    [SerializeField] ARPlaneManager _planeManager;
    private GameObject spawnedObject;
    private ARRaycastManager _arraycastmanager;
    private Vector2 touchPosition;


    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arraycastmanager = GetComponent<ARRaycastManager>();
        _planeManager = GetComponent<ARPlaneManager>();
       
    }

  /*  bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }*/

    private void Update()
    {
        /*   if(!TryGetTouchPosition(out touchPosition))
           {
               return;
           }*/

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        if (_arraycastmanager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                _planeManager.SetTrackablesActive(false);
                _planeManager.planePrefab.gameObject.SetActive(false);
                _planeManager.enabled = false;
               
                
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}
