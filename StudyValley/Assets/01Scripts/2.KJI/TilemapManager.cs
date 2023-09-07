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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[0])
            {
                Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[1]);
            }
            else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[1])
            {
                Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[2]);
            }
            else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[2])
            {
                Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[3]);
            }
            else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[3])
            {
                Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[4]);
            }
            else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[4])
            {
                Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[5]);
            }
            else if (Seedtilemap.GetTile(grid.WorldToCell(transform.position)) == SeedTile[5])
            {
                Seedtilemap.SetTile(grid.WorldToCell(transform.position), SeedTile[0]);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (Wettilemap.GetTile(grid.WorldToCell(transform.position)) == WetTile[0])
            {
                Wettilemap.SetTile(grid.WorldToCell(transform.position), WetTile[1]);
                print("1");
            }

            else
            {
                Wettilemap.SetTile(grid.WorldToCell(transform.position), WetTile[0]);
            }
        }
    }
}
