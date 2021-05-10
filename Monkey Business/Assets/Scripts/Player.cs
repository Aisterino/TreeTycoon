using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static int money = 0;
    public static int maxTrash = 5;
    public static int trash = 2;

    public static void GiveMoney(int value)
    {
        PlayerCanvas.Instance.MoneyAdded(value);
        money += value;
    }

    public static bool PickUpTrash()
    {
        if (trash + 1 <= maxTrash)
        {
            trash++;
            PlayerInfoUI.PlayerCheck();
            return true;
        }
        else
        {
            return false;
        }
    }
}
