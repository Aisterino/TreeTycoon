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
    private InputMap inputMap = new InputMap();

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
        //inputMap.Default.Left += _ => LeftFunc();
    }
    #endregion

    private void Awake()
    {
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
            playerMovement.MoveInput(-input);
        }
    }
}
