using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour
{

    public string startPoint;           //이동 되어온 맵 이름을 체크하기위한 변수

    private PlayerController thePlayer; //캐릭터 객체를 가져오기 위한 변수
    private CameraManager theCamera;    //자연스러운 카메라 이동을 위해 가져온 카메라 변수 

    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerController>();
        Scene scene = SceneManager.GetActiveScene();

        if (startPoint == thePlayer.currentMapName)
        {
            //카메라이동
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            //플레이어 이동
            thePlayer.transform.position = this.transform.position;
            thePlayer.currentMapName = scene.name;
        }
    }
}
