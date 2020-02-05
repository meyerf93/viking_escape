using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracbleFIreHearth : InteractiveElement {

    public LockableInteractible lockType;
    private Item transfetItem;

    public bool fired;
    public bool woodStock;

    public GameObject Fire;
    public GameObject Wood;

    public InteractiveElement target;

    void Start()
    {
        transfetItem = new Item();
        transfetItem.lockType = lockType;
    }

    public override void Activate()
    {
        if (fired)
        {
            fired = false;
            GetComponentInChildren<Trap>(true).enabled = false;
        }
    }

    public override void UseItemOn(Item item)
    {
        if(item.type == ItemType.TORCH)
        {
            if (woodStock && !fired)
            {
                fired = true;
                Fire.SetActive(true);
                GetComponentInChildren<Trap>(true).enabled = true;
                woodStock = false;
                target.UseItemOn(transfetItem);
            }
        }
        if(item.type == ItemType.WOOD)
        {
            if (!woodStock && !fired)
            {
                woodStock = true;
                Wood.SetActive(true);
                player.GetComponent<Inventory>().RemoveItem(item);
            }
        }
    }


}
