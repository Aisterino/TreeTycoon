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

        if (((1 << collisionObj.layer) & npcLayer.value) != 0)
        {
            if(collisionObj.GetComponent<Npc>() && collisionObj.GetComponent<Npc>().direction == direction)
            {
                Destroy(collisionObj);
            }   
        }

        if (collisionObj.GetComponent<MarketNpc>() && collisionObj.GetComponent<MarketNpc>().goingHome == true)
        {
            collisionObj.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
