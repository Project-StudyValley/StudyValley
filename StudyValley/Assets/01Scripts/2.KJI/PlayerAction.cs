using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class PlayerAction : MonoBehaviour
{
    public static PlayerAction instance;

    public Grid grid;

    public Tilemap GrowTileMap;
    public Tilemap SeedTileMap;
    public Tilemap ToolTileMap;
    public Tilemap WetTileMap;

    public List<Tile> GrowTile;
    public List<Tile> SeedTile;
    public List<Tile> ToolTile;
    public List<Tile> WetTile;


    public int spawnCont;
    public GameObject[] spawnItem;

    public Dictionary<Tile, GameObject> LastSpawnItem;

    public Item selectedItem;

    public PlayerController thePlayer;
    public string mainSceneName = "ProtoType_Main";


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

    private void Start()
    {
        LastSpawnItem = new Dictionary<Tile, GameObject>();

        LastSpawnItem.Add(TileMapManager.instance.hotPepper_Grow_Tile[5], spawnItem[0]);
        LastSpawnItem.Add(TileMapManager.instance.corn_Grow_Tile[5], spawnItem[1]);
        LastSpawnItem.Add(TileMapManager.instance.pumpkin_Grow_Tile[5], spawnItem[2]);

    }
    void Update()
    {
        if (mainSceneName == thePlayer.currentMapName)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {


                selectedItem = InventoryManager.instance.GetSelectedItem(false);


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

                            GrowTile = TileMapList(SeedTileMap.GetTile(grid.WorldToCell(transform.position)));

                            try
                            {

                                if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[0])
                                {
                                    if (SeedTileMap.GetTile(grid.WorldToCell(transform.position)) != SeedTile[0])
                                    {
                                        ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[2]);
                                        GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[1]);
                                        WetTileMap.SetTile(grid.WorldToCell(transform.position), WetTile[1]);
                                        //SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
                                        //SeedTile[1].GetComponent<Transform>().localScale = Vector2.one * Mathf.Clamp(0, 0, 0);
                                        Debug.Log("0");
                                    }
                                }
                            }
                            catch
                            {
                                return;
                            }

                            if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[1])
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
                                WetTileMap.SetTile(grid.WorldToCell(transform.position), WetTile[0]);
                                SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);

                                /*                                for (int i = 0; i < spawnCont; i++)
                                                                {
                                                                    GameObject itemGO = spawnItem[1];
                                                                    itemGO.transform.position = transform.position;
                                                                    Instantiate(itemGO);
                                                                }*/
                                ObjectSpawner(GrowTile[5]);
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
                            selectedItem = InventoryManager.instance.GetSelectedItem(true);

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
                            selectedItem = InventoryManager.instance.GetSelectedItem(true);

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
                            selectedItem = InventoryManager.instance.GetSelectedItem(true);

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
    }
    public void ResetGrid()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();

        try
        {
            GameObject.Find("GrowTileMap").GetComponent<Tilemap>();
            GrowTileMap = GameObject.Find("GrowTileMap").GetComponent<Tilemap>();
        }
        catch (Exception e)
        {
            GrowTileMap = null;
        }

        try
        {
            GameObject.Find("SeedTileMap").GetComponent<Tilemap>();
            SeedTileMap = GameObject.Find("SeedTileMap").GetComponent<Tilemap>();
        }
        catch (Exception e)
        {
            SeedTileMap = null;
        }

        try
        {
            GameObject.Find("ToolTileMap").GetComponent<Tilemap>();
            ToolTileMap = GameObject.Find("ToolTileMap").GetComponent<Tilemap>();
        }
        catch (Exception e)
        {
            ToolTileMap = null;
        }

    }

    private List<Tile> TileMapList(TileBase tile)
    {
        foreach (var Vegetavle in TileMapManager.instance.tiles)
        {
            Debug.Log("123");
            Debug.Log(Vegetavle);
            Debug.Log(tile);
            if (Vegetavle == tile)
            {

                Debug.Log("111");
                return TileMapManager.instance.fruit_Grow[Vegetavle];
            }
        }
        return null;
    }

    public void ObjectSpawner(Tile _tile)
    {
        for (int i = 0; i < spawnCont; i++)
        {
            GameObject itemGO = LastSpawnItem[_tile];
            itemGO.transform.position = transform.position;
            Instantiate(itemGO);
        }
    }
}
