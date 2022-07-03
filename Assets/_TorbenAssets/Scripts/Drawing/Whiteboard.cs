///*-------------------------------------------------------
//Creator: Torben Storch
//Expanded Realities P6
//last change: 25-06-2022
//Topic: Script to setup the whiteboard
//---------------------------------------------------------*/
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Whiteboard : MonoBehaviour
//{
//	[HideInInspector] public Texture2D texture;
//	public float sizeOfTexture = 1f;
//	[HideInInspector] public Vector2 textureSize = new Vector2(2048, 2048);

//	private void Start()
//	{
//		textureSize = new Vector2(sizeOfTexture, (gameObject.transform.localScale.z/gameObject.transform.localScale.x) * sizeOfTexture);

//		var r = GetComponent<Renderer>();
//		texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
//		r.material.mainTexture = texture;
//	}
//}


/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 25-06-2022
Topic: Script to setup the whiteboard
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Whiteboard : MonoBehaviour
{
	[HideInInspector] public Texture2D texture;
	public float sizeOfTexture = 1f;
	[HideInInspector] public Vector2 textureSize = new Vector2(2048, 2048);

	[SerializeField] PhotonView photonView;

	public void Start()
	{
		if (PhotonNetwork.InRoom && photonView.IsMine      && PhotonNetwork.IsMasterClient) //TEST MASTER CLIENT
			photonView.RPC("Setup", RpcTarget.AllBuffered);
		else if (!PhotonNetwork.InRoom)
			Setup();
	}

	[PunRPC]
	public void Setup()
	{
		textureSize = new Vector2(sizeOfTexture, (gameObject.transform.localScale.z / gameObject.transform.localScale.x) * sizeOfTexture);

		var r = GetComponent<Renderer>();
		texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
		r.material.mainTexture = texture;
	}
}