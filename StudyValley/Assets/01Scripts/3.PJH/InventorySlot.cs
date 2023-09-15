using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite selectedSprite, notSelectedSprite;


    public void Select()
    {
        image.sprite = selectedSprite;
    }
    
    public void Deselect()
    {
        image.sprite = notSelectedSprite;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
