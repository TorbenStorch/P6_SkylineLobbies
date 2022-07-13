using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIStickyNoteMovement : MonoBehaviour
{

	bool start;
	GameObject target;
	XRSimpleInteractable simpleInteractable;

	public void StartMovement()
	{
		target = target = simpleInteractable.GetOldestInteractorSelecting().transform.gameObject; 
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
			gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, gameObject.transform.position.z/*target.transform.position.z*/);
		}
	}

}
