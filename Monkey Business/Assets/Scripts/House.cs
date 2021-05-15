using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject sleepEfUI;
    public AnimationClip sleepAnimClip1;
    public AnimationClip sleepAnimClip2;
    Transform canvasTrans;
    GameObject sleepButObj;
    Animator sleepAnimator;

    private void Awake()
    {
        canvasTrans = transform.Find("Canvas");
        sleepButObj = canvasTrans.Find("Sleep").gameObject;
        sleepAnimator = sleepEfUI.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObj = collision.gameObject;

        if(collisionObj == playerObj)
        {
            sleepButObj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collisionObj = collision.gameObject;

        if (collisionObj == playerObj)
        {
            sleepButObj.SetActive(false);
        }
    }

    public void Sleep()
    {
        Debug.Log("Sleep started");
        StartCoroutine(SleepIEnum());
    }

    IEnumerator SleepIEnum()
    {
        Debug.Log("Sleep IEnum started");
        playerObj.SetActive(false);
        sleepEfUI.SetActive(true);
        sleepButObj.SetActive(false);
        sleepAnimator.SetTrigger("Sleep");
        yield return new WaitForSeconds(sleepAnimClip1.length);
        TimeManager.Instance.SleepTimer();
        yield return new WaitForSeconds(sleepAnimClip2.length);
        playerObj.SetActive(true);
    }
}
