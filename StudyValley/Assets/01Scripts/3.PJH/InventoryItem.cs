using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int myCount = 1;
    [HideInInspector] public Item item;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        //count = Random.Range(1, 5);
        //count = 1;
        RefreshCount();
    }

    public void SetCount(int count)
    {
        myCount = count;
    }

    public void RefreshCount()
    {
        countText.text = myCount.ToString();
        bool textActive = myCount > 1;
        countText.gameObject.SetActive(textActive);

        /*        countText.gameObject.SetActive(true);
                image.sprite = slot.item.image;

                if(slot.item.stackable == true)
                {
                    countText.gameObject.SetActive(true);
                    countText.text = slot.count.ToString();
                }
                else
                {
                    countText.gameObject.SetActive(false);
                }*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin drag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End drag");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);

    }
}
