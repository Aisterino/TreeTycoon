using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public static PlantScript Instance;
    public bool goodToPlant = true;

    GameObject treeSizeCheck;
    Transform seedTransform;

    private void Awake()
    {
        Instance = this;
        treeSizeCheck = transform.Find("TreeSizeCheck").gameObject;
        seedTransform = treeSizeCheck.transform.Find("Good");
    }

    public void CheckArea()
    {
        treeSizeCheck.SetActive(true);
    }

    public void PlantFunc()
    {
        treeSizeCheck.SetActive(false);
        Controls.Instance.areaChecked = false;
        if (goodToPlant)
        {

            Player.UpdateSeeds(-1);
            if(Player.seeds <= 0)
            {
                Controls.Instance.NoMoreSeeds();
            }

            GameObject newSeed = Instantiate(Storage.Instance.treeSeedObj, null);
            newSeed.transform.position = seedTransform.position;
            newSeed.SetActive(true);
        }
        else
        {
            //Some kind of a warning
        }
    }

    public void Cancle()
    {
        treeSizeCheck.SetActive(false);
        Controls.Instance.areaChecked = false;
    }
}
