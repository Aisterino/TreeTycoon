using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public static House Instance;
    public GameObject playerObj;
    public GameObject sleepEfUI;
    public AnimationClip sleepAnimClip1;
    public AnimationClip sleepAnimClip2;
    Transform canvasTrans;
    GameObject sleepButObj;
    Animator sleepAnimator;
    int sleepSpeed = 100;

    private void Awake()
    {
        Instance = this;
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

    public void Sleep(int energy)
    {
        StartCoroutine(SleepIEnum(energy));
    }

    IEnumerator SleepIEnum(int energy)
    {
        playerObj.SetActive(false);
        sleepEfUI.SetActive(true);
        sleepButObj.SetActive(false);
        sleepAnimator.SetTrigger("Sleep");

        yield return new WaitForSeconds(sleepAnimClip1.length);

        float startTime = TimeManager.Instance.timeInS;
        Time.timeScale = sleepSpeed;
        Debug.Log("Sleep time = " + TimeManager.Instance.sleepTime);
        yield return new WaitUntil(() => TimeManager.Instance.timeInS > startTime + TimeManager.Instance.sleepTime * 60);

        Time.timeScale = 1;

        if(energy < 0)
        {
            Player.energy = Player.maxEnergy;
        }
        else
        {
            Player.energy = energy;
        }

        sleepAnimator.SetTrigger("WakeUp");
        yield return new WaitForSeconds(sleepAnimClip2.length);
        playerObj.SetActive(true);
    }
}
