using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameManager gameManager;

    public float speed;
    float h, v;
    Rigidbody2D rigid;
    //Animator anim;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 상태변수로 플레이어 이동 제한
        //Move Value
        h = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button Down&Up
        bool hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = gameManager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = gameManager.isAction ? false : Input.GetButtonUp("Vertical");

        //Check Horizontal Move
        //현재 AxisRaw값에 따라 수평, 수직 판단하여 해결
        if (hDown) isHorizonMove = true;
        else if (vDown) isHorizonMove = false;
        else if (hUp || vUp) isHorizonMove = h != 0;

        //Animation
        //같은 값일때 계속 transition을 태우면 명령이 안먹혀서
        //같은 값이 아닐때만 값을 넣어준다.
        //방향변화 매개변수를 추가하여 한번만 실행되도록 함
        //if (anim.GetInteger("hAxisRaw") != (int)h)
        //{
            //anim.SetBool("isChanged", true);
            //anim.SetInteger("hAxisRaw", (int)h);
        //}
        //else if (anim.GetInteger("vAxisRaw") != (int)v)
        //{
            //anim.SetBool("isChanged", true);
            //anim.SetInteger("vAxisRaw", (int)v);
        //}
        //else anim.SetBool("isChanged", false);

        //Direction
        if (vDown && v == 1) dirVec = Vector3.up;
        else if (vDown && v == -1) dirVec = Vector3.down;
        else if (hDown && h == -1) dirVec = Vector3.left;
        else if (hDown && h == 1) dirVec = Vector3.right;

        //scanObject출력
        if (Input.GetButtonDown("Jump") && scanObject != null)
            gameManager.Action(scanObject);
    }

    void FixedUpdate()
    {
        //쯔꾸르풍 게임의 특징 대각선으로 움직일 수 없음을 구현하기 위해
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Ray(조사액션)
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        /*Object라는 레이어를 만들어서 Objcect라는 애만 조사*/
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null) scanObject = rayHit.collider.gameObject;
        else scanObject = null;
    }
}


