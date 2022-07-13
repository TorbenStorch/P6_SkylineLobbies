/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 13-07-2022
Topic: Script to lock movement with an simple interactor on 2 axis -> attached to Select event inside XRSimpleInteractable
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class UIStickyNoteMovement : MonoBehaviour
{

	bool start;
	GameObject target;
	XRSimpleInteractable simpleInteractable;

	private void Start()
	{
		simpleInteractable = GetComponent<XRSimpleInteractable>();
	}
	public void StartMovement()
	{
		target = simpleInteractable.GetOldestInteractorSelecting().transform.gameObject; 
		start = true;
	}
	public void StopMovement()
	{
		target = null;
		start = false;
	}

	private void Update()
	{
		if (start)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, target.transform.position.y, target.transform.position.z/*target.transform.position.z*/);
		}
	}

}
