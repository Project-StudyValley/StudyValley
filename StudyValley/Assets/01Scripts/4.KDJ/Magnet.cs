using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float moveSpeed = 10f;           //�������� �̵� �ӵ�
    public float magnetDistance = 15f;      //�ڼ� �ۿ� �Ÿ�

    private Transform player;               //�÷��̾��� ��ġ�� �����ϴ� ����

    public ItemDrop itemDrop;

    public Item itemData;
    public GameObject itemGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //�÷��̾� ������Ʈ�� ã�Ƽ� ����
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemDrop._isGrounded == true)
        {
            //�����۰� �÷��̾� ������ �Ÿ� ���
            float distance = Vector3.Distance(transform.position, player.position);
            Collider2D playerCollider = PlayerController_Beta.instance.GetComponent<Collider2D>();

            //�Ÿ��� magnetDistance�̳��� ��� �������� �÷��̾� ������ �̵�
            if (distance <= magnetDistance && playerCollider.enabled)
            {                
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (itemDrop._isGrounded == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                InventoryManager.instance.AddItem(itemData);
                Destroy(itemGameObject);

                Debug.Log(itemData);
            }
        }
    }
/*    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(itemData);
            Destroy(gameObject);

            Debug.Log(itemData);
        }
    }*/
}
