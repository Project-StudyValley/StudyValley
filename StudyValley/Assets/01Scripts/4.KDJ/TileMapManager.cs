using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    public static TileMapManager instance;

    public Tile apple_Tile;
    public Tile grape_Tile;
    public Tile waterMelon_Tile;
    
    public List<Tile> tiles;

    public Tile[] apple_Grow_Tile;
    public Tile[] grape_Grow_Tile;
    public Tile[] waterMelon_Grow_Tile;

    public Dictionary<Tile, Tile[]> fruit_Grow;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tiles.Add(apple_Tile);
        tiles.Add(grape_Tile);
        tiles.Add(waterMelon_Tile);

        fruit_Grow.Add(apple_Tile, apple_Grow_Tile);
        fruit_Grow.Add(grape_Tile, grape_Grow_Tile);
        fruit_Grow.Add(waterMelon_Tile, waterMelon_Grow_Tile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
