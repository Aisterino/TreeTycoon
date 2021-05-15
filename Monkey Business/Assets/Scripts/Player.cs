using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static int money = 0;
    public static int maxTrash = 5;
    public static int trash = 2;
    public static int maxEnergy = 100;
    public static int energy = 100;
    public static int seeds = 0;

    public static void GiveMoney(int value)
    {
        money += value;
        PlayerCanvas.Instance.MoneyAdded(value);
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

    public static void UpdateSeeds(int amount)
    {
        seeds += amount;
        Controls.Instance.Seeds(seeds);
    }

    public static void LoseEnergy(int amount)
    {
        
    }
}
