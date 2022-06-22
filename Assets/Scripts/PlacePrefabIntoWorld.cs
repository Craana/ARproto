using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacePrefabIntoWorld : MonoBehaviour
{
   private ARRaycastManager m_RaycastManager;
    [SerializeField] GameObject PlaceablePrefab;
    private ARAnchorManager m_AnchorManager;
    bool isPLaced = false;
    private ARPlaneManager m_planeManager;
    [SerializeField] Text PlaceThePlaneText;

    private void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_AnchorManager = GetComponent<ARAnchorManager>();
        m_planeManager = GetComponent<ARPlaneManager>();

        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        PlaceThePlaneText.gameObject.SetActive(state == GameManager.GameState.Start);
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
                m_planeManager.enabled = false;
                isPLaced = true;
               
            }
        }
    }
}
