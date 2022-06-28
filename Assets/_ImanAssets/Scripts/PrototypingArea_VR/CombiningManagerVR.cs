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

    private bool firstHit;

    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Interactable"))
    //    {
    //        Debug.Log("VR collision happened between game objects");
    //    }
    //}

    public void ParentsCheck()
    {
        if (firstHit == true)
        {
            Debug.Log("Second hit");
        }
        else
        {
            firstHit = true;
            Debug.Log("First hit");
        }
    }
}
