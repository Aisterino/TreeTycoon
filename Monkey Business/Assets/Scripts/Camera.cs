using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerTransform;
    private float distance = 10f;

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, 0, -distance);
    }
}
