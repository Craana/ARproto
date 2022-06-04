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
	
	[SerializeField] Transform bodyPart;
	
	List<Transform> body = new List<Transform>();
	//Remove these if it does not work
	private float dis;
	private Transform curBodyPart;
	private Transform PrevBodyPart;
	public float minDistance = 0.25f;
	public float curspeed;
	public LayerMask layerMask;

   // [SerializeField] LineRenderer lineRenderer;
	// Start is called before the first frame update
	void Start() 
	{

		cam = FindObjectOfType<Camera>();
	  body.Add(this.transform);
		
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

		}

		for (int i = 1; i < body.Count; i++)
		{

			curBodyPart = body[i];
			PrevBodyPart = body[i - 1];

			dis = Vector3.Distance(PrevBodyPart.position, curBodyPart.position);

			// Vector3 newpos = PrevBodyPart.position;

			//newpos = body[0].position;

			float T = Time.deltaTime * dis / minDistance * curspeed;
			float headtobodydistance = Vector3.Distance(body[0].position, body[1].position);
			
			
            if (headtobodydistance <= 0.05f)
            {
				//Sqrmagnitude or normalized vector for each body part afer the head. hopefully this works
				curBodyPart.position = (curBodyPart.position - PrevBodyPart.position).normalized * 0.05f + PrevBodyPart.position;
            }
            else {
				if (T > 0.5f) T = 0.5f;
				curBodyPart.position = Vector3.Slerp(curBodyPart.position, PrevBodyPart.position, T);
				curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PrevBodyPart.rotation, T);
			}
			
		}

	}


	public void IncreaseTheSize()
	{
		Transform segment = Instantiate(bodyPart);

		segment.position=body[body.Count-1].position;
		body.Add(segment);
		

	}

}
