/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 28-06-2022
Topic: Script for combining the gameobjects - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class CombiningManagerVR : MonoBehaviour
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
        if (other.CompareTag("Interactable"))
        {
            Debug.Log("collision happened");
        }
    }
}
