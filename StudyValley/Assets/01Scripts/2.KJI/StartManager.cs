using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartManager : MonoBehaviour
{
    public string SceneToLoad;
    public string GameExit;

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void GmaeExit()
    {
        /*UnityEditor.EditorApplication.isPlaying = false;*/
        Application.Quit();
    }

}

