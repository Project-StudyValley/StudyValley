using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    

    [SerializeField]
    private float speed;

    //enum PlayerDirection
    //{
    //    up,
    //    down,
    //    left,
    //    right
    //}

    Vector3 playerDirection;
    public LayerMask layerMask;
    Vector2 rayDirection;

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

        if (interactionObject.collider != null)
        {
            print(interactionObject.collider.gameObject.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Storage storage = interactionObject.collider.gameObject.GetComponent<Storage>();
                if (!InventoryManager.instance.mainInventory.activeSelf &&
                    !storage.storageInventory.activeSelf)
                {
                    storage.storageInventory.SetActive(true);
                    InventoryManager.instance.mainInventory.SetActive(true);
                }
                else
                {
                    storage.storageInventory.SetActive(false);
                    InventoryManager.instance.mainInventory.SetActive(false);
                }
                
                //GetComponent<RectTransform>().anchoredPosition
                //if (interactionObject.transform.GetChild(0).gameObject.activeInHierarchy)
                //{
                //    interactionObject.transform.GetChild(0).gameObject.SetActive(false);
                //}
                //else
                //{
                //    interactionObject.transform.GetChild(0).gameObject.SetActive(true);
                //}                
            }
        }
        /*        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;*/
    }

    void FixedUpdate()
    { 

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
       
        //if (interactionObject.collider.gameObject.layer == 7)
        //{

        //}
    }

    private void Move()
    {
        playerRB.velocity = vec2 * speed;
    }
}

