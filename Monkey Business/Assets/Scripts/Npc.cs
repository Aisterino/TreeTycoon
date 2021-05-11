using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public float direction = 1;
    [SerializeField] private float speed = 1.5f;
    Animator animator;
    float trashDropTime;
    float[] trashDropTimeRange = { 5, 100 };
    [SerializeField] private float litteringRate = 1f;


    private void Awake()
    {
        ResestTrDrTm();
        animator = transform.Find("Sprite").GetComponent<Animator>();
        animator.SetBool("Walking", true);

        if (direction < 0)
        {
            transform.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += direction * speed * Time.deltaTime;
        transform.position = currentPosition;
        trashDropTime -= Time.deltaTime * litteringRate;

        if(trashDropTime < 0)
        {
            dropTrash();
        }
    }

    private void dropTrash()
    {
        GameObject trashObj = Storage.Instance.GetItemR(Storage.itemTypes.Trash);
        trashObj = Instantiate(trashObj, null);
        trashObj.transform.position = transform.position;
        trashObj.SetActive(true);
        ResestTrDrTm();
    }

    private void ResestTrDrTm()//Resets trash drop timer
    {
        trashDropTime = Random.Range(trashDropTimeRange[0], trashDropTimeRange[1]);
        Debug.Log(trashDropTime);
    }
}
