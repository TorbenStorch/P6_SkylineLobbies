/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 02-07-2022
Topic: Script to Transfer Ownership by entering Trigger Area
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OwnershipTransferTrigger : MonoBehaviour
{
	//[SerializeField] GameObject[] targetArray;
	[SerializeField] PhotonView photonView;
	private void OnTriggerEnter(Collider other)
	{
		//foreach (var item in targetArray)
		//{
		//	if (other.gameObject == item)
		//	{
		//		photonView.RequestOwnership();
		//	}
		//}

		if (other.gameObject.CompareTag("Hand"))
		{
			photonView.RequestOwnership();
		}
	}
}
