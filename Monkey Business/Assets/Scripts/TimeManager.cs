using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float[] time = new float[3];// 0 - Days   1 - Hours   2 - Minutes
    public float timeInS;
    float timeSpeed = 1f;
    GameObject timeUiObj;
    TMP_Text timeText;
    GameObject daysUiObj;
    TMP_Text daysText;
    public float sleepTime = 8;//Hours
    public static TimeManager Instance;
    int energyLoseInHour = 6;
    public MarketNpc[] marketNpcs;

    public enum TimesOfADay
    {
        morrning,
        day,
        evening,
        night
    }

    public TimesOfADay timeOfADay;
    TimesOfADay lastTimeOfADay;

    private void Awake()
    {
        Instance = this;
        timeUiObj = transform.Find("TimeUI").gameObject;
        timeText = timeUiObj.GetComponent<TMP_Text>();
        daysUiObj = transform.Find("DaysUI").gameObject;
        daysText = daysUiObj.GetComponent<TMP_Text>();
        time[2] = 45;
        time[1] = 19;
    }

    private void Start()
    {
        CheckDayTime();
    }

    private void FixedUpdate()
    {
        float timePassed = Time.deltaTime * timeSpeed;
        time[2] += timePassed;
        timeInS += timePassed;

        if (time[2] > 59)
        {
            Player.ChangeEnergy(-energyLoseInHour);
            time[1] ++;
            time[2] -= 60;
            CheckDayTime();
        }

        if(time[1] > 23)
        {
            time[0] ++;
            time[1] -= 24;
        }

        daysText.text = "Day: " + time[0];

        string aditionalNum1 = "";
        string aditionalNum2 = "";

        if (time[1] < 9)
        {
            aditionalNum1 = "0";
        }

        if (time[2] < 9)
        {
            aditionalNum2 = "0";
        }

        timeText.text = aditionalNum1 + Mathf.CeilToInt(time[1]) + ":" + aditionalNum2 + Mathf.CeilToInt(time[2]);
    }

    public void CheckDayTime()
    {
        if (time[1] >= 8 && time[1] <= 10)
        {
            timeOfADay = TimesOfADay.morrning;

            if(lastTimeOfADay != TimesOfADay.morrning)
            {
                for (int i = 0; i < marketNpcs.Length; i++)
                {
                    marketNpcs[i].GlobalMorrning();
                }
            }
        }
        else if (time[1] >= 11 && time[1] <= 19)
        {
            timeOfADay = TimesOfADay.day;
        }
        else if (time[1] >= 20 && time[1] <= 22)
        {
            timeOfADay = TimesOfADay.evening;

            if (lastTimeOfADay != TimesOfADay.evening)
            {
                for (int i = 0; i < marketNpcs.Length; i++)
                {
                    marketNpcs[i].GlobalEvening();
                }
            }    
        }
        else
        {
            timeOfADay = TimesOfADay.night;
        }

        lastTimeOfADay = timeOfADay;

        SpawnManager.Instance.CheckTime(timeOfADay);
    }
}
