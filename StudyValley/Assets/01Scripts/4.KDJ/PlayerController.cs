using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        Move();
    }

    private void Move()
    {
        playerRB.velocity = vec2 * speed;
    }
}

