using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("d");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("d");
            other.transform.GetChild(0);
            GameObject canvas = other.transform.GetChild(0).gameObject;
            print(canvas.name);
            if (canvas == null)
            {
                return;
            }


            Transform transform = canvas.transform; // The Transform Attached to this GameObject
            GameObject panel = transform.Find("Panel").gameObject;

            if (panel == null)
            {
                return;
            }

            panel.SetActive(true);
        };
    }
}