using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Instantiate : MonoBehaviour
{

    [SerializeField] private GameObject stickyNotePrefab;
    [SerializeField] private GameObject startingCanvas;

    public void CreateANote()
    {
        //GameObject newNote = Instantiate(stickyNotePrefab) as GameObject;

        GameObject newNote = PhotonNetwork.Instantiate(stickyNotePrefab.name, transform.position, Quaternion.identity);
        newNote.transform.SetParent(startingCanvas.transform, false);

        StickyNoteManager.Instance.selectedObject = newNote; //now its selected
    }
}
