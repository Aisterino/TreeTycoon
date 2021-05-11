using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    float[] time = new float[3];// 0 - Days   1 - Hours   2 - Minutes
    float timeSpeed = 1f;
    GameObject timeUiObj;
    TMP_Text timeText;
    GameObject daysUiObj;
    TMP_Text daysText;

    private void Awake()
    {
        timeUiObj = transform.Find("TimeUI").gameObject;
        timeText = timeUiObj.GetComponent<TMP_Text>();
        daysUiObj = transform.Find("DaysUI").gameObject;
        daysText = daysUiObj.GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        time[2] += Time.deltaTime * timeSpeed;
        if(time[2] > 60)
        {
            time[1] ++;
            time[2] -= 60;
        }
        if(time[1] > 24)
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
}
