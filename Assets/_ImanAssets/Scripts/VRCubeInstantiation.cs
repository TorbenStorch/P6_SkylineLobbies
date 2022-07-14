/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Cube - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class VRCubeInstantiation : MonoBehaviour
{
    [SerializeField] GameObject myCube;

    [SerializeField] bool cubeHasSpawned;

    public PhotonView photonView;

    public void VRCubeCloning()
    {
        if (cubeHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
        {
            PhotonNetwork.Instantiate("VRCube", myCube.transform.position, myCube.transform.rotation);
            cubeHasSpawned = true;
            Debug.Log("VR Cube in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("VRCube")), myCube.transform.position, myCube.transform.rotation);
            cubeHasSpawned = true;
            Debug.Log("VR Cube in singleplayer scene has instantiated");
        }
    }
}
