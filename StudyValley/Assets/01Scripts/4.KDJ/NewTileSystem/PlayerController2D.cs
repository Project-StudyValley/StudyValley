using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnim;

    private Vector2 motionVector;
    public Vector2 lastMotionVector;
    [SerializeField]
    private float speed;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(horizontal, vertical);
        playerAnim.SetFloat("moveX", horizontal);
        playerAnim.SetFloat("moveY", vertical);

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            playerAnim.SetFloat("lastMoveX", horizontal);
            playerAnim.SetFloat("lastMoveY", vertical);
        }

        Move();
    }

    private void Move()
    {
        playerRB.velocity = motionVector * speed;
    }
}
