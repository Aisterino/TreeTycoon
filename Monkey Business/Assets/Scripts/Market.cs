using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public GameObject playerObj;
    private Transform canvas;
    private GameObject button;

    private int seedPrice = 1;


    private void Awake()
    {
        canvas = transform.Find("Sprite").Find("Canvas");
        button = canvas.Find("Button").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerObj)
        {
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerObj)
        {
            button.SetActive(false);
        }
    }

    public void BuySeeds()
    {
        if(Player.money >= seedPrice)
        {
            Player.GiveMoney(-seedPrice);
            Player.UpdateSeeds(1);
        }
    }

    public void SellFruits()
    {

    }
}
