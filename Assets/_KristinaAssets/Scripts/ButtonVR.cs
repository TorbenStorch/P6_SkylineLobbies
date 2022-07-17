/*-------------------------------------------------------
Creator: Kristina Koseva
Expanded Realities P6
last change: 17-07-2022
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    GameObject presser;
    AudioSource sound;
    bool isPressed;

    private Vector3 buttonRange = new Vector3(0, 0.5f, 0);
    private Vector3 buttonStartPos;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;

        buttonStartPos = button.transform.localPosition;


    }


    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = buttonStartPos - buttonRange;
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            //Debug.Log(other);
        }


    }



    private void OnTriggerExit(Collider other)
    {
        button.transform.localPosition = buttonStartPos;

        if (other == presser)
        {            
            onRelease.Invoke();    
            isPressed = false;

        }

        Debug.Log(other); //its the hand model (cube/sphere in my case)
    }


   

    public void ExitApp()
    {
        Application.Quit();
    }

}
