using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    public static TileMapManager instance;

    public Tile hotPepper_Tile;
    public Tile corn_Tile;
    public Tile pumpkin_Tile;
    [HideInInspector]
    public List<Tile> tiles;


    public List<Tile> hotPepper_Grow_Tile;
    public List<Tile> corn_Grow_Tile;
    public List<Tile> pumpkin_Grow_Tile;

    public Dictionary<Tile, List<Tile>> fruit_Grow;

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
        fruit_Grow = new Dictionary<Tile, List<Tile>>();

        tiles.Add(hotPepper_Tile);
        tiles.Add(corn_Tile);
        tiles.Add(pumpkin_Tile);

        fruit_Grow.Add(hotPepper_Tile, hotPepper_Grow_Tile);
        fruit_Grow.Add(corn_Tile, corn_Grow_Tile);
        fruit_Grow.Add(pumpkin_Tile, pumpkin_Grow_Tile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
