using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] GameObject[] startPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(PlayerController[] players)
    {
        for(int i = 0; i < 4; i++)
        {
            players[i].transform.position = startPosition[i].transform.position;
        }
    }
}
