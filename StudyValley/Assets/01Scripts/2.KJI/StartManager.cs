using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class StartManager : MonoBehaviour
{
    public string SceneToLoad;
    public string GameExit;

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void OnButtonClickExit()
    {
        /*UnityEditor.EditorApplication.isPlaying = false;*/
        
        Application.Quit();
        Debug.Log("Exit");
    }

}

