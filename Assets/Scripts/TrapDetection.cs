using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetection : Trap {
    public int Damage;

    public override void ActivateTrap()
    {
        GameCore.Instance.ModifieHealth(Damage);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
