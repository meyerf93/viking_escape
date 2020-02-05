using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeInteractive : InteractiveElement {

    public ItemType type;

     public override void UseItemOn(Item item)
    {
        Debug.Log("item type : " + item.type);
        if(item.type == type)
                Destroy(gameObject);
    }
}
