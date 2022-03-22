using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

public class MoverScript : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit))
        {
            
            agent.SetDestination(hit.point);
            Debug.Log(":)");
        }
        else
        {
            Debug.Log("???");
        }

    }

}
