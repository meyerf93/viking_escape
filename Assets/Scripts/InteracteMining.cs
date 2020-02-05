using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracteMining : InteractiveElement {

    public Item ressource;
    public ItemType tools;

    public int stock = 1;

    public override void UseItemOn(Item item)
    {
        if (stock > 0)
        {
            if (item.type == tools)
            {
                player.GetComponent<Inventory>().AddItem(ressource);
                stock--;
            }

            if (stock <= 0) Destroy(gameObject);
        }
    }
}
