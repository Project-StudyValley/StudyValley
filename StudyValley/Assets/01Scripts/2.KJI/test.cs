using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class test : MonoBehaviour
{

    public Grid grid;
    public Tilemap tilemap;
    public Tile[] testTile;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(tilemap.GetTile(grid.WorldToCell(transform.position)) == testTile[0])
            {
                tilemap.SetTile(grid.WorldToCell(transform.position), testTile[1]);
            }
            else if (tilemap.GetTile(grid.WorldToCell(transform.position)) == testTile[1])
            {
                tilemap.SetTile(grid.WorldToCell(transform.position), testTile[2]);
            }
            else if (tilemap.GetTile(grid.WorldToCell(transform.position)) == testTile[2])
            {
                tilemap.SetTile(grid.WorldToCell(transform.position), testTile[3]);
            }
            else if (tilemap.GetTile(grid.WorldToCell(transform.position)) == testTile[3])
            {
                tilemap.SetTile(grid.WorldToCell(transform.position), testTile[4]);
            }
            else if (tilemap.GetTile(grid.WorldToCell(transform.position)) == testTile[4])
            {
                tilemap.SetTile(grid.WorldToCell(transform.position), testTile[5]);
            }
            else
            {
                tilemap.SetTile(grid.WorldToCell(transform.position), testTile[0]);
            }


        }
    }
}
