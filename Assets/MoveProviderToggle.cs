using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class MoveProviderToggle : MonoBehaviour
{

    private LocomotionProvider continuousMoveProvider;

    // Start is called before the first frame update
    void Start()
    {
        continuousMoveProvider = GetComponent<ActionBasedContinuousMoveProvider>();

    }
    public void SwitchMoveProvider(bool toggle)
    {
        continuousMoveProvider.enabled = !toggle;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
