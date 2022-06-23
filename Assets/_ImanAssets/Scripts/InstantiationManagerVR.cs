// P6
// Iman Nikkhahazad

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationManagerVR : MonoBehaviour
{
    [SerializeField]
    GameObject mySphere;

    private bool hasSpawned;

    public void InstantiatorManager()
    {
        if(hasSpawned)
        {
            return;
        }

        Instantiate(mySphere, mySphere.transform.position, mySphere.transform.rotation);
        hasSpawned = true;
        Debug.Log("Object created !");
    }

    //public void Message()
    //{
    //    Debug.Log("Trigger pressed");
    //}

    //public void SetChilderen()
    //{
    //    gameObject.transform.SetParent(mySphere.transform, false);
    //}
}
