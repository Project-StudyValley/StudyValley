using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("ItemType")]
    public ItemType itemType;
    
    [Header("Tool")]
    public ActionType actionType;

    [Header("Seed")]


    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    NA,
    consume,
    Tool
}

public enum ActionType
{
    NA,
    fruit,
    dig,
    water,
    plant1,
    plant2,
    plant3,
}
    