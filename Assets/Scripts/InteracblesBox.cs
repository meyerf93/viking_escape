using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracblesBox : InteractiveElement {

    public ItemType type;

    public Item[] listTreasures;
    
    public override void UseItemOn(Item item)
    {
        if (item.type == type)
        {
            foreach(Item treasure in listTreasures)
            {
                player.GetComponent<Inventory>().AddItem(treasure);
            }

            Destroy(gameObject);
                
        }
    }
}
