using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

public class MoverScript : MonoBehaviour
{

    [SerializeField] GameObject agent;
    [SerializeField] Camera cam;
    [SerializeField] float speed = 1.0f;
    public LayerMask layerMask;
   // [SerializeField] LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {

        cam = FindObjectOfType<Camera>();
       // lineRenderer = FindObjectOfType<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, layerMask))
        {
            Vector3 hitpoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            agent.transform.LookAt(hitpoint);
            float snakeToTargetDistance = Vector3.Distance(agent.transform.position, hit.point);
            if (snakeToTargetDistance > 0.05f)
            {
                agent.transform.position += (hitpoint - agent.transform.position).normalized * Time.deltaTime * speed;
            }
            
            //lineRenderer.enabled = true;
           // lineRenderer.SetPosition(0, cam.transform.forward);
          //  lineRenderer.SetPosition(1, hit.point);
        }

    }

}
