/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Capsule - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class VRCapsuleInstantiation : MonoBehaviour
{
    [SerializeField] GameObject myCapsule;

    [SerializeField] bool capsuleHasSpawned;

    public PhotonView photonView;

    public void VRCapsuleCloning()
    {
        if (capsuleHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
        {
            PhotonNetwork.Instantiate("VRCapsule", myCapsule.transform.position, myCapsule.transform.rotation);
            capsuleHasSpawned = true;
            Debug.Log("VR Capsule in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("VRCapsule")), myCapsule.transform.position, myCapsule.transform.rotation);
            capsuleHasSpawned = true;
            Debug.Log("VR Capsule in singleplayer scene has instantiated");
        }
    }
}
