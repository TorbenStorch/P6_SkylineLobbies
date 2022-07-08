using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleObjectExample : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    

    
    private void Awake()
    {
        toggleReference.action.started += Toggle;
    }

    
    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        //bool isActive = !gameObject.activeSelf;
        //gameObject.SetActive(isActive);
        this.transform.position = new Vector3(0, 0, 0); //not even a toggle anymore but I gave up to do it the complicated way
    }
}
