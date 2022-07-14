/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Capsule - Prototyping area 
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class CapsuleInstantiation : MonoBehaviour
{
    [SerializeField] GameObject myCapsule;

    [SerializeField] bool capsuleHasSpawned;

    public PhotonView photonView;

    public void CapsuleCloning()
    {
        if (capsuleHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
        {
            PhotonNetwork.Instantiate("Capsule", myCapsule.transform.position, myCapsule.transform.rotation);
            capsuleHasSpawned = true;
            Debug.Log("Capsule in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("Capsule")), myCapsule.transform.position, myCapsule.transform.rotation);
            capsuleHasSpawned = true;
            Debug.Log("Capsule in singleplayer scene has instantiated");
        }
    }
}
