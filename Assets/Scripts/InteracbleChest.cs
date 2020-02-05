using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracbleChest : InteractiveElement {

    public LockableInteractible doorType;
    public Item[] listItems;
    public bool isOpen;
    public bool locked;

    public override void Activate()
    {
        if (!locked && !isOpen)
        {
            Open();
        }
    }

    public override void UseItemOn(Item item)
    {
        if (doorType == item.lockType)
        {
            locked = false;
            player.GetComponent<Inventory>().RemoveItem(item);
        }
    }

    public void Open()
    {
        isOpen = true;
        foreach(Item treasure in listItems)
        {
            player.GetComponent<Inventory>().AddItem(treasure);
        }
    }
}
