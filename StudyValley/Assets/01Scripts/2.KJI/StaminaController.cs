using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider slider; // �����̴� ������ �Ҵ��ϱ� ���� public ����

    private void Update()
    {
        // Spacebar�� ���� �� �����̴��� fill area ũ�⸦ ���Դϴ�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseFillArea();
        }
    }

    private void DecreaseFillArea()
    {
        // �����̴��� fill area ũ�⸦ ���Դϴ�.
        slider.value -= 0.05f; // ���ϴ� ũ�� ���� ������ ������ �� �ֽ��ϴ�.
    }
}
