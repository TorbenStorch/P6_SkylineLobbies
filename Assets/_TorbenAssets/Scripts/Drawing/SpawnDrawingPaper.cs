/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 02-07-2022
Topic: Script to Instantiate the Draw-Paper inside the cave & move it back & forth
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnDrawingPaper : MonoBehaviour
{
	[SerializeField] GameObject prefabDrawingPaper;
	[SerializeField] GameObject caveWhiteboardPos;
	[SerializeField] float moveSpeed = 10f;

	XRGrabInteractable xRGrabInteractable;

	GameObject paper;
	Vector3 originPos;
	bool canMove = true;
	public void SpawnPaper()
	{
		if (PhotonNetwork.InRoom)
			paper = PhotonNetwork.Instantiate(prefabDrawingPaper.name, caveWhiteboardPos.transform.position, Quaternion.identity);
		else
			paper = Instantiate(prefabDrawingPaper, caveWhiteboardPos.transform.position, Quaternion.identity);

		originPos = caveWhiteboardPos.transform.position;
		xRGrabInteractable = paper.GetComponent<XRGrabInteractable>();
		if (xRGrabInteractable != null) xRGrabInteractable.enabled = false;
	}

	public void PushPaperToHmd(GameObject paperHmdPos)
	{
		if (canMove)
		{
			StartCoroutine(MovePaper(paperHmdPos.transform.position));
			if (xRGrabInteractable != null) xRGrabInteractable.enabled = true;
			canMove = false;
		}
	}
	public void PushPaperToCave()
	{
		if (canMove)
		{
			StartCoroutine(MovePaper(originPos));
			if (xRGrabInteractable != null) xRGrabInteractable.enabled = false;
			canMove = false;
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