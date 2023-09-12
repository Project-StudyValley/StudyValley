using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SoundManager : MonoBehaviour
{
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,  // Sound enum의 개수 세기 위해 추가.
    }

    private void Start()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }




}
