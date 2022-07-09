using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoToggle : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    public GameObject Paper;
    public GameObject InfoBubble1;



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
        bool isActive = !Paper.activeSelf;
        Paper.SetActive(isActive);
        
        //InfoBubble1.transform.position = Paper.transform.position;
        //this.transform.position = new Vector3(0, 0, 0); //not even a toggle anymore but I gave up to do it the complicated way
    }
}
