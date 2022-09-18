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
	
	List<GameObject> body = new List<GameObject>();
	//Remove these if it does not work
	private float dis;
	private GameObject curBodyPart;
	private GameObject PrevBodyPart;
	public float minDistance = 0.25f;
	public float curspeed;
	public LayerMask layerMask;
	GameObject segment;

	// [SerializeField] LineRenderer lineRenderer;
	// Start is called before the first frame update
	void Start() 
	{

		cam = FindObjectOfType<Camera>();
	  body.Add(this.gameObject);
		
	}

    private void FixedUpdate()
    {
		RaycastForMoving();
		SnakeBodySystem();
	}


    void Update()
	{
       

		

	}

	public void ResetThePosition()
    {
		this.gameObject.transform.position = new Vector3(0, 0, 0);
    }

	public void DeleteEveryBodyPart()
    {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Body");
		for (int i = 0; i < enemies.Length; i++) { GameObject.Destroy(enemies[i]); body.Remove(enemies[i]); }
    }

	void SnakeBodySystem()
    {
		for (int i = 1; i < body.Count; i++)
		{

			curBodyPart = body[i];
			PrevBodyPart = body[i - 1];
			dis = Vector3.Distance(PrevBodyPart.transform.position, curBodyPart.transform.position);
			float T = Time.deltaTime * dis / minDistance * curspeed;
			float headtobodydistance = Vector3.Distance(body[0].transform.position, body[1].transform.position);

			if (T > 0.5f) T = 0.5f;
			if (headtobodydistance <= 0.05f)
			{

				curBodyPart.transform.position = (curBodyPart.transform.position - PrevBodyPart.transform.position).normalized * 0.05f + PrevBodyPart.transform.position;
			}
			else
			{

				curBodyPart.transform.position = Vector3.Slerp(curBodyPart.transform.position, PrevBodyPart.transform.position, T);
				curBodyPart.transform.rotation = Quaternion.Slerp(curBodyPart.transform.rotation, PrevBodyPart.transform.rotation, T);
			}

		}
	}

	private void RaycastForMoving()
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

    }

	public void IncreaseTheSize()
	{
		 segment = Instantiate(bodyPart.gameObject);

		segment.transform.position = body[body.Count-1].transform.position;
		body.Add(segment);
	}

}
