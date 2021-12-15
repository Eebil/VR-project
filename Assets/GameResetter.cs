using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
public class GameResetter : MonoBehaviour
{

    public XROrigin rig;
    public XRNode leftHand;
    public XRNode rightHand;

    private InputDevice leftDevice;
    private InputDevice rightDevice;
                

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftDevice = InputDevices.GetDeviceAtXRNode(leftHand);
        rightDevice = InputDevices.GetDeviceAtXRNode(rightHand); // these are here in case contollers are not connected when application starts
        leftDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool lPressed);
        rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool rPressed);
        if (lPressed && rPressed)
            rig.MoveCameraToWorldLocation(new Vector3(0, 2, 0));  // if both primaries pressed reset to origin
    }
}
