using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cube : MonoBehaviour
{
    public PhotonView photonView;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    public void CubeInstantiation()
    {
        
        
        
        
        string objectName = "Interactable";
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cubeObject.transform.localPosition = new Vector3(0, 1, 0);
        cubeObject.transform.localScale = new Vector3(1, 1, 1);
        cubeObject.GetComponent<MeshRenderer>().material.color = Color.red;
        cubeObject.gameObject.tag = objectName;
    }
}
