/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 06-07-2022
Topic: Sticks/Parents StickyNote when pin attached
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class StickyNotePinAttach : MonoBehaviour
{
	[Header("The Attach Pin needs the tag: AttachPin")]
	[SerializeField] GameObject rayOrigin;
	private void Update()
	{
		Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward * 0.1f, Color.green);
	}
	public void RayCastParent()
	{
		RaycastHit hitObject;
		if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hitObject, 0.1f))
		{
			if(hitObject.collider.gameObject.tag != "AttachPin") gameObject.transform.parent = hitObject.collider.gameObject.transform;
			gameObject.GetComponent<XRGrabInteractable>().enabled = false;
		}
	}

	public void RemoveParent()
	{
		gameObject.transform.parent = null;
		gameObject.GetComponent<XRGrabInteractable>().enabled = true;
	}

	private void OnDisable() //does not work?
	{
		gameObject.transform.parent = null;
	}
}
