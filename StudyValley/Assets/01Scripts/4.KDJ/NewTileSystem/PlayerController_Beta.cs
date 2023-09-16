using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Beta : MonoBehaviour
{

    private Rigidbody2D playerRB;
    private Animator[] partsAnim;
    private BoxCollider2D boxCollider;
    
    [HideInInspector]
    public Vector2 movement;
    private float moveX = 0;
    private float moveY = 0;
    private string LastDir = "Down";

    public string currentMapName;

    [SerializeField]
    private float speed = 5;
    [SerializeField] 
    private float runSpeed = 8f;
    public bool running;

    public int hairAnimNum = 1;
    public int faceAnimNum = 1;
    public int bodyAnimNum = 1;
    public int topAnimNum = 1;
    public int bottomAnimNum = 1;
    public enum PlayerState
    {
        Idle,
        Move,
        Action
    }
    [HideInInspector]
    public PlayerState currentState;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        partsAnim = GetComponentsInChildren<Animator>();

        this.transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);

        currentState = PlayerState.Idle;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }

        
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        UpdateAnimation();
    }


    private void PlayerMovement()
    {
        if (currentState == PlayerState.Action)
        {
            playerRB.velocity = Vector2.zero; // �׼� ������ �� �̵��� ����
            return; // �Լ��� �������� Ű �Է��� ����
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveX = horizontal;
        moveY = vertical;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            currentState = PlayerState.Move;
            print("�̵� ��");
        }
        else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            if (horizontal == 0 && vertical == 0)
            {
                currentState = PlayerState.Idle;
                //lastMotionVector = new Vector2(horizontal, vertical).normalized;
                print("��������");
            }
        }

/*        if (Input.GetKeyDown(KeyCode.E))
        {
            currentState = PlayerState.Action;
            StartCoroutine(ActionStateCooldown());
            print("�׼�");
        }*/

        movement = new Vector2(horizontal, vertical).normalized;
        playerRB.velocity = movement * (running ? runSpeed : speed);
    }

    public IEnumerator ActionStateCooldown()
    {
        yield return new WaitForSeconds(1f);  // �ൿ ���¸� ������ �ð� (�� ����)
        if (currentState == PlayerState.Action) // ���� ���� ���°� ������ Action�̶��
        {
            currentState = PlayerState.Idle; // ���¸� Idle�� ����
        }
    }
    private void UpdateAnimation()
    {
        
        foreach (Animator anim in partsAnim)
        {
            if (anim == null) continue;
            
            string animPrefix = "";
            string direction = LastDir;
            

            if (moveY > 0) direction = "Up";
            else if (moveY < 0) direction = "Down";
            else if (moveX > 0) direction = "Right";
            else if (moveX < 0) direction = "Left";

            LastDir = direction;

            if (anim.gameObject.name.Contains("hair"))
            {
                
                animPrefix = "hair" + hairAnimNum.ToString("D2");
               
            }            
            else if (anim.gameObject.name.Contains("face"))
            {
                animPrefix = "face" + faceAnimNum.ToString("D2");
                
            }
            else if (anim.gameObject.name.Contains("body"))
            {
                animPrefix = "body" + bodyAnimNum.ToString("D2");
                
            }
            else if (anim.gameObject.name.Contains("top"))
            {
                animPrefix = "top" + topAnimNum.ToString("D2");
                
            }
            else if (anim.gameObject.name.Contains("bottom"))
            {
                animPrefix = "bottom" + bottomAnimNum.ToString("D2");
                
            }

            switch (currentState)
            {
                case PlayerState.Idle:
                    //Debug.Log(animPrefix + "Idle"  + direction);
                    anim.Play(animPrefix + "Idle" + direction, 0);
                    break;
                case PlayerState.Move:
                    //Debug.Log(animPrefix + "Walk"  + direction);
                    anim.Play(animPrefix + "Walk"  + direction, 0);
                    break;
                case PlayerState.Action:
                    //Debug.Log(animPrefix + "Action" + direction);
                    anim.Play(animPrefix + "Action"  + direction, 0);
                    break;
                default:
                    break;
            }
        }
    }
}