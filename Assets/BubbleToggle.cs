using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleToggle : MonoBehaviour
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
        bool isActive = !InfoBubble1.activeSelf;
        InfoBubble1.SetActive(isActive);

        Paper.transform.position = InfoBubble1.transform.position;
        //gameObject.SetActive(true);
        //InfoBubble1.SetActive(false);
        //this.transform.position = new Vector3(0, 0, 0); //not even a toggle anymore but I gave up to do it the complicated way
    }
}
