using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentChild : MonoBehaviour
{
    GameObject myObject;
    GameObject interactable;

    private bool hasParented = false;

    void Awake()
    {
        interactable = GameObject.FindGameObjectWithTag("Interactable");   
    }

    void Update()
    {
        if(interactable = null)
        {
            return;
        }
        if(!hasParented)
        {
            SetParent(interactable);
            hasParented = true;
            Debug.Log("Parent set");
        }
        else if(hasParented)
        {
            Debug.Log("Looking for a childeren");
        }
    }

    public void SetParent(GameObject newParent)
    {
        if(myObject == null)
        {
            return;
        }
        
        myObject.transform.parent = newParent.transform;
        //hasParented = true;

        //Display the parent's name in the console.
        //Debug.Log("Player's Parent: " + myObject.transform.parent.name);

        // Check if the new parent has a parent GameObject.
        //if (newParent.transform.parent != null)
        //{
        //    //Display the name of the grand parent of the player.
        //    Debug.Log("Player's Grand parent: " + myObject.transform.parent.parent.name);
        //}
    }
}
