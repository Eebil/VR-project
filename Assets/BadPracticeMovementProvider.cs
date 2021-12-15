using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class BadPracticeMovementProvider : MonoBehaviour
{
    public XRNode inputSource;
    public XROrigin rig;
    public float maxSpeed { get; set; }  // made these properties to be able to modify them from the UI editor
    public float accelaration { get; set; }


    private Vector2 inputAxis;
    private CharacterController character;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        // character = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
        this.maxSpeed = 5f;
        this.accelaration = 0.5f; 
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {

        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y); // Set thubstick input relative to HMD yaw.

        if (Mathf.Abs(rigidBody.velocity.x) < maxSpeed && Mathf.Abs(rigidBody.velocity.z) < maxSpeed) // Check if we are within the speed limit for xz-plane and accelerate if we are 
            rigidBody.velocity += direction * accelaration;

        /*
        character.Move(direction * Time.fixedDeltaTime);


        // implementing gravity
        if (IsGrounded())
            fallingSpeed = 0;
        else
        fallingSpeed += gravity * Time.fixedDeltaTime;
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
        */
    }

}
