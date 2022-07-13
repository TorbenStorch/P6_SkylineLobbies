/*-------------------------------------------------------
Creator: Marje-Alicia Harms
Expanded Realities P6
last change: 13-07-2022
Topic: Toggling the Paper Sprite between set active true and false
(didn't do it in one script with the infobubble because they need to turn off and on asynchronous and this was the first way that came to mind)
(-> basically not pretty but fast solution)
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using Photon.Pun;

public class InfoToggle : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    public GameObject Paper1;
    public GameObject Paper2;
    public GameObject Paper3;
    //public GameObject InfoBubble1;


    //[SerializeField] PhotonView photonView;

    private void Awake()
    {
        //if (!photonView.IsMine)
        //{
        //    return;
        //}
        toggleReference.action.started += Toggle1;
        toggleReference.action.started += Toggle2;
        toggleReference.action.started += Toggle3;

    }


    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle1;
        toggleReference.action.started -= Toggle2;
        toggleReference.action.started -= Toggle3;
    }

    private void Toggle1(InputAction.CallbackContext context)
    {
        bool isActive = !Paper1.activeSelf;
        Paper1.SetActive(isActive);
        Debug.Log("TogglePaper");

        //InfoBubble1.transform.position = Paper.transform.position;
        //this.transform.position = new Vector3(0, 0, 0); //not even a toggle anymore but I gave up to do it the complicated way
    }

    private void Toggle2(InputAction.CallbackContext context)
    {
        bool isActive = !Paper2.activeSelf;
        Paper2.SetActive(isActive);
        Debug.Log("TogglePaper");

        //InfoBubble1.transform.position = Paper.transform.position;
        //this.transform.position = new Vector3(0, 0, 0); //not even a toggle anymore but I gave up to do it the complicated way
    }

    private void Toggle3(InputAction.CallbackContext context)
    {
        bool isActive = !Paper3.activeSelf;
        Paper3.SetActive(isActive);
        Debug.Log("TogglePaper");

        //InfoBubble1.transform.position = Paper.transform.position;
        //this.transform.position = new Vector3(0, 0, 0); //not even a toggle anymore but I gave up to do it the complicated way
    }
}
