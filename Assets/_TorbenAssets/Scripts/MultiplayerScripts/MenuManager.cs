using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
	public GameObject[] activateButtons; //those buttons should only be used when we joined the server & lobby

	#region Join Server & Lobby
	private void Start()
	{
		if (activateButtons != null)
			foreach (var item in activateButtons)
			{
				item.SetActive(false); //deactivate all buttons that let us join rooms (only want to have them active when usable)
			}
		FindObjectOfType<NetworkManager>().connectedToLobbyEvent += ConnectedToServerAndLobby; //connect to the event (when joined server&lobby) as listener
		ConnectToServer(); // we want to automaticly join the server & lobby -> therefore in start instead of calling it via button
	}
	void ConnectToServer()
	{
		NetworkManager.Instance.StartConnectServer(); //will join the server
	}
	void ConnectedToServerAndLobby() //will be called once the player joined the lobby (added to the event "connectedToLobbyEvent" from NewNetworkManager)
	{
		if (activateButtons != null)
			foreach (var item in activateButtons)
			{
				item.SetActive(true); //now we can activate the buttons that let us join rooms
			}
	}
	#endregion

	//will be called by a buttonOnClick event (just drag the ProjectScriptableObject into the slot to send over name and scene.name)
	public void CreateOrJoinSpecificRoom(ProjectScriptableObjectScript projectToJoin) //connection to the Project Scriptable Obj (has info about name & scene of projects)
	{
		if (projectToJoin != null)
		{
			NetworkManager.Instance.CreateOrJoinSpecificRoom(projectToJoin.projectName, projectToJoin.sceneToLoadWhenJoinedProject.ToString());
		}
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
