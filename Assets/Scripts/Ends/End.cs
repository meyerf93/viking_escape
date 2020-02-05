using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    public bool ready;

    public PlayerController player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ready = player != null;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player = other.GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            player = null;
    }
}
