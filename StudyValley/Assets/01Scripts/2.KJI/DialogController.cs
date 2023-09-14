using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public TMP_Text dialogText;

    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = "";
        string sampleText = "난 펠리컨 마을의 시장을 20년 동안 해왔네! 선거철이 되면 아무도 지원을 안 해. 내가 일을 잘 하고 있다는 뜻으로 생각하고 싶네. 난 시장인 게 썩 마음에 들거든. 그래서 무엇이 필요한가?";
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