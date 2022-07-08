/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 28-06-2022
Topic: Script for combining the gameobjects - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class CombiningManagerVR : MonoBehaviour
{
    public PhotonView photonView;

    //GameObject interactable;
    //GameObject myObject;

    private bool hasCollided;
    private bool hasParented;

    void Awake()
    {
        //interactable = GameObject.FindGameObjectWithTag("Interactable");
    }

    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Interactable"))
        {
            //if(!hasParented)
            //{
            //    SetParent(interactable);
            //    Debug.Log("Parent set");
            //    hasParented = true;
            //}
            //else if(hasParented)
            //{
            //    SetChild();
            //    Debug.Log("Child set");
            //}
        }
    }


    //public void SetParent(GameObject newParent)
    //{
    //    myObject.transform.parent = newParent.transform;

    //    //Display the parent's name in the console.
    //    Debug.Log("Player's Parent: " + myObject.transform.parent.name);

    //    // Check if the new parent has a parent GameObject.
    //    if (newParent.transform.parent != null)
    //    {
    //        //Display the name of the grand parent of the player.
    //        Debug.Log("Player's Grand parent: " + myObject.transform.parent.parent.name);
    //    }
    //}

    //public void SetChild()
    //{

    //}
}