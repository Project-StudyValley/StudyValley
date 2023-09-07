using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TilemapManager : MonoBehaviour
{

    public Grid grid;
    public Tilemap Wettilemap;
    public Tilemap Seedtilemap;
    public Tile[] SeedTile;
    public Tile[] WetTile;
    private Tilemapstate currentState;

    public enum Tilemapstate
    {
        Dry,
        Wet

    }
    private void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//Space바(씨앗)를 이용해 작물을 심을 수 있다.
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


        if (Input.GetKeyDown(KeyCode.LeftAlt))//Alt키(물뿌리개) 입력시 물에 젖은 땅이 생긴다.
        {
            if (Wettilemap.GetTile(grid.WorldToCell(transform.position)) == WetTile[0])
            {
                Wettilemap.SetTile(grid.WorldToCell(transform.position), WetTile[1]);

                StartCoroutine(StateTransitionCoroutine(transform.position));
            }

            else
            {
 

            }
        }
                
    }
    //마른 땅에 물을 줘서 젖은 땅으로 바꾼다
    //젖은 땅은 30초가 지나면 마른 땅으로 돌아온다.

    IEnumerator StateTransitionCoroutine(Vector3 position)
    {

        //3초 기다린다.
        yield return new WaitForSeconds(3.0f);

        //젖은땅이 마른땅이 된다.
        Wettilemap.SetTile(grid.WorldToCell(position), WetTile[0]);
    }

}
