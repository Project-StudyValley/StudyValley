using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public int spawnCont;
    public GameObject[] itam;

    void Update()
    {   //Ű�Է��Ҷ� -> Ÿ�ϸ� ����ɶ��� ����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < spawnCont; i++)
            {
                Instantiate(itam[1]);

                
            }
        }
    }
    
}
