using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
        public Animator hairAnimator;
        public Animator faceAnimator;
        public Animator bodyAnimator;
        public Animator shirtsAnimator;
        public Animator pantsAnimator;

        // 외부 변수 또는 스크립트에서 설정할 변수
        public int hairNum = 1;
        public int faceNum = 1;
        public int bodyNum = 1;
        public int ShirtsNum = 1;
        public int pantsNum = 1;

        private void Update()
        {
            
            hairAnimator.SetInteger("AnimationNum", hairNum);
            faceAnimator.SetInteger("AnimationNum", faceNum);
            bodyAnimator.SetInteger("AnimationNum", bodyNum);
            shirtsAnimator.SetInteger("AnimationNum", ShirtsNum);
            pantsAnimator.SetInteger("AnimationNum", pantsNum);
        }

    
    public void increaseHairNum()
    {
        if (hairNum < 4)
        {
            hairNum += +1;
        }
        else if (hairNum > 4)
        {
            hairNum = 1;
        }
        
    }
    public void decreaseHairNum()
    {
        if (hairNum > 1)
        {
            hairNum += -1;
        }
        else if (hairNum < 1)
        {
            hairNum = 3;
        }

    }
    public void increaseFaceNum()
    {
        if (faceNum < 4)
        {
            faceNum += +1;
        }
        else if (faceNum > 4)
        {
            faceNum = 1;
        }

    }
    public void decreaseFaceNum()
    {
        if (faceNum > 1)
        {
            faceNum += -1;
        }
        else if (faceNum < 1)
        {
            faceNum = 3;
        }

    }

}


