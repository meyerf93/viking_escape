using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    ORC, SKELETON, GHOST 
}

public class MonsterInteractive : InteractiveElement {

    public MonsterType type;

    public override void UseItemOn(Item item)
    {
        switch (type)
        {
            case MonsterType.ORC:
                UseOnOrc(item);
                break;
            case MonsterType.SKELETON:
                UseOnSkelleton(item);
                break;
            case MonsterType.GHOST:
                UseOnGhost(item);
                break;
        }
    }

    public void UseOnOrc(Item item)
    {
        if(item.type == ItemType.AXE)
        {
            GetComponentInParent<MonsterAI>().Damages(2,player);
        }
    }
    public void UseOnSkelleton(Item item)
    {
        if (item.type == ItemType.SWORD)
        {
            GetComponentInParent<MonsterAI>().Damages(1, player);
        }
    }
    public void UseOnGhost(Item item)
    {
        if (item.type == ItemType.TORCH)
        {
            GetComponentInParent<MonsterAI>().Damages(1, player);
        }
    }
}
