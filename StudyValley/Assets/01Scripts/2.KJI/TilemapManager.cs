using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{

    public Grid grid;
    public Tilemap Wettilemap;
    public Tilemap Seedtilemap;
    public Tile[] SeedTile;
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
            //¹°»Ñ(±¹¹ä)
            if (selectedItem != null )
            {
                if (selectedItem.actionType == ActionType.water)
                {
                    if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[0])
                    {
                        Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[1]);
                        Debug.Log("0");

                    }
                    else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[1])
                    {

                        Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[2]);
                        Debug.Log("1");
                    }
                    else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[2])
                    {
                        Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[3]);
                        Debug.Log("2");
                    }
                    else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[3])
                    {
                        Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[4]);
                        Debug.Log("3");
                    }
                    else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[4])
                    {

                        Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[5]);
                        Debug.Log("4");
                    }
                    else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[5])
                    {
                        Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);

                        for (int i = 0; i < spawnCont; i++)
                        {

                            GameObject itemGO = item[1];
                            itemGO.transform.position = transform.position;
                            Instantiate(itemGO);
                        }
                        Debug.Log("5");
                    }
                }
                else if (selectedItem.actionType == ActionType.dig)
                {
                    //°î±ªÀÌ            
                    if (Wettilemap.GetTile(grid.WorldToCell(transform.position)) == WetTile[0])
                    {
                        Wettilemap.SetTile(grid.WorldToCell(transform.position), WetTile[1]);                        
                    }
                    else
                    {
                        Wettilemap.SetTile(grid.WorldToCell(transform.position), WetTile[0]);
                    }
                }
            }            
        }       
    }
}
