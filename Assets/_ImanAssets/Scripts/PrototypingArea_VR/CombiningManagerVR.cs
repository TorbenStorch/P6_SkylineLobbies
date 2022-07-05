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
    public PhotonView photonView;


    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("VR collision happened between game objects");
        }
    }
}
