using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour
{

    public string startPoint;           //�̵� �Ǿ�� �� �̸��� üũ�ϱ����� ����

    private PlayerController thePlayer; //ĳ���� ��ü�� �������� ���� ����
    private CameraManager theCamera;    //�ڿ������� ī�޶� �̵��� ���� ������ ī�޶� ���� 

    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerController>();
        Scene scene = SceneManager.GetActiveScene();

        if (startPoint == thePlayer.currentMapName)
        {
            //ī�޶��̵�
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            //�÷��̾� �̵�
            thePlayer.transform.position = this.transform.position;
            thePlayer.currentMapName = scene.name;
        }
    }
}
