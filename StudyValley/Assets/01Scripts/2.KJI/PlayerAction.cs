using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerAction : MonoBehaviour
{
    public static PlayerAction instance;

    public Grid grid;

    public Tilemap GrowTileMap;
    public Tilemap SeedTileMap;
    public Tilemap ToolTileMap;

    public List<Tile> GrowTile;
    public List<Tile> SeedTile;
    public List<Tile> ToolTile;

    public int spawnCont;
    public GameObject[] item;

    public Item selectedItem;

    private PlayerController thePlayer;
    private string mainSceneName = "ProtoType_Main";

    public GameObject farmGrid;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            selectedItem = InventoryManager.instance.GetSelectedItem(true);

            if (selectedItem != null)
            {
                switch (selectedItem.actionType)
                {
                    case ActionType.water:

                        //foreach (Tile fruit in TileMapManager.instance.tiles)
                        //{
                        //    if (fruit == GrowTileMap.GetTile(grid.WorldToCell(transform.position)))
                        //    {
                        //        GrowTile = TileMapManager.instance.fruit_Grow[fruit];
                        //    }
                        //}

                        GrowTile = TileMapList(GrowTileMap.GetTile(grid.WorldToCell(transform.position)));

                        if (SeedTileMap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[1])
                        {
                            if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[0])
                            {
                                ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[2]);
                                GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[1]);
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
                                Debug.Log("0");
                            }
                        }
                        else if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[1])
                        {
                            GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[2]);
                            Debug.Log("1");
                        }
                        else if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[2])
                        {
                            GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[3]);
                            Debug.Log("2");
                        }
                        else if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[3])
                        {
                            GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[4]);
                            Debug.Log("3");
                        }
                        else if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[4])
                        {
                            GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[5]);
                            Debug.Log("4");
                        }
                        else if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[5])
                        {
                            GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[0]);
                            ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[0]);

                            for (int i = 0; i < spawnCont; i++)
                            {
                                GameObject itemGO = item[1];
                                itemGO.transform.position = transform.position;
                                Instantiate(itemGO);
                            }
                            Debug.Log("5");

                        }
                        break;

                    case ActionType.dig:
                        //»ð           
                        if (ToolTileMap.GetTile(grid.WorldToCell(transform.position)) == ToolTile[0])
                        {
                            ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[1]);
                        }
                        else
                        {
                            ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[0]);
                        }
                        break;

                    case ActionType.plant1:
                        SeedTile[1] = TileMapManager.instance.hotPepper_Tile;

                        if (ToolTileMap.GetTile(grid.WorldToCell(transform.position)) == ToolTile[1])
                        {
                            //¾¾¾Ñ            
                            if (SeedTileMap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[0])
                            {
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[1]);
                                Debug.Log("Pepper");
                            }
                            else
                            {
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
                            }
                        }
                        break;
                    case ActionType.plant2:
                        SeedTile[1] = TileMapManager.instance.corn_Tile;

                        if (ToolTileMap.GetTile(grid.WorldToCell(transform.position)) == ToolTile[1])
                        {
                            //¾¾¾Ñ            
                            if (SeedTileMap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[0])
                            {
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[1]);
                                Debug.Log("corn");

                            }
                            else
                            {
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
                            }
                        }
                        break;
                    case ActionType.plant3:
                        SeedTile[1] = TileMapManager.instance.pumpkin_Tile;

                        if (ToolTileMap.GetTile(grid.WorldToCell(transform.position)) == ToolTile[1])
                        {
                            //¾¾¾Ñ            
                            if (SeedTileMap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[0])
                            {
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[1]);
                                Debug.Log("pumpkin");

                            }
                            else
                            {
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
                            }
                        }
                        break;
                }

                /*  //¶¥Á¥°ÔÇÏ±â
                 else if (selectedItem.actionType == ActionType.water)
                 {                                
                      if (ToolTileMap.GetTile(grid.WorldToCell(transform.position)) == ToolTile[0])
                     {
                          ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[2]);
                     }
                 }*/
            }
        }
    }
    public void ResetGrid()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
/*        if (mainSceneName == thePlayer.currentMapName)
        {*/
            GrowTileMap = GameObject.Find("GrowTileMap").GetComponent<Tilemap>();
            SeedTileMap = GameObject.Find("SeedTileMap").GetComponent<Tilemap>();
            ToolTileMap = GameObject.Find("ToolTileMap").GetComponent<Tilemap>();
      /*  }*/
    }

    private List<Tile> TileMapList(TileBase tile)
    {
        foreach (var fruit in TileMapManager.instance.tiles)
        {
            Debug.Log("123");
/*            if (fruit == tile)
            {*/
               
                return TileMapManager.instance.fruit_Grow[fruit];
/*            }*/
        }
        return null;
    }
}
