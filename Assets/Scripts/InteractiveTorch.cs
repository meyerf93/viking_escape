using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTorch : InteractiveElement {

    public LockableInteractible lockType;
    public bool Fired;

    public override void Activate()
    {
        if (Fired)
        {
            Fired = false;
        }

    }

    public override void UseItemOn(Item item)
    {
        if(item.type == ItemType.TORCH && !Fired)
        {
            Fired = true;
        }
    }
}
