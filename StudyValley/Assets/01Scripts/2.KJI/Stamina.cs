using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Stamina : MonoBehaviour
{
    Slider slStamina;
    float fSliderBarTime;
    void Start()
    {
        slStamina = GetComponent<Slider>();
    }


    void Update()
    {
        if (slStamina.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
