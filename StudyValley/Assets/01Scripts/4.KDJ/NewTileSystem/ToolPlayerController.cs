using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolPlayerController : MonoBehaviour
{
    private PlayerController2D playerCnt;
    private Rigidbody2D rgdb2D;

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
    private CropsManager cropsManager;
    [SerializeField]
    private TileData plowableTiles;

    InventorySlot inventorySlot;

    private Vector3Int selectedTilePosition;
    private bool selectable;

    private void Awake()
    {
        playerCnt = GetComponent<PlayerController2D>();
        rgdb2D = GetComponent<Rigidbody2D>();
        inventorySlot = GetComponent<InventorySlot>();
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
        Vector2 position = rgdb2D.position + playerCnt.lastMotionVector * offsetDistance;

        Item selectedItem = InventoryManager.instance.GetSelectedItem(true);
        if (selectedItem == null)
        {
            return false;
        }
        if (selectedItem.onAction == null)
        {
            return false;
        }

        bool complete = selectedItem.onAction.OnApply(position);

        return complete;
    }

    private void UseToolGrid()
    {
        if (selectable == true)
        {
            TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = tileMapReadController.GetTileData(tileBase);
            if (tileData != plowableTiles)
            {
                return;
            }
            if (cropsManager.Check(selectedTilePosition))
            {
                cropsManager.Seed(selectedTilePosition);
            }
            else
            {
                cropsManager.Plow(selectedTilePosition);
            }
        }
    }
}
