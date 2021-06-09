using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public Transform[] spawners = new Transform[2];
    float defaultSpawnRate = 1;//SpawnRate that isn't effected by the time of a day
    float spawnRate = 1;//SpawnRate that is effected by time of a day and climate
    float spawnTime = 0f;
    float[] sTRange = { 5, 30 };//Spawn time range

    private void Awake()
    {
        Instance = this;

        spawners[0] = transform.Find("Left");
        spawners[1] = transform.Find("Right");
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
            GameObject npcObj = Instantiate(Storage.Instance.GetItemR(Storage.itemTypes.Npcs), null);
            int side = Mathf.RoundToInt(Random.Range(0, 2));
            npcObj.transform.position = spawners[side].position;
            float direction;

            if(side == 0)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            npcObj.GetComponent<Npc>().direction = direction;
            npcObj.SetActive(true);
            spawnTime = Random.Range(sTRange[0], sTRange[1] * spawnRate);
        }
    }

    public void CheckTime(TimeManager.TimesOfADay timeOfADay)
    {
        switch(timeOfADay)
        {
            case (TimeManager.TimesOfADay.morrning):
                spawnRate = defaultSpawnRate * .1f;
                break;
            case (TimeManager.TimesOfADay.day):
                spawnRate = defaultSpawnRate;
                break;
            case (TimeManager.TimesOfADay.evening):
                spawnRate = defaultSpawnRate * .1f;
                break;
            case (TimeManager.TimesOfADay.night):
                spawnRate = defaultSpawnRate * .005f;
                break;
        }
    }
}
