using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager1 : MonoBehaviour
{
    System.Action _OnClickConformButton, _OnClickCancelButton;

    private static PopUpManager1 _instance;
    public static PopUpManager1 Instance
    {
        get
        {
            return _instance;
        }
    }


    public GameObject _popup;
    public TMP_Text _popMsg;

    public void Open()
    {
        _popup.SetActive(true);
    }

    public void Open(string text, System.Action OnClickConformButton, System.Action OnClickCancelButton)
    {
        _popup.SetActive(true);
        _popMsg.text = text;
        _OnClickConformButton = OnClickConformButton;
        _OnClickCancelButton = OnClickCancelButton;
    }

    public void Close()
    {
        _popup.SetActive(false);
    }


    private void Awake()
    {
        _popup.SetActive(false);
        DontDestroyOnLoad(this);
        _instance = this;
    }

    public void OnClickConformButton()
    {

        if (_OnClickConformButton != null)
        {
            Debug.Log("확인 버튼 누름");
            _OnClickConformButton();
        }
        Close();
    }


    public void OnClickCancelButton()
    {
        if (_OnClickCancelButton != null)
        {
            Debug.Log("취소 버튼 누름");
            _OnClickCancelButton();
        }
        Close();
    }

}
