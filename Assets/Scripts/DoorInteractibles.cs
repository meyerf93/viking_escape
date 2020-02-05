using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LockableInteractible
{
    NONE, LOCKA, LOCKB, LOCKC, LOCKD,
}

[RequireComponent(typeof(AudioSource))]
public class DoorInteractibles : InteractiveElement {

    [SerializeField]
    private GameObject door;
    [SerializeField]
    private int rotationWhenOpen = 90;

    private AudioSource audioSource;
    public LockableInteractible doorType;
    public bool isOpen;
    public bool locked;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Activate()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            if (!locked)
                Open();
        }
    }

    public override void UseItemOn(Item item)
    {
        if(doorType == item.lockType)
        {
            locked = false;
            player.GetComponent<Inventory>().RemoveItem(item);
            Open();
        }
    }

    public void Open()
    {
        isOpen = true;
        audioSource.Play();
        door.transform.Rotate(0, rotationWhenOpen, 0);
    }

    public void Close()
    {
        isOpen = false;
        audioSource.Play();
        door.transform.Rotate(0, -rotationWhenOpen, 0);
    }

}
