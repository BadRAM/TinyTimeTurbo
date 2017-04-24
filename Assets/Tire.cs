using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour {
    public bool Powered;
    public bool Steerable;
    public Transform Wheel;

	// Use this for initialization
	void Start () {
		//GetComponent<WheelCollider>().
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 position;
	    Quaternion rotation;
	    GetComponent<WheelCollider>().GetWorldPose(out position, out rotation);
	    Wheel.position = position;
	    Wheel.rotation = rotation;
	}
}
