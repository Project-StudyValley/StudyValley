using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{


    public bool isAction;


    // Update is called once per frame
    public void Action(GameObject scanObj)
    {

        if (isAction)
        {
            isAction = false;
        }


    }
}