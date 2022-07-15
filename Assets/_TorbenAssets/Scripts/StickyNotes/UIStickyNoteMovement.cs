/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 15-07-2022
Topic: Script to lock movement with an simple interactor on 2 axis -> attached to Select event inside XRSimpleInteractable
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//[RequireComponent(typeof(XRSimpleInteractable))]
public class UIStickyNoteMovement : MonoBehaviour
{

	bool start;
	GameObject target;


	[SerializeField] bool usingSimpleInteractableAndControllerPos;
	[SerializeField] XRSimpleInteractable simpleInteractable;
	[SerializeField] bool usingGrabInteractableWithoutForceGrab;
	Vector3 startPos;

	private void Start()
	{
		//simpleInteractable = GetComponent<XRSimpleInteractable>();
		if (usingGrabInteractableWithoutForceGrab)
		{
			startPos = gameObject.transform.position;
		}
	}
	public void StartMovement()
	{
		if (usingSimpleInteractableAndControllerPos)
		{
			target = simpleInteractable.GetOldestInteractorSelecting().transform.gameObject;
			start = true;
		}
	}
	public void StopMovement()
	{
		if (usingSimpleInteractableAndControllerPos)
		{
			target = null;
			start = false;
		}
	}

	private void Update()
	{
		if (usingSimpleInteractableAndControllerPos)
		{
			if (start)
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, target.transform.position.y, target.transform.position.z/*target.transform.position.z*/);
			}
		}
		if (usingGrabInteractableWithoutForceGrab)
		{
			gameObject.transform.position = new Vector3(startPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}


	}

}
