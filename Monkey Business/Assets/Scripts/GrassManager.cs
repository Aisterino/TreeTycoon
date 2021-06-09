using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
    Transform samplesStor;
    Transform zonesStor;
    Transform[] grassSamples;
    Transform[] zones;
    Collider2D[] zoneCol;

    float grassSpace = .13f;
    float grassYPos = -2.045f;

    private void Awake()
    {
        samplesStor = transform.Find("Samples");
        zonesStor = transform.Find("Zones");
        grassSamples = new Transform[samplesStor.childCount];
        for (int i = 0; i < samplesStor.childCount; i++)
        {
            grassSamples[i] = samplesStor.GetChild(i);
        }
        zones = new Transform[zonesStor.childCount];
        zoneCol = new Collider2D[zonesStor.childCount];
        for(int i = 0; i < zonesStor.childCount; i++)
        {
            zones[i] = zonesStor.GetChild(i);
            zoneCol[i] = zones[i].GetComponent<Collider2D>();
        }
    }

    private void Start()
    {
        for(int i = 0; i < zones.Length; i++)
        {
            Vector2 zoneVec = new Vector2(zones[i].transform.position.x - zoneCol[i].bounds.extents.x, zones[i].transform.position.x + zoneCol[i].bounds.extents.x);
            float colOffest = zoneCol[i].offset.x;
            int lastGType = -1;
            for (int j = 0; j < Mathf.FloorToInt(Mathf.Abs(zoneVec.x - zoneVec.y) / grassSpace); j++)
            {
                int grassType;
                do
                {
                    grassType = Random.Range(0, grassSamples.Length);
                } while (grassType == lastGType);
                lastGType = grassType;
                GameObject grass = Instantiate(grassSamples[grassType].gameObject, null);
                grass.transform.position = new Vector2(zoneVec.x + colOffest + grassSpace * j, grassYPos);
                Vector2 grassLScale = grass.transform.localScale;
                grassLScale.x = Random.Range(0, 2);
                if(grassLScale.x == 0)
                {
                    grassLScale.x = -1;
                }
                grass.transform.localScale = grassLScale;
                grass.SetActive(true);
            }
        }
    }
}
