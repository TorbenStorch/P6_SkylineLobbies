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
