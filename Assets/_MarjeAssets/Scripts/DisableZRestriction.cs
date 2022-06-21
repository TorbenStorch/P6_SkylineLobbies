using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisableZRestriction : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    Rigidbody rb;


   
    private void Awake()
    {
        toggleReference.action.started += Toggle;

        rb = GetComponent<Rigidbody>();
        //locks rb so it doesn't move on z
    }

    
    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        //bool isActive = !gameObject.activeSelf;
        //gameObject.SetActive(isActive);
        rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        
    }
}
