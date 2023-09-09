using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWH_Controller : MonoBehaviour
{
   
    private Rigidbody2D playerRB;
    private Animator[] partsAnim;
    private BoxCollider2D boxCollider;

    private Vector2 vec2;

    [SerializeField]
    private float speed;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        partsAnim = GetComponentsInChildren<Animator>();
        
        this.transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                    anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
                }
            }
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        vec2 = new Vector2(horizontal, vertical).normalized;


        foreach (Animator anim in partsAnim) // 수정된 부분: Animator 배열에 대한 foreach 루프 추가

        {
            //if (anim != null)
            {
                anim.SetFloat("moveX", horizontal);
                anim.SetFloat("moveY", vertical);
            }

        }
        Move();
    }

    private void Move()
    {
        playerRB.velocity = vec2 * speed;
    }
}
