using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CropTile
{
    public int growTimer;
    public Crop crop;
}

public class CropsManager : TimeAgent
{
    [SerializeField]
    private TileBase plowed;
    [SerializeField]
    private TileBase seeded;
    [SerializeField]
    private Tilemap seededTilemap;
    [SerializeField]
    private Tilemap plowedTilemap;

    Dictionary<Vector2Int, CropTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
        //onTimeTick += Tick;
        Init();
    }
    public void Tick()
    {
        foreach (CropTile cropTile in crops.Values)
        {
            if (cropTile.crop == null)
            {
                continue;
            }
            cropTile.growTimer += 1;

            if (cropTile.growTimer >= cropTile.crop.timeToGrow)
            {
                Debug.Log("Im done growing");
                cropTile.crop = null;
            }
        }
       
    }

    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }

    public void Plow(Vector3Int position)
    {
        if(crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);
    }   

    public void Seed(Vector3Int position, Crop toSeed)
    {
        seededTilemap.SetTile(position, seeded);

        crops[(Vector2Int)position].crop = toSeed;
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropTile crop = new CropTile();
        crops.Add((Vector2Int)position, crop);

        plowedTilemap.SetTile(position, plowed);
    } 
}
