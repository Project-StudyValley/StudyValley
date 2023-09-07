using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: �÷��̾ FSM ���̾�׷��� ���� ���� ��Ű�� �ʹ�.
//�ʿ�Ӽ�: �÷��̾� ����

public class Player_FSM : MonoBehaviour
{
    public enum PlayerState
    {
        UpIdle,
        UpMove,
        DownIdle,
        DownMove,
        LeftIdle,
        LeftMove,
        RightIdle,
        RightMove

    }
    public PlayerState playerState;

    public float moveX;
    public float moveY;
    public float lastmoveX;
    public float lastmoveY;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerState.UpIdle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerState)
        {
            case PlayerState.UpIdle:
                UpIdle();
                break;
            case PlayerState.DownIdle:
                DownIdle();
                break;
            case PlayerState.LeftIdle:
                LeftIdle();
                break;
            case PlayerState.RightIdle:
                RightIdle();
                break;
            case PlayerState.UpMove:
                UpMove();
                break;
            case PlayerState.DownMove:
                DownMove();
                break;
            case PlayerState.LeftMove:
                LeftMove();
                break;
            case PlayerState.RightMove:
                RightMove();
                break;


        }

        if(moveX > 0.1)
        {
            playerState = PlayerState.UpIdle;
        }
    }
    private void UpIdle()
    {
        animator.SetTrigger("UpIdle");
    }
    private void UpMove()
    {

    }
    private void DownIdle()
    {

    }
    private void DownMove()
    {

    }
    private void LeftIdle()
    {

    }
    private void LeftMove()
    {

    }
    private void RightIdle()
    {

    }
    private void RightMove()
    {

    }
}

