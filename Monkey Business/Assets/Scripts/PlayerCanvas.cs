using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCanvas : MonoBehaviour
{
    GameObject canvas;
    Transform playerTransform;
    Animator canvasAnimator;
    GameObject moneyAddedUI;
    TMP_Text moneyText;

    public static PlayerCanvas Instance;

    private void Awake()
    {
        Instance = this;

        canvas = transform.Find("Canvas").gameObject;
        playerTransform = canvas.transform.parent;
        canvasAnimator = canvas.GetComponent<Animator>();
        moneyAddedUI = canvas.transform.Find("MoneyAdded").gameObject;
        moneyText = moneyAddedUI.GetComponent<TMP_Text>();
    }

    public void MoneyAdded(float amount)
    {
        float playerScaleX = playerTransform.localScale.x;
        Vector2 newScale = canvas.transform.localScale;
        newScale.x = playerScaleX;
        canvas.transform.localScale = newScale; 

        if(amount < 0)
        {
            moneyText.text = amount + " $";
        }
        else
        {
            moneyText.text = "+" + amount + " $";
        }
        
        canvasAnimator.SetTrigger("Add");
        PlayerInfoUI.PlayerCheck();
    }
}
