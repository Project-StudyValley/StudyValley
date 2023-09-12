using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    public string _popupMsg;

    public void OnClickTrigger()
    {
        PopUpManager.Instance.Open
            (_popupMsg, OnClickConformButton: () =>
           {
               Debug.Log("On Trigger Conform Button");

           }, OnClickCancelButton: () =>

           {
               Debug.Log("On Click Cancel Button");
           }
           );
    }
}
