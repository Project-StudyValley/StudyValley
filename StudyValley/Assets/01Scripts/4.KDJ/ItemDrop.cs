using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


public class ItemDrop : MonoBehaviour
{

    [SerializeField]
    private int maxBounce;      //ƨ��� Ƚ��

    [SerializeField]
    private float xForce;       //x�� ��(�� �ָ�)
    [SerializeField]
    private float yForce;       //y�� ��(�� ����)
    [SerializeField]
    private float gravity;      //�߷� (�������� �ӵ� ����)

    private Vector2 dir;    
    private int currentBounce = 0;
    private bool isGrounded = true;

    private float maxHeight;
    private float currentHeight;

    [SerializeField]
    private Transform sprite;
    [SerializeField]
    private Transform shadow;

    public bool _isGrounded
    {
        get
        {
            return isGrounded;
        }
        set
        {
            isGrounded = value;
        }
    }
    
    void Start()
    {
        currentHeight = Random.Range(yForce - 1, yForce);
        maxHeight = currentHeight;
        Initialize(new Vector2(Random.Range(-xForce, xForce), Random.Range(-xForce, xForce)));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            currentHeight += -gravity * Time.deltaTime;
            sprite.position += new Vector3(0, currentHeight, 0) * Time.deltaTime;
            transform.position += (Vector3)dir * Time.deltaTime;

            float totalVelocity = Mathf.Abs(currentHeight) + Mathf.Abs(maxHeight);
            float scaleXY = Mathf.Abs(currentHeight) / totalVelocity;
            shadow.localScale = Vector2.one * Mathf.Clamp(scaleXY, 0.5f, 1.0f);

            CheckGroundHit();
        }
    }

    void Initialize(Vector2 _direction)
    {
        isGrounded = false;
        maxHeight /= 1.5f;
        dir = _direction;
        currentHeight = maxHeight;
        currentBounce++;
    }

    void CheckGroundHit()
    {
        if(sprite.position.y < shadow.position.y)
        {
            sprite.position = shadow.position;
            shadow.localScale = Vector2.one * Mathf.Clamp(0.2f, 0.2f, 1.0f);

            if (currentBounce < maxBounce)
            {
                Initialize(dir / 1.5f);
            }
            else
            {
                isGrounded = true;
                shadow.localScale = Vector2.one * Mathf.Clamp(0, 0, 0);
            }
        }
    }
}

