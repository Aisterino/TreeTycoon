using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    GameObject moneyObj;
    GameObject trashObj;
    static TMP_Text moneyText;
    static TMP_Text trashText;

    private void Awake()
    {
        moneyObj = transform.Find("Money").gameObject;
        trashObj = transform.Find("Trash").gameObject;
        moneyText = moneyObj.GetComponent<TMP_Text>();
        trashText = trashObj.GetComponent<TMP_Text>();

        PlayerInfoUI.PlayerCheck();
    }

    public static void PlayerCheck()
    {
        moneyText.text = "" + Player.money;
        trashText.text = Player.trash + "/" + Player.maxTrash;
    }
}
