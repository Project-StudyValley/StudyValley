using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * 0.005f;

        playerAnim.SetFloat("moveX", playerRB.velocity.x);
        playerAnim.SetFloat("moveY", playerRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }


    }

    private void FixedUpdate()
    {
/*        //Ray(조사액션)
        Debug.DrawRay(playerRB.position, vec2 * 0.7f, new Color(0, 1, 0));
        *//*Object라는 레이어를 만들어서 Objcect라는 애만 조사*//*
        RaycastHit2D rayHit = Physics2D.Raycast(playerRB.position, vec2, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null) scanObject = rayHit.collider.gameObject;
        else scanObject = null;*/
    }
}

