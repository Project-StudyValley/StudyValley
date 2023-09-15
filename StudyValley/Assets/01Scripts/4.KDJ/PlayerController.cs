using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    private Rigidbody2D playerRB;
    private Animator playerAnim;
    private BoxCollider2D boxCollider;

    private Vector2 vec2;

    public string currentMapName;

    public GameObject storeNpc;

    [SerializeField]
    private float speed;

    Vector3 playerDirection;
    public LayerMask layerMask;
    Vector2 rayDirection;

    GameObject storageInventory;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);

            playerRB = GetComponent<Rigidbody2D>();
            playerAnim = GetComponent<Animator>();
            boxCollider = GetComponent<BoxCollider2D>();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rayDirection = new Vector2(transform.position.x, transform.position.y - 0.3f);
        Debug.DrawRay(rayDirection, playerDirection, new Color(1, 0, 0));
        RaycastHit2D interactionObject = Physics2D.Raycast(rayDirection, playerDirection, 1f, layerMask);

        // 창고 상호작용
        if (interactionObject.collider != null)
        {
            Storage storage = interactionObject.collider.gameObject.GetComponent<Storage>();
            storageInventory = interactionObject.collider.gameObject.GetComponent<Storage>().storageInventory;
            print(interactionObject.collider.gameObject.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (InventoryManager.instance.mainInventoryGroup.activeInHierarchy) 
                //    return;

                //GetComponent<RectTransform>().anchoredPosition
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
                    //Debug.Log("디버그");
                    ////창고
                    //storageInventory.SetActive(!storageInventory.activeInHierarchy);
                    ////인벤토리
                    //InventoryManager.instance.mainInventoryGroup.SetActive(!InventoryManager.instance.mainInventoryGroup.activeInHierarchy);
                    //InventoryManager.instance.toolBar.SetActive(!InventoryManager.instance.toolBar.activeInHierarchy);

                    RectTransform mainInvenRT = InventoryManager.instance.mainInventory.GetComponent<RectTransform>();

                    //mainInvenRT.anchoredPosition = new Vector2(0, -330); // 추가 수정 필요


                    if (storageInventory.activeInHierarchy == false)
                    {
                        storageInventory.SetActive(true);
                        InventoryManager.instance.mainInventoryGroup.SetActive(true);
                        InventoryManager.instance.toolBar.SetActive(false);
                        mainInvenRT.anchoredPosition = new Vector2(0, -330);
                    }
                    else
                    {
                        Debug.Log("도착");
                        storageInventory.SetActive(false);
                        InventoryManager.instance.mainInventoryGroup.SetActive(false);
                        InventoryManager.instance.toolBar.SetActive(true);
                        mainInvenRT.anchoredPosition = new Vector2(0, 0);
                    }
                }
            }
        }

        // 인벤토리
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
    }

    void FixedUpdate()
    {
        if (storageInventory != null)
        {
            if (storageInventory.activeInHierarchy)
                return;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        vec2 = new Vector2(horizontal, vertical);
        playerAnim.SetFloat("moveX", horizontal);
        playerAnim.SetFloat("moveY", vertical);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        if (horizontal > 0)
        {
            playerDirection = Vector3.right;
        }
        else if (horizontal < 0)
        {
            playerDirection = Vector3.left;
        }
        else if (vertical > 0)
        {
            playerDirection = Vector3.up;
        }
        else if (vertical < 0)
        {
            playerDirection = Vector3.down;
        }

        Move();
    }

    private void Move()
    {
        playerRB.velocity = vec2 * speed;
    }
}

