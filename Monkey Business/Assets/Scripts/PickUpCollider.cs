using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollider : MonoBehaviour
{
    Transform playerTrans;
    Movement movement;
    public LayerMask trashLayer;

    private void Awake()
    {
        playerTrans = transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObj = collision.gameObject;

        if(((1<<collisionObj.layer) & trashLayer.value) != 0)
        {
            Debug.Log("1");
            if(Player.PickUpTrash())
            {
                Debug.Log("2");
                Destroy(collisionObj);
            }
            else
            {
                Debug.Log("?");
                //Send warning
            }
        }
    }
}
