using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartPoint : MonoBehaviour
{
    public string startPoint;           //�̵� �Ǿ�� �� �̸��� üũ�ϱ����� ����

    private CameraManager theCamera;    //�ڿ������� ī�޶� �̵��� ���� ������ ī�޶� ���� 
    private SWH_Controller2 thePlayer; //ĳ���� ��ü�� �������� ���� ����

    private Vector3 cameraVec3;         //ī�޶� ���� ��ġ ���Ͱ�
    public GameObject startCameraPos;   //ī�޶� ������ų ��ġ�� �������ִ� ���ӿ�����Ʈ

    //public PlayerAction playerAction;

    private void Awake()
    {
        //playerAction = GetComponent<PlayerAction>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerAction.instance.ResetGrid();

        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<SWH_Controller2>();


        Scene scene = SceneManager.GetActiveScene();

        cameraVec3 = startCameraPos.gameObject.transform.position;


        if (startPoint == thePlayer.currentMapName)
        {
            //ī�޶��̵�
            theCamera.transform.position = new Vector3(cameraVec3.x, cameraVec3.y, theCamera.transform.position.z);
            //�÷��̾� �̵�
            thePlayer.transform.position = this.transform.position;
            thePlayer.currentMapName = scene.name;

        }

    }
}
