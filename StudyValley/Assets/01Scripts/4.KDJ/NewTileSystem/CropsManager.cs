using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CropTile
{
    public int growTimer;
    public int growStage;
    public Crop crop;
    public SpriteRenderer renderer;

    public bool Complate
    {
        get
        {
            if (crop == null)
            {
                return false;
            }
            return growStage >= crop.maxGrowStage;

        }
    }

    internal void Harvested()
    {
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
    }
}

public class CropsManager : TimeAgent
{
    [SerializeField]
    private TileBase plowed;
    [SerializeField]
    private TileBase[] seeded;
    [SerializeField]
    private Tilemap seededTilemap;
    [SerializeField]
    private Tilemap plowedTilemap;
    [SerializeField]
    private GameObject cropsSpritePrefab;

    [SerializeField]
    private GameObject[] fruit;

    Dictionary<Vector2Int, CropTile> crops;

    [SerializeField]
    private int spawnCont = 5;

    [SerializeField]
    float spread = 0.7f;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();

        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (CropTile cropTile in crops.Values)
            {
                if (cropTile.crop == null)
                {
                    continue;
                }
                cropTile.renderer.gameObject.SetActive(true);
                cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];

                cropTile.growStage += 1;
                if (cropTile.growStage >= cropTile.crop.maxGrowStage)
                {
                    cropTile.growStage = 0;
                    for (int i = 0; i < spawnCont; i++)
                    {
                        Vector3 position = transform.position;
                        position.x += spread * UnityEngine.Random.value - spread / 2;
                        position.y += spread * UnityEngine.Random.value - spread / 2;

                        GameObject itemGO = Instantiate(fruit[0]);
                        itemGO.transform.position = position;
                        cropTile.Harvested();
                    }
                }
            }
        }
    }

    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }

    public void Plow(Vector3Int position)
    {
        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);
    }

    public void Seed(Vector3Int position, Crop toSeed)
    {
        seededTilemap.SetTile(position, seeded[0]);

        crops[(Vector2Int)position].crop = toSeed;
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropTile crop = new CropTile();
        crops.Add((Vector2Int)position, crop);

        GameObject go = Instantiate(cropsSpritePrefab);
        go.transform.position = plowedTilemap.CellToWorld(position);
        //go.transform.position -= Vector3.forward * 0.5f;
        go.SetActive(false);
        crop.renderer = go.GetComponent<SpriteRenderer>();

        plowedTilemap.SetTile(position, plowed);
    }

    internal void PickUp(Vector3Int gridPosition)
    {
        Vector2Int position = (Vector2Int)gridPosition;
        if (crops.ContainsKey(position) == false)
        {
            return;
        }

        CropTile cropTile = crops[position];
        if (cropTile.Complate)
        {
            for (int i = 0; i < spawnCont; i++)
            {
                Instantiate(fruit[0]);
                cropTile.Harvested();
            }
        }
    }
}
