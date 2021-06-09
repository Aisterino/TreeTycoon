using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoffeShop : MonoBehaviour
{
    bool isOpen = false;
    int coffePrice = 5;
    int energyFromCoffe = 10;
    int cdbs = 0; // Coffe dranked before sleep
    public static CoffeShop Instance;
    public GameObject playerObj;
    Transform canvas;
    GameObject button;
    TMP_Text priceText;

    private void Awake()
    {
        Instance = this;
        canvas = transform.Find("Canvas");
        button = canvas.Find("Button").gameObject;
        priceText = button.transform.Find("Price").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        CheckIfOpen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerObj)
        {
            button.SetActive(true);
            SetUpPrice();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerObj)
        {
            button.SetActive(false);
        }
    }

    bool CheckIfOpen()
    {
        if (TimeManager.Instance.time[1] > 8 && TimeManager.Instance.time[1] < 10)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }

        return isOpen;
    }

    public void BuyCoffe()
    {
        if(SetUpPrice())
        {
            Debug.Log("Bough some fucking coffe");
            Player.GiveMoney(-coffePrice);
            Player.ChangeEnergy(energyFromCoffe - cdbs);

            if (cdbs < energyFromCoffe)
            {
                cdbs++;
            }
        }

        SetUpPrice();
    }

    bool SetUpPrice()
    {
        bool enoughMoney = true;
        if(Player.money >= coffePrice)
        {
            priceText.color = Color.green;
        }
        else
        {
            priceText.color = Color.red;
            enoughMoney = false;
        }
        priceText.text = coffePrice + "$";

        return enoughMoney;
    }

    public void newDay()
    {
        cdbs = 0;
    }
}
