using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlateManager : MonoBehaviour {

    public lockadeTrap[] trapList;
    public InteractiveElement target;
    public bool trigerred;
	
	// Update is called once per frame
	void Update () {
		foreach(lockadeTrap trap in trapList)
        {
            if (!trap.trigered) return;
        }

        if (!trigerred)
        {
            trigerred = true;
            target.Activate();
        }
    }
}
