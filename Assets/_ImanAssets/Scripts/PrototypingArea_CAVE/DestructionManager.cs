/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 26-06-2022
Topic: Script for destroying the gameobjects - Prototyping area - CAVE side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class DestructionManager : MonoBehaviour
{
    GameObject[] myObjects;

    public PhotonView photonView;

    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    public void DestroyAll()
    {
        myObjects = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject obj in myObjects)
        {
            Destroy(obj);
        }
    }
}
