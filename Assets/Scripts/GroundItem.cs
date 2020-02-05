using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : InteractiveElement {

    [SerializeField] Item item;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public override void Activate()
    {
        player.GetComponent<Inventory>().AddItem(item);
        Destroy(gameObject);
	}

}
