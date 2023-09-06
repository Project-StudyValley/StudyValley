using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 저장하는 방법
// 1. 저장할 데이터가 존재
// 2. 데이터를 제이슨으로 변환
// 3. 제이슨을 외부에 저장

// 불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터 형태로 변환 
// 3. 불러온 데이터를 사용
public class DataManeger : MonoBehaviour
{
    private static DataManeger instance;

    PlayerData nowPlayer = new PlayerData();

    private void Awake()
    {
        if (instance == null )
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy( instance.gameObject );
        }
        DontDestroyOnLoad( this.gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        string data = JsonUtility.ToJson( nowPlayer );

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
