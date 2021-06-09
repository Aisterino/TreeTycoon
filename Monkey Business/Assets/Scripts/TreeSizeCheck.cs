using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSizeCheck : MonoBehaviour
{
    public static TreeSizeCheck Instance;
    public LayerMask ObstaclesLayer;
    bool goodArea;
    GameObject goodSeed;
    GameObject badSeed;

    private void Awake()
    {
        Instance = this;
        goodSeed = transform.Find("Good").gameObject;
        badSeed = transform.Find("Bad").gameObject;
    }

    private void OnEnable()
    {
        ChangeSeed(true);
        PlantScript.Instance.goodToPlant = true;
        timer = 0;
    }

    private float timer;
    private float timerForCheck = 0.1f;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= timerForCheck)
        {
            Controls.Instance.areaChecked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObj = collision.gameObject;

        if (((1 << collisionObj.layer) & ObstaclesLayer.value) != 0)
        {
            ChangeSeed(false);
            PlantScript.Instance.goodToPlant = false;
        }
    }

    void ChangeSeed(bool good)
    {
        if(good)
        {
            goodArea = true;
            goodSeed.SetActive(true);
            badSeed.SetActive(false);
        }
        else
        {
            goodArea = false;
            badSeed.SetActive(true);
            goodSeed.SetActive(false);
        }
    }
}
