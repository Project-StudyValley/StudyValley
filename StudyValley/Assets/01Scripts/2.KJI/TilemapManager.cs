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
        if (Input.GetKeyDown(KeyCode.Space))//Space��(����)�� �̿��� �۹��� ���� �� �ִ�.
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


        if (Input.GetKeyDown(KeyCode.LeftAlt))//AltŰ(���Ѹ���) �Է½� ���� ���� ���� �����.
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
    //���� ���� ���� �༭ ���� ������ �ٲ۴�
    //���� ���� 30�ʰ� ������ ���� ������ ���ƿ´�.

    IEnumerator StateTransitionCoroutine(Vector3 position)
    {

        //3�� ��ٸ���.
        yield return new WaitForSeconds(3.0f);

        //�������� �������� �ȴ�.
        Wettilemap.SetTile(grid.WorldToCell(position), WetTile[0]);
    }

}
