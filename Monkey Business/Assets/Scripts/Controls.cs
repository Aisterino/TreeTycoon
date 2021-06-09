using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject moneyAddedCanvas;
    GameObject moneyAddedObj;
    Animator moneyAddedAnim;
    Movement playerMovement;

    GameObject left;
    GameObject right;
    GameObject jump;
    GameObject plantButObj;
    GameObject cancleButObj;
    TMP_Text plantText;

    #region PC Controls
    private InputMap inputMap;

    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }

    private void Start()
    {
        inputMap.Default.Left.performed += _ => LeftFunc(true);
        inputMap.Default.Left.canceled += _ => LeftFunc(false);
        inputMap.Default.Right.performed += _ => RightFunc(true);
        inputMap.Default.Right.canceled += _ => RightFunc(false);
        //inputMap.Default.Jump.performed += _ => JumpFunc();
    }
    #endregion

    public static Controls Instance;

private void Awake()
    {
        Instance = this;
        inputMap = new InputMap();
        playerMovement = player.GetComponent<Movement>();
        plantButObj = transform.Find("Plant").gameObject;
        plantText = plantButObj.transform.Find("Text").GetComponent<TMP_Text>();
        moneyAddedObj = moneyAddedCanvas.transform.Find("MoneyAdded").gameObject;
        moneyAddedAnim = moneyAddedCanvas.GetComponent<Animator>();
        cancleButObj = transform.Find("Cancle").gameObject;
    }

    public void LeftFunc(bool isDown)
    {
        Move(isDown, -1f);
    }

    public void RightFunc(bool isDown)
    {
        Move(isDown, 1f);
    }
    
    public void JumpFunc()
    {
        playerMovement.Jump(0, false);
    }
    
    public void PickUp()
    {
        playerMovement.PickUp();
    }

    private void Move(bool isDown, float input)
    {
        if (isDown)
        {
            if(moneyAddedObj.activeSelf)
            {
                moneyAddedAnim.SetTrigger("Stop");
            }
            
            playerMovement.MoveInput(input);
        }
        else
        {
            playerMovement.MoveInput(-input);
        }
    }

    public void Seeds(int amount)
    {
        plantButObj.SetActive(true);
        plantText.text = "" + amount;
    }

    public void NoMoreSeeds()
    {
        plantButObj.SetActive(false);
    }

    public bool areaChecked = false;

    public void TryToPlant()
    {
        if(!areaChecked)
        {
            playerMovement.LockMoving();
            playerMovement.enabled = false;
            PlantScript.Instance.CheckArea();
            TurnOnCancle(true);
        }
        else
        {
            playerMovement.enabled = true;
            PlantScript.Instance.PlantFunc();
            TurnOnCancle(false);
        }
    }

    public void TurnOnCancle(bool value)
    {
        cancleButObj.SetActive(value);
    }

    public void Cancle()
    {
        PlantScript.Instance.Cancle();
        playerMovement.enabled = true;
        TurnOnCancle(false);
    }
}
