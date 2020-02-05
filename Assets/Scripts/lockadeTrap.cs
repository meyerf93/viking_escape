using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockadeTrap : Trap {

    public LockableInteractible lockType;
    public bool trigered;
    public bool keepPressed;

    public override void ActivateTrap()
    {
        trigered = true;
    }

    public override void LeaveTrap()
    {
        if (keepPressed)
        {
            trigered = false;
        }
    }


}
