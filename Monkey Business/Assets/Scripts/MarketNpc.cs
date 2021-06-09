using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketNpc : MonoBehaviour
{
    float goal;
    float direction;
    bool custumMovementOn = false;
    [SerializeField] int npcType;
    Transform marketTrans;
    float spriteOffsetInMarket = -0.024f;
    public bool goingHome = false;
    SpriteRenderer spriteRend;
    float speed = 1.5f;
    bool firstMorrning = true;
    Animator animator;

    private int overTimeRange = 15; //Seconds
    bool goingForSmoke = false;
    float smokeRate = 20;
    float smokePlaceX = 3;
    float smokeTime = 3f;

    private void Awake()
    {
        marketTrans = transform.parent.parent;
        spriteRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        InvokeRepeating("Smoke", smokeRate, 10);
    }

    private void Update()
    {
        if (custumMovementOn)
        {
            float npcX = transform.position.x;

            Vector3 currentPosition = transform.position;
            currentPosition.x += direction * speed * Time.deltaTime;
            transform.position = currentPosition;

            animator.SetBool("Walking", true);

            if(direction == 1)
            {
                transform.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                if (goal <= npcX)
                {
                    GoalReached();
                }
            }
            else if (direction == -1)
            {
                transform.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                if (goal >= npcX)
                {
                    GoalReached();
                }
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void GoalReached()
    {
        Debug.Log("Goal reached");

        if(direction == -1)
        {
            Vector2 npcPos = transform.position;
            npcPos.x = spriteOffsetInMarket + marketTrans.position.x;
            transform.position = npcPos;
        }

        direction = 0;
        custumMovementOn = false;

        if(goingForSmoke)
        {
            animator.SetBool("Smoke", true);
            float time = 0;
            while(time < smokeTime)
            {
                time += Time.deltaTime;
            }
            animator.SetBool("Smoke", false);
        }
    }

    public void moveToAPoint(float goal, bool smoke)
    {
        if(smoke)
        {
            goingForSmoke = true;
        }

        float npcX = transform.position.x;
        this.goal = goal;
        
        if (npcX < goal)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        custumMovementOn = true;
    }
    void Smoke()
    {
        moveToAPoint(smokePlaceX, true);
    }

    public void GlobalMorrning()
    {
        StartCoroutine(ComeToWork(true));
        Debug.Log("Morrning");
    }

    public void GlobalEvening()
    {
        StartCoroutine(ComeToWork(false));
        Debug.Log("Evening");
    }

    IEnumerator ComeToWork(bool value)
    {
        yield return new WaitForSeconds(Random.Range(0, overTimeRange + 1));

        if (value)
        {
            spriteRend.enabled = true;
            moveToAPoint(spriteOffsetInMarket + marketTrans.position.x, false);
        }
        else
        {
            goingHome = true;
            moveToAPoint(SpawnManager.Instance.spawners[1].position.x, false);
        }
    }
}
