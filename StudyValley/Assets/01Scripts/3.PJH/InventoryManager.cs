using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    public GameObject mainInventoryGroup;

    //부모위치선정  
    public GameObject mainInventory;
    public GameObject toolBar;

    //이동할툴바슬롯들
    public GameObject[] toolBarSlots;

    public Item[] startItems;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
        foreach (var item in startItems)
        {
            AddItem(item);
        }
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number >= 0 && number < 10)
            {
                if (number == 0)
                {
                    number = 10;
                }
                ChangeSelectedSlot(number - 1);
            }
        }

        // 툴바 인벤토리 동기화        
        if (InventoryManager.instance.mainInventoryGroup.activeSelf)
        {
            foreach (var item in inventorySlots)
            {
                item.transform.SetParent(mainInventory.transform);
                item.transform.SetAsLastSibling();
            }
        }
        else
        {
            foreach (var slot in toolBarSlots)
            {
                slot.transform.SetParent(toolBar.transform);
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

/*    public void RemoveItem(Item itemToRemove, int count = 1)
    {
        if (itemToRemove == null || count <= 0)
        {
            return;
        }

        if (itemToRemove.stackable)
        {
            for (int i = 0; i < inventorySlots.Length && count > 0; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null)
                    continue;
                if (itemInSlot.item == itemToRemove)
                {
                    int removeCount = Mathf.Min(count, itemInSlot.count);
                    itemInSlot.count -= removeCount;
                    count -= removeCount;
                    if (itemInSlot.count <= 0)
                    {
                        itemInSlot.Clear();
                    }
                }
            }
        }
        else
        {
            while (count > 0)
            {
                for (int i = inventorySlots.Length - 1; i >= 0 && count > 0; i--)
                {
                    InventorySlot slot = inventorySlots[i];
                    InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                    if (itemInSlot == null)
                        continue;

                    itemInSlot.Clear();
                    count--;
                }
            }
        }
    }*/


    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponentInChildren<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    // true 사용 false 확인
    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true)
            {
                if (item.itemType == ItemType.tool)
                {
                    item.durability -= 1;
                    if (item.durability <= 0)
                    {
                        Debug.Log("내구도0");
                        Destroy(itemInSlot.gameObject);
                    }
                }
                else
                {
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                    else
                    {
                        itemInSlot.RefreshCount();
                    }
                }
            }
            return item;
        }
        return null;
    }
}
