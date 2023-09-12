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
            hairTempAnimNum = hairAnimNum;  // �ӽ� ������ ���� ����
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("hairAnimationNum", hairTempAnimNum);  // Animator�� ���� ����
                }
            }
            StartCoroutine(ResetHairAnimNum(hairTempAnimNum));  // �ڷ�ƾ ȣ��
        }

        if (faceAnimNum != 0)
        {
            faceTempAnimNum = faceAnimNum;  // �ӽ� ������ ���� ����
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("faceAnimationNum", faceTempAnimNum);  // Animator�� ���� ����
                }
            }
            StartCoroutine(ResetFaceAnimNum(faceTempAnimNum));  // �ڷ�ƾ ȣ��
        }
        if (bodyAnimNum != 0)
        {
            bodyTempAnimNum = bodyAnimNum;  // �ӽ� ������ ���� ����
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bodyAnimationNum", bodyTempAnimNum);  // Animator�� ���� ����
                }
            }
            StartCoroutine(ResetBodyAnimNum(bodyTempAnimNum));  // �ڷ�ƾ ȣ��
        }
        if (topAnimNum != 0)
        {
            topTempAnimNum = topAnimNum;  // �ӽ� ������ ���� ����
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("topAnimationNum", topTempAnimNum);  // Animator�� ���� ����
                }
            }
            StartCoroutine(ResetTopAnimNum(topTempAnimNum));  // �ڷ�ƾ ȣ��
        }
        if (bottomAnimNum != 0)
        {
            bottomTempAnimNum = bottomAnimNum;  // �ӽ� ������ ���� ����
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bottomAnimationNum", bottomTempAnimNum);  // Animator�� ���� ����
                }
            }
            StartCoroutine(ResetBottomAnimNum(bottomTempAnimNum));  // �ڷ�ƾ ȣ��
        }

        IEnumerator ResetHairAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1�� ���
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("hairAnimationNum", 0);  // ���� 0���� ����
                }
            }
            hairAnimNum = 0;  // �ܺο��� �����ϴ� ������ 0���� ����
        }
        IEnumerator ResetFaceAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1�� ���
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("faceAnimationNum", 0);  // ���� 0���� ����
                }
            }
            faceAnimNum = 0;  // �ܺο��� �����ϴ� ������ 0���� ����

        }
        IEnumerator ResetBodyAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1�� ���
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bodyAnimationNum", 0);  // ���� 0���� ����
                }
            }
            bodyAnimNum = 0;  // �ܺο��� �����ϴ� ������ 0���� ����
        }
        IEnumerator ResetTopAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1�� ���
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("topAnimationNum", 0);  // ���� 0���� ����
                }
            }
            topAnimNum = 0;  // �ܺο��� �����ϴ� ������ 0���� ����
        }
        IEnumerator ResetBottomAnimNum(int animationNumber)
        {
            yield return new WaitForSeconds(1f);  // 1�� ���
            foreach (Animator anim in partsAnim)
            {
                if (anim != null)
                {
                    anim.SetInteger("bottomAnimationNum", 0);  // ���� 0���� ����
                }
            }
            bottomAnimNum = 0;  // �ܺο��� �����ϴ� ������ 0���� ����
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        vec2 = new Vector2(horizontal, vertical).normalized;


        foreach (Animator anim in partsAnim) // ������ �κ�: Animator �迭�� ���� foreach ���� �߰�

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
