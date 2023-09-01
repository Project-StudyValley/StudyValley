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
        // ���º����� �÷��̾� �̵� ����
        //Move Value
        h = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button Down&Up
        bool hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = gameManager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = gameManager.isAction ? false : Input.GetButtonUp("Vertical");

        //Check Horizontal Move
        //���� AxisRaw���� ���� ����, ���� �Ǵ��Ͽ� �ذ�
        if (hDown) isHorizonMove = true;
        else if (vDown) isHorizonMove = false;
        else if (hUp || vUp) isHorizonMove = h != 0;

        //Animation
        //���� ���϶� ��� transition�� �¿�� ����� �ȸ�����
        //���� ���� �ƴҶ��� ���� �־��ش�.
        //���⺯ȭ �Ű������� �߰��Ͽ� �ѹ��� ����ǵ��� ��
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

        //scanObject���
        if (Input.GetButtonDown("Jump") && scanObject != null)
            gameManager.Action(scanObject);
    }

    void FixedUpdate()
    {
        //��ٸ�ǳ ������ Ư¡ �밢������ ������ �� ������ �����ϱ� ����
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Ray(����׼�)
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        /*Object��� ���̾ ���� Objcect��� �ָ� ����*/
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null) scanObject = rayHit.collider.gameObject;
        else scanObject = null;
    }
}


