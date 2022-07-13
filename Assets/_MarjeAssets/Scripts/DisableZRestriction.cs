/*-------------------------------------------------------
Creator: Marje-Alicia Harms
Expanded Realities P6
last change: 13-07-2022
Topic: Scrapped script I didn't use in the end 
(used for toggling between being able to restrict the z axis of the bubble sprite object and being able to turn off the restriction to grab it and pull it out)
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisableZRestriction : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    Rigidbody rb;
    //bool toggleBool = false;

   
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
        Debug.Log("pos constraint on z executes");
        rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        //toggleBool = !toggleBool;

    }

    //private void Update() {
    //    if (toggleBool) {
    //        rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
    //        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    //    }
    //    }
}
