using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Item item;

    Rect baseRect;
    //public float dropDelay = 3.0f;

    private void Start()
    {
        baseRect = transform.parent.parent.GetComponent<RectTransform>().rect;

        item.durability = 10;
        
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        //count = Random.Range(1, 5);
        //count = 1;
        RefreshCount();
    }
    public void Clear()
    {
        item = null;
        count = 0;
    }


    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
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
        Collider2D playerCollider = PlayerController_Beta.instance.GetComponent<Collider2D>();

        // 인벤토리 밖에 드랍하면
        if (transform.localPosition.x < baseRect.xMin
           || transform.localPosition.x > baseRect.xMax
           || transform.localPosition.y < baseRect.yMin
           || transform.localPosition.y > baseRect.yMax)
        {
            // 플레이어 콜라이더 끄고
            playerCollider.enabled = false;
            
            // 해당 아이템을 버린다.
            item.itemGO.transform.position = PlayerController_Beta.instance.transform.position;
            for (int i = 0; i < count; i++)
            {
                GameObject instanceItem = Instantiate(item.itemGO);
                //ItemDrop isGrounded = instanceItem.GetComponent<ItemDrop>();
                //isGrounded._isGrounded = true;
            }
            
            Destroy(gameObject);
        }
    }

    //IEnumerator DropItemWithDelay()
    //{
    //    Collider2D playerCollider = PlayerController.instance.GetComponent<Collider2D>();
        
    //    if (playerCollider != null)
    //    {
    //        Debug.Log("1차");
    //        playerCollider.enabled = false;
    //    }
    //    Debug.Log("2차");
    //    yield return new WaitForSeconds(dropDelay);
    //    Debug.Log("3차");
    //    if (playerCollider != null)
    //    {
    //        Debug.Log("4차");
    //        playerCollider.enabled = true;
    //    }

    //}
}
