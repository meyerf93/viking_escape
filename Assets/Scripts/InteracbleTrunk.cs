using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracbleTrunk : InteractiveElement {

    public Item Plank;
    public Item Wood;

    public int stock = 1;

    public override void UseItemOn(Item item)
    {

        if (stock > 0)
        {
            if (item.type == ItemType.AXE)
            {
                player.GetComponent<Inventory>().AddItem(Wood);
                stock--;

            }
            else if (item.type == ItemType.SAW)
            {
                player.GetComponent<Inventory>().AddItem(Plank);
                stock--;

            }

            if (stock <= 0) Destroy(gameObject);
        }
    }
}
