using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// �����ϴ� ���
// 1. ������ �����Ͱ� ����
// 2. �����͸� ���̽����� ��ȯ
// 3. ���̽��� �ܺο� ����

// �ҷ����� ���
// 1. �ܺο� ����� ���̽��� ������
// 2. ���̽��� ������ ���·� ��ȯ 
// 3. �ҷ��� �����͸� ���
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
