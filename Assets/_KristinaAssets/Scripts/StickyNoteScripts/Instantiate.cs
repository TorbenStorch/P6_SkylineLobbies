using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    [SerializeField] private GameObject stickyNotePrefab;
    [SerializeField] private GameObject startingCanvas;



    public void CreateANote()
    {
        GameObject newNote = Instantiate(stickyNotePrefab) as GameObject;
        newNote.transform.SetParent(startingCanvas.transform, false);

        StickyNoteManager.Instance.selectedObject = newNote; //now its selected
    }


}
