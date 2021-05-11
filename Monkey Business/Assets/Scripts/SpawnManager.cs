using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Transform[] spawners = new Transform[2];
    float spawnRate = 1;
    float spawnTime = 0f;
    float[] sTRange = { 5, 30 };//Spawn time range

    private void Awake()
    {
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
            spawnTime = Random.Range(sTRange[0], sTRange[1] / spawnRate);
        }
    }
}
