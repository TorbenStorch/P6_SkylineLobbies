/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 03-07-2022
Topic: Script for Calibrating and Set TablePosition
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateTable : MonoBehaviour //Script is placed on Table Parent
{
	[Tooltip("Press 'T' to set object to target position")]
	[SerializeField] GameObject target;
	void Update()
	{
		if (!target) target = GameObject.FindGameObjectWithTag("ControllerDrawPoint");
		if (Input.GetKeyDown(KeyCode.T) && target) 
		{
			gameObject.transform.position = target.transform.position; 
		}
	}
}

