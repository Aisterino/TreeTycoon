using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    public GameObject playerObj;
    private GameObject sellButton;

    private void Awake()
    {
        sellButton = transform.Find("Canvas").Find("SellButton").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter");
        if (collision.gameObject == playerObj && Player.trash != 0)
        {
            sellButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exit");
        if (collision.gameObject == playerObj)
        {
            sellButton.SetActive(false);
        }
    }

    public void Sell()
    {
        if(Player.trash != 0)
        {
            Player.GiveMoney(Player.trash);
            Player.trash = 0;
            PlayerInfoUI.PlayerCheck();
        }
    }
}
