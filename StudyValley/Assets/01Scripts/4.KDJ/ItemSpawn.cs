using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public int spawnCont;
    public GameObject[] itam;

    void Update()
    {   //키입력할때 -> 타일맵 변경될때로 수정
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < spawnCont; i++)
            {
                Instantiate(itam[1]);

                
            }
        }
    }
    
}
