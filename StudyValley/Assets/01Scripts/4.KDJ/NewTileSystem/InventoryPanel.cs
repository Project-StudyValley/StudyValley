using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    ItemContainers inventory;

    private void Start()
    {
        Show();
    }
    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {

        }
    }


    private void Show()
    {
        
    }
}
