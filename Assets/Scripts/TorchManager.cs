using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour {

    public InteractiveTorch[] listTorchs;
    public LockableInteractible lockType;

    public InteractiveElement target;
    private bool trigered = false;
    public bool stateTarget;

    private void Update()
    {
        foreach( InteractiveTorch torch in listTorchs)
        {
            if (torch.Fired != stateTarget)
            {
                return;
            }
        }

        //l'objet fais un truc 
        if (!trigered)
        {
            target.Activate();
            trigered = true;
        }
    }
}
