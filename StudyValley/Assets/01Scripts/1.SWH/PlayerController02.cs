using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController02 : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnim;

    private GameObject scanObject;
    private Vector2 vec2;



    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        /*        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;*/

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        vec2 = new Vector2(horizontal, vertical);
        playerAnim.SetFloat("moveX", horizontal);
        playerAnim.SetFloat("moveY", vertical);

        Move();
    }

    private void Move()
    {
        playerRB.velocity = vec2 * speed;
    }
}

