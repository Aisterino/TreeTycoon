using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDestroyer : MonoBehaviour
{
    public LayerMask npcLayer;
    float direction = 1;

    private void Awake()
    {
        if(gameObject.name == "Left")
        {
            direction = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObj = collision.gameObject;

        if (((1 << collisionObj.layer) & npcLayer.value) != 0 && collisionObj.GetComponent<Npc>().direction == direction)
        {
            Destroy(collisionObj);
        }
    }
}
