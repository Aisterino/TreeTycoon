using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : MonoBehaviour
{
    private InputMap inputMap = new InputMap();

    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
