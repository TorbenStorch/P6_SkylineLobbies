/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 09-06-2022
Topic: Script to Instantiate the players accordingly to their SelectDevice.deviceType
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks //Spawn the prefabs 
{
	[SerializeField] GameObject prefabCAVE, prefabHMD;
	[SerializeField] Vector3 prefabCavePos, prefabHmdPos;
	[SerializeField] Quaternion prefabCaveRot, prefabHmdRot;

	#region Singleton
	public static RoomManager Instance { set; get; }
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(Instance);
		}
		else
			Destroy(this.gameObject);
	}
	#endregion
	#region Add/Remove OnSceneLoad
	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoad;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoad;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoad;
	}
	#endregion

	private void OnSceneLoad(Scene scene, LoadSceneMode mode)
	{
		if (PhotonNetwork.InRoom)
		{
			switch (SelectDevice.deviceType)
			{
				case "CAVE":
					PhotonNetwork.Instantiate(prefabCAVE.name, prefabCavePos, prefabCaveRot);
					break;

				//case "PROJECTOR":
				//	PhotonNetwork.Instantiate(prefabPROJECTOR, prefabPROJECTORpos, Quaternion.identity);
				//	break;

				case "HMD":
					PhotonNetwork.Instantiate(prefabHMD.name, prefabHmdPos, prefabHmdRot);
					break;

				default:
					break;
			}
		}
	}


}
