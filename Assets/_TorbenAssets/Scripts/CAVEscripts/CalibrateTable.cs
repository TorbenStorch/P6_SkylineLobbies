/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 12-07-2022
Topic: Script for Calibrating and Set TablePosition
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CalibrateTable : MonoBehaviour //Script is placed on Table Parent
{
	[Tooltip("Press 'T' to set object to target position")]
	[SerializeField] GameObject target_ControllerDrawPoint;
	
	[SerializeField] PhotonView photonView;
	void Update()
	{
		if (!target_ControllerDrawPoint) target_ControllerDrawPoint = GameObject.FindGameObjectWithTag("ControllerDrawPoint");
		if (Input.GetKeyDown(KeyCode.T) && target_ControllerDrawPoint ) 
		{
			CalibrateTableCall();
		}
	}

	public void CalibrateTableCall()
	{
		if (!target_ControllerDrawPoint) return;
		photonView.RequestOwnership();
		gameObject.transform.position = target_ControllerDrawPoint.transform.position;
	}
}

