/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 09-06-2022
Topic: Script to select the specific Device
Note: The deviceType will be selected in the staring Scene of each device (-> VR and CAVE have different staring Scenes)
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectDevice : MonoBehaviour
{
	public enum deviceTypeEnum //add the scene names
	{
		CAVE, HMD, PROJECTOR
	}
	public deviceTypeEnum deviceTypeOptions;

	public static string deviceType;
	public void Start()
	{
		deviceType = deviceTypeOptions.ToString();
	}
}
