using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{    
    public ItemType itemType;      
    public ActionType actionType;    
    public bool stackable = true;    
    public int durability = 10;
    public int price = 1;
    public int regain = 1;
    public Sprite image;

    public GameObject itemGO;
}

public enum ItemType
{
    None,
    tool,
    seed,
    food
}

public enum ActionType
{
    None,
    water,
    harvest,
    dig,
    mine,
    fishing,

    plant1,
    plant2,
    plant3
}