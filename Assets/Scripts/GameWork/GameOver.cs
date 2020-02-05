﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("A 1"))
        {
            GameCore.Instance.Replay();
        }
        else if(Input.GetButtonDown("B 1"))
        {
            GameCore.Instance.BackToMenu();
        }
	}
}
