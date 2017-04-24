using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation((target.position + Vector3.up * 2) - transform.position, Vector3.up);
	    transform.position = Vector3.Slerp(transform.position, target.position + Vector3.up * 2 +
	        (transform.position - (target.position + Vector3.up * 2)).normalized * 5, 0.9f);
	}
}
