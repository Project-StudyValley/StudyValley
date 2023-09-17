using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class NewButtonController : MonoBehaviour
{
    [System.Serializable]
    public class ButtonScenePair
    {
        public string ButtonName;
        public string sceneToLoad;
    }

    public ButtonScenePair[] buttonScenePairs;

    private void Start()
    {
        foreach (ButtonScenePair pair in buttonScenePairs)
        {
            GameObject button = GameObject.Find(pair.ButtonName);
            if (button != null)
            {
                button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
                {
                    LoadScene(pair.sceneToLoad);
                });
            }
            else
            {
                Debug.LogError("Button not found: " + pair.ButtonName);
            }
        }
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}