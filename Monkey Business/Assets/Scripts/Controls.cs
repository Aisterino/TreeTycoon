using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Movement playerMovement;

    GameObject left;
    GameObject right;
    GameObject jump;

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
        inputMap.Default.Jump.performed += _ => JumpFunc();
    }
    #endregion

    private void Awake()
    {
        inputMap = new InputMap();
        playerMovement = player.GetComponent<Movement>();
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

    private void Move(bool isDown, float input)
    {
        if (isDown)
        {
            playerMovement.MoveInput(input);
        }
        else
        {
            if(playerMovement.movementInput == input)
            {
                playerMovement.MoveInput(0);
            }
            else
            {
                playerMovement.MoveInput(input);
            }
        }
    }
}
