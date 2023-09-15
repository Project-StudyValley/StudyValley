using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainers : ScriptableObject
{
    public List<ItemSlot> slots;
    public bool isDirty;
    

    public void Add(Item item, int count = 1)
    {
        isDirty = true;
        if (item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(slot => slot.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(slot => slot.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            //add non stackable
            ItemSlot itemSlot = slots.Find(slot => slot.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }

    public void RemoveItem(Item itemToRemove, int count = 1)
    {
        isDirty = true;
        if (itemToRemove.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if (itemSlot == null)
                return;

            itemSlot.count -= count;
            if (itemSlot.count <= 0)
            {
                itemSlot.Clear();
            }
        }
        else
        {
            while (count > 0)
            {
                count -= 1;

                ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
                if (itemSlot == null)
                    return;

                itemSlot.Clear();
            }
        }
    }

    internal bool CheckFreeSpace()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == null)
                return true;
        }
        return false;
    }

    internal bool CheckItem(ItemSlot checkingItem)
    {
        ItemSlot itemSlot = slots.Find(x => x.item == checkingItem.item);

        if (itemSlot == null)
            return false;

        if (checkingItem.item.stackable)
            return itemSlot.count >= checkingItem.count;

        return true;
    }

    internal void Init()
    {
        slots = new List<ItemSlot>();
        for (int i = 0; i < 36; i++)
        {
            slots.Add(new ItemSlot());
        }
    }
}
