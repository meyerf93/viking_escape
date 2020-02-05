using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour {

    Portal[] portals;

	// Use this for initialization
	void Start () {
        portals = GetComponentsInChildren<Portal>();
	}
	
	// Update is called once per frame
	void Update () {
        SwapManager();
    }

    void SwapManager()
    {
        List<Portal> toActivate = new List<Portal>();
        foreach (Portal p in portals)
        {
            if (p.player != null && !p.reloading && p.tryActive)
            {
                toActivate.Add(p);
            }
        }

        for (int i = 0; i < toActivate.Count - 1; i++)
        {
            if(!(toActivate[i].player.area.controllerID > GameCore.Instance.playerCount 
            && toActivate[i+1].player.area.controllerID > GameCore.Instance.playerCount))
            toActivate[i].Swap(toActivate[i + 1]);
        }
    }
}
