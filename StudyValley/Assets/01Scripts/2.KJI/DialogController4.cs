using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController4 : MonoBehaviour
{
    public TMP_Text dialogText;

    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = "";
        string sampleText = "운동은 습관이다... 운동을 할지 말지는 일단 체육관에 간 다음에 판단해라";
        StartCoroutine(Typing(sampleText));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}