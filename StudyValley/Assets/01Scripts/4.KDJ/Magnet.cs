using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float moveSpeed = 10f;           //아이템의 이동 속도
    public float magnetDistance = 15f;      //자석 작용 거리

    private Transform player;               //플레이어의 위치를 저장하는 변수

    public ItemDrop itemDrop;

    public Item itemData;
    public GameObject itemGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //플레이어 오브젝트를 찾아서 저장
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemDrop._isGrounded == true)
        {
            //아이템과 플레이어 사이의 거리 계산
            float distance = Vector3.Distance(transform.position, player.position);
            Collider2D playerCollider = PlayerController_Beta.instance.GetComponent<Collider2D>();

            //거리가 magnetDistance이내일 경우 아이템을 플레이어 쪽으로 이동
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
