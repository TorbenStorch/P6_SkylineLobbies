/*-------------------------------------------------------
Creator: Marje-Alicia Harms
Expanded Realities P6
last change: 13-07-2022
Topic: Toggling the InfoBubble Sprite between set active true and false; also setting the position of the paper to it's position;
also spawning the Sprites of Paper and Bubble very far away so they don't look bad in the beginning
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;


public class BubbleToggle : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    public GameObject Paper1;
    public GameObject Paper2;
    public GameObject Paper3;

    public GameObject InfoBubble1;
    public GameObject InfoBubble2;
    public GameObject InfoBubble3;

    //precautions for not looking bad
    private float very = 1000f;
    private float far = 1000f;
    private float away = 1000f;

    [SerializeField] PhotonView photonView;

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        //spawn far away so if user already presses secondary button or K it doesn't look bad
        Paper1.transform.position = new Vector3(very, far, away);
        Paper2.transform.position = new Vector3(very, far, away);
        Paper3.transform.position = new Vector3(very, far, away);

        InfoBubble1.transform.position = new Vector3(very, far, away);
        InfoBubble2.transform.position = new Vector3(very, far, away);
        InfoBubble3.transform.position = new Vector3(very, far, away);


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
        bool isActive = !InfoBubble1.activeSelf;
        InfoBubble1.SetActive(isActive);
        Debug.Log("BubbleToggle");

        Paper1.transform.position = InfoBubble1.transform.position;
        //gameObject.SetActive(true);
        //InfoBubble1.SetActive(false);
        //this.transform.position = new Vector3(0, 0, 0); //not even a toggle anymore but I gave up to do it the complicated way
    }

    private void Toggle2(InputAction.CallbackContext context)
    {
        bool isActive = !InfoBubble2.activeSelf;
        InfoBubble2.SetActive(isActive);
        Debug.Log("BubbleToggle");

        Paper2.transform.position = InfoBubble2.transform.position;
          
    }

    private void Toggle3(InputAction.CallbackContext context)
    {
        bool isActive = !InfoBubble3.activeSelf;
        InfoBubble3.SetActive(isActive);
        Debug.Log("BubbleToggle");

        Paper3.transform.position = InfoBubble3.transform.position;

    }
}
