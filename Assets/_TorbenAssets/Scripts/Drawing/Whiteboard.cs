/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 12-07-2022
Topic: Script to setup the whiteboard
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using System;

public class Whiteboard : MonoBehaviour
{
	[HideInInspector] public Texture2D texture;
	public float sizeOfTexture = 1f;
	[HideInInspector] public Vector2 textureSize = new Vector2(2048, 2048);

	[SerializeField] PhotonView photonView;

	public void Start()
	{
		if (PhotonNetwork.InRoom && photonView.IsMine)//failed test to make it an RPC (no time left to look into it further atm)
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

		Color[] pixels = Enumerable.Repeat(Color.white, (int)textureSize.x * (int)textureSize.y).ToArray(); //set the texture to white (needed for eraser - white marker)
		texture.SetPixels(pixels);
		texture.Apply();

		r.material.mainTexture = texture;
	}
}