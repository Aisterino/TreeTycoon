using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static Storage Instance;
    private GameObject trash;
    private GameObject npcs;

    public enum itemTypes
    {
        Trash,
        Npcs
    }

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetItemR(itemTypes itemType)
    {
        GameObject itemObj = transform.Find(itemType.ToString()).gameObject;

        return itemObj.transform.GetChild(Random.Range(0, itemObj.transform.childCount)).gameObject;
    }
}
