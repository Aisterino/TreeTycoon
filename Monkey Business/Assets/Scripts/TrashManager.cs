using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;
    Queue<GameObject> trashQueue = new Queue<GameObject>();
    int maxTrash = 30;

    private void Awake()
    {
        Instance = this;
    }

    public void NewTrash(GameObject trash)
    {
        trashQueue.Enqueue(trash);

        if(trashQueue.Count > maxTrash)
        {
            GameObject firstTrash = trashQueue.Dequeue();
            Destroy(firstTrash);
        }
    }
}
