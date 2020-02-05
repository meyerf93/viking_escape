using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveElement : MonoBehaviour {

    protected PlayerController player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Input.GetButtonDown("A " + player.area.controllerID))
        {
            Activate();
        }
        if (player != null && Input.GetButtonDown("B " + player.area.controllerID))
        {
            UseItemOn(player.GetComponent<Inventory>().GetSelectedItem());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item Taker")
            player = other.transform.parent.GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        player = null;
    }

    public virtual void Activate()
    {
        print("Activate Element");
    }

    public virtual void UseItemOn(Item item)
    {
        print("Use item on it");
    }
}
