using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracbleWhole : InteractiveElement {

    public GameObject []dirtStone;
    public GameObject []Plank;
    public Collider[] plankCollider;

    public int numberOfRessources;
    public int maxRessource;
    public bool IsFull;

    public int plankRessource;
    public int plankTarget;

    public int nailRessource;
    public int nailTarget;


    public override void UseItemOn(Item item)
    {
        if (item.type == ItemType.STONE || item.type == ItemType.DIRT)
        {
            if (!IsFull)
            {
                if (numberOfRessources < maxRessource)
                {
                    numberOfRessources++;
                    player.GetComponent<Inventory>().RemoveItem(item);
                    dirtStone[numberOfRessources - 1].SetActive(true);
                }
            }

            if (numberOfRessources >= maxRessource)
            {
                IsFull = true;
            }
        }
        else if (item.type == ItemType.PLANK)
        {
            if (!IsFull)
            {
                if (plankRessource < plankTarget)
                {
                    plankRessource++;
                    player.GetComponent<Inventory>().RemoveItem(item);
                    //Debug.Log("actual plank : " + plankRessource);
                    Plank[plankRessource - 1].SetActive(true);
                }
            }
        }
        else if(item.type == ItemType.NAIL)
        {
            if(nailRessource < nailTarget)
            {
                nailRessource++;
                player.GetComponent<Inventory>().RemoveItem(item);
            }

            if(nailRessource == nailTarget)
            {
                IsFull = true;
                foreach (Collider collider in plankCollider)
                {
                    collider.enabled = true;
                }
            }
        }

    }
}
