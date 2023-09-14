using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider slider; // 슬라이더 참조를 할당하기 위한 public 변수

    private void Update()
    {
        // Spacebar를 누를 때 슬라이더의 fill area 크기를 줄입니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseFillArea();
        }
    }

    private void DecreaseFillArea()
    {
        // 슬라이더의 fill area 크기를 줄입니다.
        slider.value -= 0.05f; // 원하는 크기 조절 값으로 변경할 수 있습니다.
    }
}
