using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BaseTilePlayerController : MonoBehaviour
{
    private static BaseTilePlayerController instance;

    private Rigidbody2D playerRB;
    private Animator playerAnim;
    private BoxCollider2D boxCollider;

    private Vector2 vec2;

    public string currentMapName;

    public GameObject storage;

    [SerializeField]
    private float speed;
    [SerializeField]
    private MarkerManager markerManager;
    [SerializeField]
    TileMapReadController tileMapReadController;

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
        Marker();

        rayDirection = new Vector2(transform.position.x, transform.position.y - 0.3f);
        Debug.DrawRay(rayDirection, playerDirection, new Color(1, 0, 0));
        RaycastHit2D interactionObject = Physics2D.Raycast(rayDirection, playerDirection, 1f, layerMask);

        if (interactionObject.collider != null)
        {
            print(interactionObject.collider.gameObject.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (storage.activeSelf)
                {
                    storage.SetActive(false);
                }
                else
                {
                    storage.SetActive(true);
                }               
            }
        }
    }
    private void Marker()
    {
        Vector3Int gridPosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
        markerManager.markedCellPosition = gridPosition;
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
    }

    private void Move()
    {
        playerRB.velocity = vec2 * speed;
    }
}

