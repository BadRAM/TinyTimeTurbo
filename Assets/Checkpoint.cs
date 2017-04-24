using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Race Race;
    public bool active;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && active)
        {
            if (Race.Active)
            {
                Race.Checkpoint();
            }
            else
            {
                Race.StartRace();
            }
        }
    }

	// Update is called once per frame
	void Update () {
	    if (active)
	    {
	        GetComponent<MeshRenderer>().enabled = true;
	    }
	    else
	    {
	        GetComponent<MeshRenderer>().enabled = false;
	    }
	}
}
