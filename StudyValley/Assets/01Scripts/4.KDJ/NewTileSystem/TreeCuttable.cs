using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField]
    GameObject pickUpDrop;
    [SerializeField]
    int dropCount = 5;
    [SerializeField]
    float spread = 0.7f;
    public Vector2 position;

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject itemGO = Instantiate(pickUpDrop);
            itemGO.transform.position = position;
        }

        Destroy(gameObject);
    }
}
