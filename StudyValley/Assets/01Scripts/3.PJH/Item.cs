using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public bool stackable = true;
    public Sprite image;
    public ToolAction onAction;

    public ItemType itemType;      
    public ActionType actionType;    
    public int durability = 10;
    public int price = 1;
    public int regain = 1;

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