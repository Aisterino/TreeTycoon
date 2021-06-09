using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static float speedByEnerg = 1;
    public static int money = 100;
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

    public static void ChangeEnergy(int amount)
    {
        energy += amount;
        if(energy > 10)
        {
            speedByEnerg = 1;
        }
        if (energy <= 10)
        {
            speedByEnerg = .6f;
        }
        if(energy <= 5)
        {
            speedByEnerg = .3f;
        }
        if(energy <= 0)
        {
            House.Instance.Sleep(60);
        }
    }
}
