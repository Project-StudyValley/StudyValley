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


    Vector3 playerDirection;
    public LayerMask layerMask;
    Vector2 rayDirection;

    GameObject storageInventory;

    Collider2D playerCollider;


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
        boxCollider = GetComponent<BoxCollider2D>();
        playerCollider = GetComponent<Collider2D>();

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

        rayDirection = new Vector2(transform.position.x, transform.position.y - 0.3f);
        Debug.DrawRay(rayDirection, playerDirection, new Color(1, 0, 0));
        RaycastHit2D interactionObject = Physics2D.Raycast(rayDirection, playerDirection, 1f, layerMask);

        // â�� ��ȣ�ۿ�
        if (interactionObject.collider != null)
        {
            Storage storage = interactionObject.collider.gameObject.GetComponent<Storage>();
            storageInventory = interactionObject.collider.gameObject.GetComponent<Storage>().storageInventory;
            print(interactionObject.collider.gameObject.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (InventoryManager.instance.mainInventoryGroup.activeInHierarchy) 
                //    return;    
                //NPC
                if (interactionObject.collider.tag == "NPC")
                {
                    if (interactionObject.transform.GetChild(0).gameObject.activeInHierarchy)
                    {
                        interactionObject.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    else
                    {
                        interactionObject.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
                //Storage
                else if (interactionObject.collider.tag == "Storage")
                {
                    ////â��
                    //storageInventory.SetActive(!storageInventory.activeInHierarchy);
                    ////�κ��丮
                    //InventoryManager.instance.mainInventoryGroup.SetActive(!InventoryManager.instance.mainInventoryGroup.activeInHierarchy);
                    //InventoryManager.instance.toolBar.SetActive(!InventoryManager.instance.toolBar.activeInHierarchy);

                    RectTransform mainInvenRT = InventoryManager.instance.mainInventory.GetComponent<RectTransform>();

                    if (storageInventory.activeInHierarchy == false)
                    {
                        storageInventory.SetActive(true);
                        InventoryManager.instance.mainInventoryGroup.SetActive(true);
                        InventoryManager.instance.toolBar.SetActive(false);
                        mainInvenRT.anchoredPosition = new Vector2(0, -330);
                    }
                    else
                    {
                        storageInventory.SetActive(false);
                        InventoryManager.instance.mainInventoryGroup.SetActive(false);
                        InventoryManager.instance.toolBar.SetActive(true);
                        mainInvenRT.anchoredPosition = new Vector2(0, 0);
                    }
                }
            }
        }

        // �κ��丮
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (storageInventory != null)
            {
                if (storageInventory.activeInHierarchy)
                    return;
            }
            InventoryManager.instance.mainInventoryGroup.SetActive(!InventoryManager.instance.mainInventoryGroup.activeInHierarchy);
            InventoryManager.instance.toolBar.SetActive(!InventoryManager.instance.toolBar.activeInHierarchy);
        }

        //  playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        if (playerCollider.enabled == false)
        {

            StartCoroutine(DropItemWithDelay());

        }

    }



    private void FixedUpdate()
    {
        PlayerMovement();
        UpdateAnimation();
    }

    IEnumerator DropItemWithDelay()
    {
        Collider2D playerCollider = GetComponent<Collider2D>();


        yield return new WaitForSeconds(2.0f);


        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }
        Debug.Log(playerCollider.enabled);
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