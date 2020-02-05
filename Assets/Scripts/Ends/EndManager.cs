using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour {

    End[] ends;

	// Use this for initialization
	void Start ()
    {
        ends = GetComponentsInChildren<End>();
    }
	
	// Update is called once per frame
	void Update () {
        CheckLevelEnd();
	}

    void CheckLevelEnd()
    {
        bool result = true;
        foreach(End end in ends)
        {
            result = result && end.ready;
        }

        if (result)
        {
            GameCore.Instance.NextLevel();
        }
    }
}
