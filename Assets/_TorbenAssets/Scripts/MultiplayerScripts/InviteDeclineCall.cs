/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 15-07-2022
Topic: Script to Spawn Buttons & PS
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InviteDeclineCall : MonoBehaviour
{

	[SerializeField] PhotonView photonView;

	[Header("Set them to inactive in the inspector!")]
	[SerializeField] GameObject[] buttons;
	[SerializeField] ParticleSystem thisParticleSystem;

	public void ShowButtons()
	{
		if (PhotonNetwork.InRoom && photonView.IsMine)
        {
			photonView.RequestOwnership();
			photonView.RPC("ActivateButtons", RpcTarget.All);
		}

		else if (!PhotonNetwork.InRoom)
			ActivateButtons();
	}

	[PunRPC]
	public void ActivateButtons()
	{
		foreach (var item in buttons)
		{
			item.SetActive(true);
		}
	}

	public void ShowParticleSystem()
	{
		if (PhotonNetwork.InRoom && photonView.IsMine) 
		{
			photonView.RequestOwnership();
			photonView.RPC("PlayParticleSystem", RpcTarget.All);
		}

		else if (!PhotonNetwork.InRoom)
			PlayParticleSystem();
	}

	[PunRPC]
	public void PlayParticleSystem()
	{
		thisParticleSystem.gameObject.SetActive(true);
		thisParticleSystem.Play();
	}
}
