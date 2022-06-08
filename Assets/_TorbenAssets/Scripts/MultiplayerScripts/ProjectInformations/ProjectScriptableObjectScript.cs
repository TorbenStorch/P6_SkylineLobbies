using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectInformation", fileName = "ProjectInformation")]
public class ProjectScriptableObjectScript : ScriptableObject
{
	public string projectName; //name of the Project
	public enum avaliableProjectScenes //all the scenes that we can switch to (add all scenes for multiplayer aka project rooms)
	{
		MultiplayerRoom
	}
	public avaliableProjectScenes sceneToLoadWhenJoinedProject;
}
