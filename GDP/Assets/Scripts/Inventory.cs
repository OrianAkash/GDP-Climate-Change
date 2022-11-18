using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count; //how many item in a slot
        public int maxAllowed; //how many item allowed in the slot

        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 5;
        }
        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return true; //if have space
            }
            return false; //if not space
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for(int i = 0; i < numSlots; i++) //loop through the number of slots the inventory has
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Collectable item) //add items in the inventory when player picked it up
    {
        foreach(Slot slot in slots) //search for item which is the same in the inventory that player want to add
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach (Slot slot in slots)  //add an item which player do not yet have or if slot is full
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    } 
}
