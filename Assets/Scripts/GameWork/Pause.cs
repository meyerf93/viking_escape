using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    [SerializeField] GameObject pausePanel;
    public static bool paused;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start"))
        {
            SwapPause();
        }
	}

    void SwapPause()
    {
        paused = !paused;
        pausePanel.SetActive(paused);
        Time.timeScale = (paused) ? 0 : 1;
    }
}
