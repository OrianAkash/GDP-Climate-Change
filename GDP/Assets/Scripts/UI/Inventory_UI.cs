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
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }
    void Setup()
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

    public  void SlotBeginDrag(Slot_UI slot)
    {
        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false;
        draggedIcon.rectTransform.sizeDelta = new Vector2(50f, 50f);

        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Start Drag: " + draggedSlot.name);
    }

    public void SlotDrag()
    {
        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Dragging :" + draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Debug.Log("Done Dragging: " + draggedSlot.name);
    }

    public void SlotDrop(Slot_UI slot)
    {
        Debug.Log("Dropped " + draggedSlot.name + " on " + slot.name);
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                Input.mousePosition, null, out position);

            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }
}
