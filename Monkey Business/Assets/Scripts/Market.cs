using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public GameObject playerObj;
    public int marketType;
    public static int amountOfMarkets = 3;
    public static Market[] markets = new Market[amountOfMarkets];
    Transform sprite;
    private Transform canvas;
    private GameObject button;
    GameObject sprite2;
    GameObject sprite3;
    private int seedPrice = 10;

    private void Awake()
    {
        sprite = transform.Find("Sprite");
        canvas = sprite.Find("Canvas");
        button = canvas.Find("Button").gameObject;
        markets[marketType] = this;
        sprite2 = sprite.Find("Sprite2").gameObject;
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

    public static void SellFruits()
    {

    }
}
