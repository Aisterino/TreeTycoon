using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    float plantTime;
    float defaultGrowTime;
    float growtime;
    int treeGrowthIdex = 0;
    int numOfTreeFazes = 4;
    SpriteRenderer SpriteRend;
    bool grownup = false;
    public static float GlobalFruitRate = 1;
    float fruitRate;
    float defaultFruitTime;
    float fruitTime;


    enum treeTypes
    {
        apple,
        lemon,
        cherry,
        orange,
        length
    }

    treeTypes treeType;

    private void Awake()
    {
        SpriteRend = GetComponent<SpriteRenderer>();

        treeType = (treeTypes)Random.Range(0, (int)treeTypes.length);

        switch (treeType)
        {
            case (treeTypes.apple):
                newTree(1200, 5, 300);
                break;
            case (treeTypes.cherry):
                newTree(1500 , 8, 300);
                break;
            case (treeTypes.lemon):
                newTree(2400, 5, 600);
                break;
            case (treeTypes.orange):
                newTree(1800, 5, 400);
                break;
            default:
                Debug.Log("Smth wrong with treeTypes enum in tree script");
                break;
        }

        growtime = defaultGrowTime;

        plantTime = TimeManager.Instance.timeInS;
    }

    private void Update()
    {
        if(grownup && TimeManager.Instance.timeInS >= plantTime + defaultGrowTime)
        {
            SpriteRend.sprite = Storage.Instance.treesTrans.GetChild(treeGrowthIdex).GetComponent<SpriteRenderer>().sprite;
            treeGrowthIdex++;

            if(treeGrowthIdex > numOfTreeFazes)
            {
                grownup = true;
                fruitTime = TimeManager.Instance.timeInS + defaultFruitTime;
            }
            else
            {
                growtime += defaultGrowTime;
            }
        }

        if(grownup && fruitTime <= TimeManager.Instance.timeInS)
        {
            GrowFruit();
        }
    }

    void newTree(float defaultGrowTime, float fruitRate, float defaultFruitTime)
    {
        this.defaultGrowTime = defaultGrowTime;
        this.fruitRate = fruitRate;
        this.defaultFruitTime = defaultFruitTime;
    }

    void GrowFruit()
    {
        //spawn fruit
        fruitTime = TimeManager.Instance.timeInS + defaultFruitTime;
    }
}
