using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_RaycastRay : MonoBehaviour
{
	[SerializeField]
	private Camera rayOriginCam;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) /*&& photonView.IsMine*/)
		{
			Ray ray = rayOriginCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				T_RaycastButton rayHitButton = hit.collider.gameObject.GetComponent<T_RaycastButton>(); //needs box collider

				if (rayHitButton != null)
				{
					rayHitButton.OnButtonClick();
				}
			}
		}
	}



}
