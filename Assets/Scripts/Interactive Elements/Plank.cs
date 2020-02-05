using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : InteractiveElement {

    [SerializeField] Item wood;

    public override void Activate()
    {
        print("plank activate");
    }

    public override void UseItemOn(Item item)
    {
        switch (item.type)
        {
            case ItemType.AXE:
                Cut();
                break;
        }
    }

    public void Cut()
    {
        print("CUT");
        player.GetComponent<Inventory>().AddItem(wood);
        Destroy(gameObject);
    }
}
