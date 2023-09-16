using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static SWH_Controller2;

public class ToolPlayerController : MonoBehaviour
{
    private SWH_Controller2 playerCnt;
    private Rigidbody2D rgdb2D;
    private Animator animator;

    [SerializeField]
    private float offsetDistance = 1f;
    [SerializeField]
    private float sizeOfInteractableArea = 1.2f;
    [SerializeField]
    private MarkerManager markerManager;
    [SerializeField]
    private TileMapReadController tileMapReadController;
    [SerializeField]
    private float maxDistance = 1.5f;
    [SerializeField]
    private TileData plowableTiles;

    InventorySlot inventorySlot;

    private Vector3Int selectedTilePosition;
    private bool selectable;

    private void Awake()
    {
        playerCnt = GetComponent<SWH_Controller2>();
        rgdb2D = GetComponent<Rigidbody2D>();
        inventorySlot = GetComponent<InventorySlot>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Marker();
        SelectTile();
        CanSelectCheck();
        if (Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);

    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);

    }

    private void Marker()
    {
        Vector3Int gridPosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
        markerManager.markedCellPosition = gridPosition;
    }
    private bool UseToolWorld()
    {
        Vector2 position = rgdb2D.position + playerCnt.movement * offsetDistance;

        Item selectedItem = InventoryManager.instance.GetSelectedItem(true);
        if (selectedItem == null)
        {
            return false;
        }
        if (selectedItem.onAction == null)
        {
            return false;
        }
        //animator.SetTrigger("act");<- 상호작용 애니메이션 삽입
        playerCnt.currentState = PlayerState.Action;
        StartCoroutine(playerCnt.ActionStateCooldown());
        print("액션");
        bool complete = selectedItem.onAction.OnApply(position);

        if (complete == true)
        {
            if (selectedItem.onItemUsed != null)
            {
                selectedItem.onItemUsed.OnItemUsed(selectedItem, GameManager.instance.inventoryContainer);
            }
        }

        return complete;
    }
        
    private void UseToolGrid()
    {
        if (selectable == true)
        {
            Item selectedItem = InventoryManager.instance.GetSelectedItem(false);

            if (selectedItem == null)
            {
                return;
            }
            if (selectedItem.onTileMapAction == null)
            {
                return;
            }

            //animator.SetTrigger("act");<- 상호작용 애니메이션 삽입
            playerCnt.currentState = PlayerState.Action;
            StartCoroutine(playerCnt.ActionStateCooldown());
            print("액션");
            bool complete = selectedItem.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController, selectedItem);

            if (complete == true)
            {
                if (selectedItem.onItemUsed != null)
                {
                    selectedItem.onItemUsed.OnItemUsed(selectedItem, GameManager.instance.inventoryContainer);
                }
            }
        }
    }
}
