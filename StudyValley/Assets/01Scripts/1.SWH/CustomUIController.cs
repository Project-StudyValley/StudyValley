using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomUIController : MonoBehaviour
{
    public Text hairAnimNumText,
                faceAnimNumText,
                bodyAnimNumText,
                topAnimNumText,
                bottomAnimNumText;

    public int maxHairAnimNum = 3,
                maxFaceAnimNum = 3,
                maxBodyAnimNum = 3,
                maxTopAnimNum = 3,
                maxBottomAnimNum = 3;

    public SWH_Controller swhController; // SWH_Controller 스크립트에 대한 참조

    private int currentHairAnimNum = 1,
                currentFaceAnimNum = 1,
                currentBodyAnimNum = 1,
                currentTopAnimNum = 1,
                currentBottomAnimNum = 1;

    void Start()
    {
        UpdateAnimText();
    }

    public void IncreaseHairAnim()
    {
        ChangeAnimNum(ref currentHairAnimNum, maxHairAnimNum);
        swhController.hairAnimNum = currentHairAnimNum;
    }

    public void DecreaseHairAnim()
    {
        ChangeAnimNum(ref currentHairAnimNum, maxHairAnimNum, false);
        swhController.hairAnimNum = currentHairAnimNum;
    }

    // 다른 파트의 애니메이션 숫자를 변경하는 함수들
    public void IncreaseFaceAnim()
    {
        ChangeAnimNum(ref currentFaceAnimNum, maxFaceAnimNum);
        swhController.faceAnimNum = currentFaceAnimNum;
    }
    public void DecreaseFaceAnim()
    {
        ChangeAnimNum(ref currentFaceAnimNum, maxFaceAnimNum, false);
        swhController.faceAnimNum = currentFaceAnimNum;
    }

    public void IncreaseBodyAnim()
    { ChangeAnimNum(ref currentBodyAnimNum, maxBodyAnimNum);
        swhController.bodyAnimNum = currentBodyAnimNum;
    }
    public void DecreaseBodyAnim()
    { ChangeAnimNum(ref currentBodyAnimNum, maxBodyAnimNum, false);
        swhController.bodyAnimNum = currentBodyAnimNum;
    }

    public void IncreaseTopAnim()
    {
        ChangeAnimNum(ref currentTopAnimNum, maxTopAnimNum);
        swhController.topAnimNum = currentTopAnimNum;
    }
    public void DecreaseTopAnim()
    {
        ChangeAnimNum(ref currentTopAnimNum, maxTopAnimNum, false);
        swhController.topAnimNum = currentTopAnimNum;
    }

    public void IncreaseBottomAnim()
    {
        ChangeAnimNum(ref currentBottomAnimNum, maxBottomAnimNum);
        swhController.bottomAnimNum = currentBottomAnimNum;
    }
    public void DecreaseBottomAnim()
    {
        ChangeAnimNum(ref currentBottomAnimNum, maxBottomAnimNum, false);
        swhController.bottomAnimNum = currentBottomAnimNum;
    }

    // 애니메이션 숫자를 증가 또는 감소시키는 보조 함수
    private void ChangeAnimNum(ref int currentAnimNum, int maxAnimNum, bool increase = true)
    {
        if (increase)
        {
            currentAnimNum++;
            if (currentAnimNum > maxAnimNum)
            {
                currentAnimNum = 1;
            }
        }
        else
        {
            currentAnimNum--;
            if (currentAnimNum < 1)
            {
                currentAnimNum = maxAnimNum;
            }
        }
        UpdateAnimText();
    }

    void UpdateAnimText()
    {
        hairAnimNumText.text = "hair" + currentHairAnimNum.ToString("00");
        faceAnimNumText.text = "face" + currentFaceAnimNum.ToString("00");
        bodyAnimNumText.text = "body" + currentBodyAnimNum.ToString("00");
        topAnimNumText.text = "top" + currentTopAnimNum.ToString("00");
        bottomAnimNumText.text = "bottom" + currentBottomAnimNum.ToString("00");
    }
}