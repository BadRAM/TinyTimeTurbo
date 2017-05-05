using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform target;
    public float BaseFov = 70;
    public float MaxFov = 90;
    public float MaxSpeed = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = Quaternion.LookRotation((target.position + Vector3.up * 2) - transform.position, Vector3.up);
	    transform.position = Vector3.Slerp(transform.position, target.position + Vector3.up * 2 +
	        (transform.position - (target.position + Vector3.up * 2)).normalized * 5, 0.9f);

	    GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView,
	        Mathf.Lerp(BaseFov, MaxFov, target.GetComponent<Rigidbody>().velocity.magnitude / MaxSpeed), 0.1f);
	    Debug.Log(GetComponent<Camera>().fieldOfView);
	}
}
