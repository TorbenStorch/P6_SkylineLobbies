using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    GameObject[] myObjects;

    public void DestroyAll()
    {
        myObjects = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject obj in myObjects)
        {
            Destroy(obj);
        }
    }
}
