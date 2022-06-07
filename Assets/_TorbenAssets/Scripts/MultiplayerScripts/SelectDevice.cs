using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectDevice : MonoBehaviour
{
	public enum avaliableScenes //add the scene names
	{
		SelectDeviceScene, MainMenu, MultiplayerRoom
	}
	public avaliableScenes sceneToLoad;



	public static string deviceType;
	public void DeviceType(string selectedDeviceType)
	{
		if (selectedDeviceType == "CAVE" || selectedDeviceType == "PROJECTOR" || selectedDeviceType == "HMD")
		{
			deviceType = selectedDeviceType; //set the static string to the selectedDeviceType (CAVE or PROJECTOR or HMD)
			SceneManager.LoadScene(sceneToLoad.ToString());
		}
	}
}
