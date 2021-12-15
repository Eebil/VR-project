using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class TurnProviderToggle : MonoBehaviour
{
    private bool turnToggle = true;
    private LocomotionProvider snapProvider;
    private LocomotionProvider continuousProvider;

    // Start is called before the first frame update
    void Start()
    {
        snapProvider = GetComponent<ActionBasedSnapTurnProvider>();
        continuousProvider = GetComponent<ActionBasedContinuousTurnProvider>();
        SwitchTurnProvider();

    }
    public void SwitchTurnProvider()
    {
        turnToggle = !turnToggle;

        if (turnToggle)
        {
            continuousProvider.enabled = false;
            snapProvider.enabled = true;
        }
        else
        {
            continuousProvider.enabled = true;
            snapProvider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
