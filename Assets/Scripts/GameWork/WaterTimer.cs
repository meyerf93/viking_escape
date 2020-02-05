using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTimer : MonoBehaviour {

    public float levelTimeSec;
    float time;
    bool stop;
	// Use this for initialization
	void Start () {
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (stop) return;
        time += Time.deltaTime / levelTimeSec;
        transform.localScale = new Vector3(1, time, 1);
    }

    public float GetTime()
    {
        return time;
    }

    public void Stop()
    {
        stop = true;
    }

    public void Restart(float startTime = 0)
    {
        stop = false;
        time = 0;
    }
}
