using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SO_hairPart : MonoBehaviour
{

    public string BodyPartName;
    public int BodyPartAnimationID;
}

public enum ItemType
{
    BuildingBlock,
    Tool
}

public enum ActionType
{
    Dig,
    Mine
}
