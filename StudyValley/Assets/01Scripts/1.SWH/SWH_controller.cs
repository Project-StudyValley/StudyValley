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

    
    public int hairAnimNum = 0;
    public int faceAnimNum = 0;
    public int bodyAnimNum = 0;
    public int topAnimNum = 0;
    public int bottomAnimNum = 0;

    private int hairTempAnimNum = 0;
    private int faceTempAnimNum = 0;
    private int bodyTempAnimNum = 0;
    private int topTempAnimNum = 0;
    private int bottomTempAnimNum = 0;

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

        if (hairAnimNum != 0)
        {
            hairTempAnimNum = hairAnimNum;  // 임시 변수에 값을 저장
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("hairAnimationNum", hairTempAnimNum);  // Animator에 값을 설정
                }
            }
            StartCoroutine(ResetHairAnimNum(hairTempAnimNum));  // 코루틴 호출
        }

        if (faceAnimNum != 0)
        {
            faceTempAnimNum = faceAnimNum;  // 임시 변수에 값을 저장
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("faceAnimationNum", faceTempAnimNum);  // Animator에 값을 설정
                }
            }
            StartCoroutine(ResetFaceAnimNum(faceTempAnimNum));  // 코루틴 호출
        }
        if (bodyAnimNum != 0)
        {
            bodyTempAnimNum = bodyAnimNum;  // 임시 변수에 값을 저장
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bodyAnimationNum", bodyTempAnimNum);  // Animator에 값을 설정
                }
            }
            StartCoroutine(ResetBodyAnimNum(bodyTempAnimNum));  // 코루틴 호출
        }
        if (topAnimNum != 0)
        {
            topTempAnimNum = topAnimNum;  // 임시 변수에 값을 저장
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("topAnimationNum", topTempAnimNum);  // Animator에 값을 설정
                }
            }
            StartCoroutine(ResetTopAnimNum(topTempAnimNum));  // 코루틴 호출
        }
        if (bottomAnimNum != 0)
        {
            bottomTempAnimNum = bottomAnimNum;  // 임시 변수에 값을 저장
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bottomAnimationNum", bottomTempAnimNum);  // Animator에 값을 설정
                }
            }
            StartCoroutine(ResetBottomAnimNum(bottomTempAnimNum));  // 코루틴 호출
        }

        IEnumerator ResetHairAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1초 대기
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("hairAnimationNum", 0);  // 값을 0으로 설정
                }
            }
            hairAnimNum = 0;  // 외부에서 참조하는 변수도 0으로 설정
        }
        IEnumerator ResetFaceAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1초 대기
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("faceAnimationNum", 0);  // 값을 0으로 설정
                }
            }
            faceAnimNum = 0;  // 외부에서 참조하는 변수도 0으로 설정

        }
        IEnumerator ResetBodyAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1초 대기
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bodyAnimationNum", 0);  // 값을 0으로 설정
                }
            }
            bodyAnimNum = 0;  // 외부에서 참조하는 변수도 0으로 설정
        }
        IEnumerator ResetTopAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1초 대기
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("topAnimationNum", 0);  // 값을 0으로 설정
                }
            }
            topAnimNum = 0;  // 외부에서 참조하는 변수도 0으로 설정
        }
        IEnumerator ResetBottomAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1초 대기
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bottomAnimationNum", 0);  // 값을 0으로 설정
                }
            }
            bottomAnimNum = 0;  // 외부에서 참조하는 변수도 0으로 설정
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
