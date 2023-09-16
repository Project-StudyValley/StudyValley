using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static PlayerController_Beta;

public class ToolPlayerController : MonoBehaviour
{
    private PlayerController_Beta playerCnt;
    private Rigidbody2D rgdb2D;
    private Animator animator;

    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

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

    InventorySlot[] inventorySlot;

    private Vector3Int selectedTilePosition;
    private bool selectable;

    private void Awake()
    {
        playerCnt = GetComponent<PlayerController_Beta>();
        rgdb2D = GetComponent<Rigidbody2D>();
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

        Item selectedItem = InventoryManager.instance.GetSelectedItem(false);
        if (selectedItem == null)
        {
            return false;
        }
        bool complete = false;
        if (selectedItem.durability >= 1 && selectedItem.onAction != null)
        {
            //animator.SetTrigger("act");<- 상호작용 애니메이션 삽입
            playerCnt.currentState = PlayerState.Action;
            StartCoroutine(playerCnt.ActionStateCooldown());
            print("액션1");
            complete = selectedItem.onAction.OnApply(position);

            if (complete == true && selectedItem.itemType == ItemType.tool)
            {
                selectedItem.DecreaseDurability();
                if (selectedItem.onItemUsed != null)
                {
                    selectedItem.onItemUsed.OnItemUsed(selectedItem, inventoryManager);
                }
            }
        }

        return complete;
    }
        
    private void UseToolGrid()
    {
        if (selectable == true)
        {
            Item selectedItem = InventoryManager.instance.GetSelectedItem(true);

            if (selectedItem == null)
            {
                return;
            }
            bool complete = false;
            if (selectedItem.durability >= 1 && selectedItem.onTileMapAction != null)
            {
                playerCnt.currentState = PlayerState.Action;
                StartCoroutine(playerCnt.ActionStateCooldown());
                print("액션2");
                complete = selectedItem.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController, selectedItem);

                if (complete == true && selectedItem.itemType == ItemType.tool)
                {
                    selectedItem.DecreaseDurability();
                    Debug.Log("내구도 감소");
                    if (selectedItem.onItemUsed != null)
                    {
                        selectedItem.onItemUsed.OnItemUsed(selectedItem, inventoryManager);
                    }
                }
            }
        }
    }
}
