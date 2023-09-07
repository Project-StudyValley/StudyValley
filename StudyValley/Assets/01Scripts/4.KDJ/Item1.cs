using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item1 : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType1 type;
    public ActionType actionType;
  /*  public Vector2Int range = new Vector2Int(5, 4);*/

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;


}

public enum ItemType1
{
    BuildingBlock,
    Tool
}

public enum ActionType1
{
    Dig,
    Mine
}
