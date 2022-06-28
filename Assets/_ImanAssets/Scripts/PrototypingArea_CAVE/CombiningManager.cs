/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 28-06-2022
Topic: Script for combining the gameobjects - Prototyping area - CAVE side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class CombiningManager : MonoBehaviour
{
    private bool hascollided;

    public PhotonView photonView;

    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // if(hascollided)
        //  {
        //   return;
        //}

        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("CAVE collision happened between game objects");
            //hascollided = true;
        }
    }
}