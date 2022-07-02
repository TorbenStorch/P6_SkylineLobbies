/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 02-07-2022
Topic: Script to Transfer Ownership by calling the function
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OwnershipTransfer : MonoBehaviour
{
	public void TransferOwnership(PhotonView photonView)
	{
		photonView.RequestOwnership();
	}
}
