using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController3 : MonoBehaviour
{
    public TMP_Text dialogText;

    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = "";
        string sampleText = "오운완 맛있네ㅋ";
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