using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWH_Controller2 : MonoBehaviour
{

    private Rigidbody2D playerRB;
    private Animator[] partsAnim;
    private BoxCollider2D boxCollider;

    private Vector2 vec2;
    private float moveX = 0;
    private float moveY = 0;
    private string LastDir = "Down";

    [SerializeField]
    private float speed;

    public int hairAnimNum = 1;
    public int faceAnimNum = 1;
    public int bodyAnimNum = 1;
    public int topAnimNum = 1;
    public int bottomAnimNum = 1;
    public enum PlayerState
    {
        Idle,
        Move,
        Action
    }

    private PlayerState currentState;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        partsAnim = GetComponentsInChildren<Animator>();

        this.transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);

        currentState = PlayerState.Idle;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    void Update()
    {
        PlayerMovement();
        UpdateAnimation();
    }

    private void PlayerMovement()
    {
        if (currentState == PlayerState.Action)
        {
            playerRB.velocity = Vector2.zero; // 액션 상태일 때 이동을 중지
            return; // 함수를 빠져나가 키 입력을 무시
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveX = horizontal;
        moveY = vertical;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            currentState = PlayerState.Move;
            print("이동 중");
        }
        else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                currentState = PlayerState.Idle;
                print("정지상태");
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentState = PlayerState.Action;
            StartCoroutine(ActionStateCooldown());
            print("액션");
        }

        Vector2 movement = new Vector2(horizontal, vertical);
        playerRB.velocity = movement.normalized * speed;
    }

    IEnumerator ActionStateCooldown()
    {
        yield return new WaitForSeconds(1f);  // 행동 상태를 유지할 시간 (초 단위)
        if (currentState == PlayerState.Action) // 만약 현재 상태가 여전히 Action이라면
        {
            currentState = PlayerState.Idle; // 상태를 Idle로 변경
        }
    }
    private void UpdateAnimation()
    {
        
        foreach (Animator anim in partsAnim)
        {
            if (anim == null) continue;
            
            string animPrefix = "";
            string direction = LastDir;
            

            if (moveY > 0) direction = "Up";
            else if (moveY < 0) direction = "Down";
            else if (moveX > 0) direction = "Right";
            else if (moveX < 0) direction = "Left";

            LastDir = direction;

            if (anim.gameObject.name.Contains("hair"))
            {
                
                animPrefix = "hair" + hairAnimNum.ToString("D2");
               
            }            
            else if (anim.gameObject.name.Contains("face"))
            {
                animPrefix = "face" + faceAnimNum.ToString("D2");
                
            }
            else if (anim.gameObject.name.Contains("body"))
            {
                animPrefix = "body" + bodyAnimNum.ToString("D2");
                
            }
            else if (anim.gameObject.name.Contains("top"))
            {
                animPrefix = "top" + topAnimNum.ToString("D2");
                
            }
            else if (anim.gameObject.name.Contains("bottom"))
            {
                animPrefix = "bottom" + bottomAnimNum.ToString("D2");
                
            }

            switch (currentState)
            {
                case PlayerState.Idle:
                    //Debug.Log(animPrefix + "Idle"  + direction);
                    anim.Play(animPrefix + "Idle" + direction, 0);
                    break;
                case PlayerState.Move:
                    //Debug.Log(animPrefix + "Walk"  + direction);
                    anim.Play(animPrefix + "Walk"  + direction, 0);
                    break;
                case PlayerState.Action:
                    //Debug.Log(animPrefix + "Action" + direction);
                    anim.Play(animPrefix + "Action"  + direction, 0);
                    break;
                default:
                    break;
            }
        }
    }
}