/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 12-07-2022
Topic: Scriptable Object for scalability (new Projects can easily be added)
Note: currently there are test scenes added to the enum to quickly switch between them in the inspector
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectInformation", fileName = "ProjectInformation")]
public class ProjectScriptableObjectScript : ScriptableObject
{
	public string projectName; //name of the Project
	public enum avaliableProjectScenes //all the scenes that we can switch to (add all scenes for multiplayer aka project rooms)
	{
		MultiplayerRoom, MultiplayerSceneCopy_CAVEDrawing, MultiplayerSceneCopy_CAVEDrawing2 //added 2 test scenes
	}
	public avaliableProjectScenes sceneToLoadWhenJoinedProject;
}
