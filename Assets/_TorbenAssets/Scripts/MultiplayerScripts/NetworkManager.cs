/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 09-06-2022
Topic: Photon Network script (connect to server & lobby, joining/createing a room) -> atm the Functions will be called by the MenuManager
Note: Includes an event that is called when we joined the lobby/can join rooms
---------------------------------------------------------*/
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public sealed class NetworkManager : MonoBehaviourPunCallbacks
{
	string sceneToSwitchTo;
	public event Action connectedToLobbyEvent; //event that gets called when we joined the lobby

	#region Singleton

	public static NetworkManager Instance { set; get; }

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

	#region Connect to Server and join Lobby
	public void StartConnectServer() //Connect to server (own function that is called by the MenuManager)
	{
		Debug.Log("Try to Connect to Server");
		PhotonNetwork.ConnectUsingSettings();
	}
	public override void OnConnectedToMaster() //when we are connected to the server
	{
		Debug.Log("Connected to Server");
		PhotonNetwork.JoinLobby(); //join the lobby of server
	}
	public override void OnJoinedLobby()//when we joined the lobby (first connect to server -> then connect to lobby -> then for ex. create/join a room)
	{
		Debug.Log("Ready to join Multiplayer");
		if (connectedToLobbyEvent != null)
		{
			connectedToLobbyEvent();
		}
	}
	#endregion

	#region Create and Join specific room
	public void CreateOrJoinSpecificRoom(string roomName, string sceneToSwitchToName) //will be called in the button (NewMenuManager)-> the roomName and sceneToSwitchToName will be handeled by a scriptabnleObject
	{
		sceneToSwitchTo = sceneToSwitchToName;
		RoomOptions roomOptions = new RoomOptions()
		{
			IsVisible = true,
			IsOpen = true,
			MaxPlayers = 5,
			PublishUserId = true
		};
		Debug.Log("Room: '" + roomName + "' was created/joined");
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
	}
	#endregion

	public override void OnJoinedRoom()
	{
		Debug.Log("Room Joined");
		PhotonNetwork.LoadLevel(sceneToSwitchTo);
	}
}
