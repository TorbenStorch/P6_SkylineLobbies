/*-------------------------------------------------------
Creator: Code from Prof. Grimm - Implemented by Torben Storch
Expanded Realities P6
last change: 02-06-2022
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCameras : MonoBehaviour
{
	private void Start()
	{
		createMultiDisplay();
	}
	void createMultiDisplay()
	{
		//Debug.Log(Display.displays.Length);
		for (int i = 1; i < Display.displays.Length; i++)
			Display.displays[i].Activate();
	}
}
