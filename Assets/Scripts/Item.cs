using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    AXE, PICKAXE, SHOVEL, SWORD, BOW, HAMMER, WOOD, SAW, TORCH, PLANK, KEY, NAIL, POTION, DIRT, ROPE, TREASURE, STONE
}

public class Item : MonoBehaviour {

    public LockableInteractible lockType;

    public Sprite icon;
    public ItemType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
