using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacePrefabIntoWorld : MonoBehaviour
{
   private ARRaycastManager m_RaycastManager;
    [SerializeField] GameObject PlaceablePrefab;
    private ARAnchorManager m_AnchorManager;
    bool isPLaced = false;
    private ARPlaneManager m_planeManager;

    private void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_AnchorManager = GetComponent<ARAnchorManager>();
        m_planeManager = GetComponent<ARPlaneManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {

            List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
            if (m_RaycastManager.Raycast(Input.GetTouch(0).position, s_Hits, TrackableType.Planes) && isPLaced == false)
            {
                    ARAnchor anchor = m_AnchorManager.AttachAnchor((ARPlane)s_Hits[0].trackable, s_Hits[0].pose);
                PlaceablePrefab.SetActive(true);
                PlaceablePrefab.transform.parent = anchor.transform;
                PlaceablePrefab.transform.localPosition = Vector3.zero;
                //After instantiating playfield, I need to disable the 
               
                m_planeManager.enabled = false;
                isPLaced = true;
            }
        }
        }
}
