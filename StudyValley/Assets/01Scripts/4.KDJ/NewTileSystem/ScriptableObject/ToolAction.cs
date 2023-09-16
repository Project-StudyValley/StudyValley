using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply is not inplemented");
        return true;
    }
        
    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        Debug.LogWarning("OnApply is not inplemented");
        return true;
    }   

    public virtual bool OnItemUsed(Item usedItem, InventoryManager inventorySlots)
    {
        Debug.LogWarning("OnItemUsed is not implemented");
        return true; 
    }
}
