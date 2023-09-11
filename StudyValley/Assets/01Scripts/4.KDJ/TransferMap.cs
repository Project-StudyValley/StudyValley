using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;


public class TransferMap : MonoBehaviour
{
    public string TransferMapName;
/*    public Transform SpawnPoint;
    public StartPoint otherSP;*/

    private PlayerController thePlayer;
    private CameraManager theCamera;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            /*thePlayer.currentMapName = TransferMapName;*/
            SceneManager.LoadScene(TransferMapName);
        }
    }


}
