/*-------------------------------------------------------
Creator: Kristina Koseva - adjusted by Torben Storch (changed from Canvas Image to 3D GameObject/prefab)
Expanded Realities P6
last change: 17-07-2022
Topic: Script to Instantiate a StickyNoteUI and set it to StickyNoteManager.Instance.selectedObject
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Instantiate : MonoBehaviour
{

    [SerializeField] private GameObject stickyNotePrefab;
    [SerializeField] private GameObject startingCanvas;
    [SerializeField] GameObject spawnPos;
    public void CreateANote() //adjusted by T.S.
    {
        //GameObject newNote = Instantiate(stickyNotePrefab) as GameObject;

        GameObject newNote = PhotonNetwork.Instantiate(stickyNotePrefab.name, spawnPos.transform.position, Quaternion.identity);
        //newNote.GetComponent<OwnershipTransfer>().TransferOwnership(newNote.GetComponent<PhotonView>());
        //newNote.transform.SetParent(startingCanvas.transform, false);
        StickyNoteManager.Instance.selectedObject = newNote; //now its selected
    }
}
