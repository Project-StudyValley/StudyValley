using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartPoint : MonoBehaviour
{
    public string startPoint;           //이동 되어온 맵 이름을 체크하기위한 변수

    private CameraManager theCamera;    //자연스러운 카메라 이동을 위해 가져온 카메라 변수 
    private PlayerController_Beta thePlayer; //캐릭터 객체를 가져오기 위한 변수


    private Vector3 cameraVec3;         //카메라 스폰 위치 벡터값
    public GameObject startCameraPos;   //카메라를 스폰시킬 위치를 가지고있는 게임오브젝트

    //public PlayerAction playerAction;
    public ToolPlayerController toolPlayerController;

    private void Awake()
    {
        toolPlayerController = GetComponent<ToolPlayerController>();
        //playerAction = GetComponent<PlayerAction>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerAction.instance.ResetGrid();
        ToolPlayerController.instance.ResetScript();

        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerController_Beta>();


        Scene scene = SceneManager.GetActiveScene();

        cameraVec3 = startCameraPos.gameObject.transform.position;


        if (startPoint == thePlayer.currentMapName)
        {
            //카메라이동
            theCamera.transform.position = new Vector3(cameraVec3.x, cameraVec3.y, theCamera.transform.position.z);
            //플레이어 이동
            thePlayer.transform.position = this.transform.position;
            thePlayer.currentMapName = scene.name;

        }

    }
}
