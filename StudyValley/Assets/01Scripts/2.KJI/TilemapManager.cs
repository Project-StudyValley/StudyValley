using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Grid grid;

    public Tilemap GrowTileMap;
    public Tilemap SeedTileMap;
    public Tilemap ToolTileMap;
    public Tilemap WetTileMap;

    public Tile[] GrowTile;
    public Tile[] SeedTile;
    public Tile[] ToolTile;
    public Tile[] WetTile;

    public int spawnCont;
    public GameObject[] item;

    public Item selectedItem;

    /*    public GameObject itemDrop;*/

    /*    private void Start()
        {
            itemDrop = GameObject.Find("Spawner");
        }*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            selectedItem = InventoryManager.instance.GetSelectedItem(true);

            if (selectedItem != null)
            {
                //¹°ÁÖ±â -> ½Ä¹°ÀÚ¶ó±â
                if (selectedItem.actionType == ActionType.water)
                {
                    if (GrowTileMap.GetTile(grid.WorldToCell(transform.position)) == GrowTile[0])
                    {
                        ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[2]);
                        GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[1]);
                        SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
                        Debug.Log("0");
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
                        GrowTileMap.SetTile(grid.WorldToCell(transform.position), GrowTile[0]);
                        ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[0]);

                        for (int i = 0; i < spawnCont; i++)
                        {
                            GameObject itemGO = item[1];
                            itemGO.transform.position = transform.position;
                            Instantiate(itemGO);
                        }
                        Debug.Log("4");
                    }

                }
                else if (selectedItem.actionType == ActionType.dig)
                {
                    //»ð           
                    if (ToolTileMap.GetTile(grid.WorldToCell(transform.position)) == ToolTile[0])
                    {
                        ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[1]);
                    }
                    else
                    {
                        ToolTileMap.SetTile(grid.WorldToCell(transform.position), ToolTile[0]);
                    }
                }
                else if (selectedItem.actionType == ActionType.plant)
                {
                    if (ToolTileMap.GetTile(grid.WorldToCell(transform.position)) == ToolTile[1])
                    {
                        //¾¾¾Ñ            
                        if (SeedTileMap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[0])
                        {
                            SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[1]);
                        }
                        else
                        {
                            SeedTileMap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
                        }
                    }
                }
                /*                //¶¥Á¥°ÔÇÏ±â
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
