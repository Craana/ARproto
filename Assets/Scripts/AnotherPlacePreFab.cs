using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class AnotherPlacePreFab : MonoBehaviour
{
    private ARRaycastManager m_RaycastManager;
    [SerializeField] GameObject PlaceablePrefab;
    private ARAnchorManager m_AnchorManager;
    bool isPLaced = false;
    private ARPlaneManager m_planeManager;

    [SerializeField] Button PrefabPlacer;

    private void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_AnchorManager = GetComponent<ARAnchorManager>();
        m_planeManager = GetComponent<ARPlaneManager>();
    }

    private void Update()
    {

        List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, s_Hits, TrackableType.Planes) && isPLaced == false)
        {
            PrefabPlacer.gameObject.SetActive(true);
            ARAnchor anchor = m_AnchorManager.AttachAnchor((ARPlane)s_Hits[0].trackable, s_Hits[0].pose);
            PlaceablePrefab.SetActive(true);
            PlaceablePrefab.transform.parent = anchor.transform;
            PlaceablePrefab.transform.localPosition = Vector3.zero;

            //After instantiating playfield, I need to disable the planes


            m_planeManager.enabled = false;
            isPLaced = true;
        }
    }
}

