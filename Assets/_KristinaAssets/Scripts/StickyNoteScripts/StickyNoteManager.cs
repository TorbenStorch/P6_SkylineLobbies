using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNoteManager : MonoBehaviour
{

    //this script is attatched to the StickyNoteManager game object with StickyNote_Grid script as well


    //referenced in Instantiate script. ; puts the instantiated sticky note prefab in the inspector when instantiated, then later referenced to transfer to the whiteborard
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
