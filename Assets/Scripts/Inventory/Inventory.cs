using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	[SerializeField]
	private GameObject inventoriesContainer;

	InventoryUI inventoryUI;
	PlayerController player;

    [SerializeField]
	List<Item> inventoryItems = new List<Item>();

    int selectedIdx;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController>();
		getInventoryUI();
        updateInventoryUI();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("LB " + player.area.controllerID))
            ChangeSelection(-1);
        if (Input.GetButtonDown("RB " + player.area.controllerID))
            ChangeSelection(+1);
    }

    void getInventoryUI() {
        inventoryUI = inventoriesContainer.transform.Find("Inventory" + (player.area.id)).GetComponentInChildren<InventoryUI>();
    }

    void updateInventoryUI() {
        if(selectedIdx >= inventoryItems.Count)
        {
            selectedIdx = inventoryItems.Count - 1;
        }
        
        if(inventoryItems.Count > 0)
            inventoryUI.UpdateUI(inventoryItems[selectedIdx]);
        else
            inventoryUI.UpdateUI(null);
    }

	public void IdSwaped() {
		getInventoryUI();
        updateInventoryUI();
    }

    public void AddItem(Item i)
    {
        inventoryItems.Add(i);
        ChangeSelection(inventoryItems.Count - 1);
        updateInventoryUI();
    }

    public void RemoveItem(Item i)
    {
        inventoryItems.Remove(i);
        updateInventoryUI();
    }

    public Item GetSelectedItem()
    {
        return inventoryItems[selectedIdx];
    }

    public void ChangeSelection(int offset)
    {
        if (inventoryItems.Count == 0) return;

        selectedIdx += offset;
        if (selectedIdx < 0)
            selectedIdx += inventoryItems.Count;
        selectedIdx = selectedIdx % inventoryItems.Count;

        updateInventoryUI();
    }
}
