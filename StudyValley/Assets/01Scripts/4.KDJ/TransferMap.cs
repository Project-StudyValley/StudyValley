using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;


public class TransferMap : MonoBehaviour
{
    public string TransferMapName;
    public Transform SpawnPoint;
    public Transform SpawnPoint2;

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
/*            onOffCamera.SetActive(false);*/
            /*            thePlayer.currentMapName = TransferMapName;*/

            theCamera.transform.position = new Vector3(SpawnPoint2.transform.position.x, SpawnPoint2.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = SpawnPoint.transform.position;

            SceneManager.LoadScene(TransferMapName);
        }
    }

/*    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            onOffCamera.SetActive(true);
        }
    }*/
}
