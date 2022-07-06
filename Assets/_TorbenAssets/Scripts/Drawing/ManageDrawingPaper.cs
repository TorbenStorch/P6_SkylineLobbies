/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 03-07-2022
Topic: Script to Instantiate the Draw-Paper inside the cave & move it back & forth
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class ManageDrawingPaper : MonoBehaviour
{
	[SerializeField] GameObject prefabDrawingPaper;
	[SerializeField] GameObject caveWhiteboardPos;
	[SerializeField] float moveSpeed = 10f;

	XRGrabInteractable xRGrabInteractable;

	GameObject paper;
	
	bool canMove = true;

	public void SpawnPaper()
	{
		if (PhotonNetwork.InRoom)
			paper = PhotonNetwork.Instantiate(prefabDrawingPaper.name, caveWhiteboardPos.transform.position, Quaternion.identity);
		else
			paper = Instantiate(prefabDrawingPaper, caveWhiteboardPos.transform.position, Quaternion.identity);
		xRGrabInteractable = paper.GetComponent<XRGrabInteractable>();
		if (xRGrabInteractable != null) xRGrabInteractable.enabled = false;
	}

	public void PushPaperToHmd(GameObject paperHmdPos)
	{
		if (canMove)
		{
			canMove = false;

			paper.GetComponent<PhotonView>().RequestOwnership();

			StartCoroutine(MovePaper(paperHmdPos.transform.position));
			if (xRGrabInteractable != null) xRGrabInteractable.enabled = true;
		}
	}
	public void PushPaperToCave()
	{
		if (canMove)
		{
			canMove = false;

			paper.GetComponent<PhotonView>().RequestOwnership();

			StartCoroutine(MovePaper(caveWhiteboardPos.transform.position));
			if (xRGrabInteractable != null) xRGrabInteractable.enabled = false;
			paper.transform.rotation = Quaternion.identity;
		}
	}

	IEnumerator MovePaper(Vector3 destination)
	{
		while (paper.transform.position != destination)
		{
			paper.transform.position = Vector3.MoveTowards(paper.transform.position, destination, moveSpeed * Time.deltaTime);
			yield return null;
		}
		canMove = true;
		yield return null;
	}
}