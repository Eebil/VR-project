using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionInitializer : MonoBehaviour
{

    private CharacterController character;
    private CapsuleCollider capsule;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        capsule = GetComponent<CapsuleCollider>();
        rigidBody = GetComponent<Rigidbody>();
        SwitchLocomotionBase(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Set components to appropriate values when switching from physics based locomotion system to non-physics based and vice versa.
    */
    public void SwitchLocomotionBase(bool toggle)
    {
        if (!toggle)
        {
            character.enabled = true;
            capsule.enabled = false;
            rigidBody.isKinematic = true; // ignore physics when not using physics based locomotion
        }
        else 
        {
            character.enabled = false;
            capsule.enabled = true;
            rigidBody.isKinematic = false;
        }
        
    }
}
