/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Cube - Prototyping area - CAVE side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class CubeInstantiation : MonoBehaviour
{
    [SerializeField] GameObject myCube;

    [SerializeField] bool cubeHasSpawned;

    public PhotonView photonView;

    public void CubeCloning()
    {
        if (cubeHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
        {
            PhotonNetwork.Instantiate("CAVECube", myCube.transform.position, myCube.transform.rotation);
            cubeHasSpawned = true;
            Debug.Log("Cube in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("CAVECube")), myCube.transform.position, myCube.transform.rotation);
            cubeHasSpawned = true;
            Debug.Log("Cube in singleplayer scene has instantiated");
        }
    }
}
