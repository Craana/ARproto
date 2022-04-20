using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

public class MoverScript : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Camera cam;
    [SerializeField] LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        agent = FindObjectOfType<NavMeshAgent>();
        cam = FindObjectOfType<Camera>();
        lineRenderer = FindObjectOfType<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit))
        {
            agent.SetDestination(hit.point);
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, cam.transform.forward);
            lineRenderer.SetPosition(1, hit.point);
        }

    }

}
