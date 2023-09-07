using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public Item itemData;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            gameObject.SetActive(false);
            InventoryManager.instance.AddItem(itemData);
        }        
    }
}