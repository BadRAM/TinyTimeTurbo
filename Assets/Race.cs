using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Race : MonoBehaviour
{
    public List<Checkpoint> Checkpoints;
    public float Time;
    private float _startTime;
    public int Laps;
    private int _lap;
    private int _checkpoint;
    public Text Lap;
    public Text CurrentTime;
    public Text FinalTime;
    public bool Active;
    public bool Time1;
    public bool Time2;
    public bool Time3;

    public void StartRace()
    {
        Debug.Log("STARTING RACE");
        Active = true;
        _lap = 0;
        _checkpoint = 0;
        _startTime = UnityEngine.Time.time;
        foreach (Checkpoint checkpoint in Checkpoints)
        {
            checkpoint.active = false;
        }
        Checkpoints[_checkpoint].active = true;
    }

    public void Checkpoint()
    {
        Checkpoints[_checkpoint].active = false;
        Debug.Log("checkpoint " + (_checkpoint + 1) + "/" + Checkpoints.Count);
        if (Checkpoints.Count - 1 == _checkpoint)
        {
            _checkpoint = 0;
            _lap += 1;
            if (_lap == Laps)
            {
                Debug.Log("RACE COMPLETE");
                if (Time1)
                {
                    Times.Time1 = Mathf.Min(Time, Times.Time1);
                    SceneManager.UnloadSceneAsync("Race1");
                }
                else if (Time2)
                {
                    Times.Time2 = Mathf.Min(Time, Times.Time2);
                    SceneManager.UnloadSceneAsync("Race2");
                }
                else if (Time3)
                {
                    Times.Time3 = Mathf.Min(Time, Times.Time3);
                    SceneManager.UnloadSceneAsync("Race3");
                }
            }
            Debug.Log("LAP COMPLETE");
        }
        else
        {
            _checkpoint += 1;
        }
        Checkpoints[_checkpoint].active = true;
    }

    // Update is called once per frame
	void Update ()
	{
	    if (Input.GetButtonDown("Cancel"))
	    {
	        if (Time1)
	        {
	            SceneManager.UnloadSceneAsync("Race1");
	        }
	        else if (Time2)
	        {
	            SceneManager.UnloadSceneAsync("Race2");
	        }
	        else if (Time3)
	        {
	            SceneManager.UnloadSceneAsync("Race3");
	        }
	    }
	    if (Active)
	    {
	        Time = UnityEngine.Time.time - _startTime;
	        string minutes = Mathf.Floor(Time / 60).ToString("00");
	        string seconds = Mathf.Floor(Time % 60).ToString("00");
	        string fraction = Mathf.Floor((Time * 100) % 100).ToString("00");
	        CurrentTime.text = minutes + ":" + seconds + ":" + fraction;

	        Lap.text = (_lap + 1) + "/" + Laps;
	    }
	}
}
