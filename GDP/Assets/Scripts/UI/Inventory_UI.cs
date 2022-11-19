using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    [SerializeField] private Canvas canvas;

    private Slot_UI draggedSlot;
    private Image draggedIcon;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();//toggle inventory
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);  //turn on the inventory make it visible to player
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }
    void Refresh()
    {
        if(slots.Count== player.inventory.slots.Count) //check if inventory and inventory UI has the same number of slots
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {
        Collectable itemToDrop = GameManager.instance.itemManager.GetItemByType(player.inventory.slots[slotID].type);
        if(itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
    }

    
}
