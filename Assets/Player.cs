using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Tire> Wheels;
    public float MaxRPM = 100;
    public float MaxSteerAngle = 40;
    public float MaxTorque;
    public float MaxSpeed;
    public float Grip;
    public Transform CoM;
    private float _steerAngle;
    public Text SpeedText;


	// Use this for initialization
	void Start ()
	{
	    GetComponent<Rigidbody>().centerOfMass = CoM.localPosition;
	}

    void Update()
    {
        SpeedText.text = (GetComponent<Rigidbody>().velocity.magnitude * 2).ToString("00");
    }

	// Update is called once per tick
	void FixedUpdate () {
	    foreach (Tire tire in Wheels)
	    {
	        tire.GetComponent<WheelCollider>().brakeTorque = 0;
	        if (tire.Powered)
	        {
	            tire.GetComponent<WheelCollider>().motorTorque =
	                ((MaxRPM - tire.GetComponent<WheelCollider>().rpm) / MaxRPM) * Input.GetAxis("Vertical") * MaxTorque;
	        }
	        if (Input.GetAxis("Vertical") < 0 && tire.GetComponent<WheelCollider>().rpm > 0)
	        {
	            tire.GetComponent<WheelCollider>().brakeTorque = MaxTorque * -Input.GetAxis("Vertical");
	        }
	        else if (Input.GetAxis("Vertical") < 0 && tire.GetComponent<WheelCollider>().rpm >= 0)
	        {
	            tire.GetComponent<WheelCollider>().motorTorque =
	                ((MaxRPM - -tire.GetComponent<WheelCollider>().rpm) / MaxRPM) * Input.GetAxis("Vertical") * MaxTorque;
	        }
	        if (tire.Steerable)
	        {
	            tire.GetComponent<WheelCollider>().steerAngle = Input.GetAxis("Horizontal") * MaxSteerAngle;
	        }
	    }
	}
}
