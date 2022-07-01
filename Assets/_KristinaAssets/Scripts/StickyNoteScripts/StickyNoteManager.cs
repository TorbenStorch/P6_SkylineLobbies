using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNoteManager : MonoBehaviour
{
    //referenced in Instantiate script
    public GameObject selectedObject;



    //---------Singleton--------
    public static StickyNoteManager Instance { get; private set; }

    private void Awake()
    {

        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }


    }

    



    

    


}
