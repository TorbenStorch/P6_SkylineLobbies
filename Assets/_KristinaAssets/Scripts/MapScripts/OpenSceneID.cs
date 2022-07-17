/*-------------------------------------------------------
Creator: Kristina Koseva
Expanded Realities P6
last change: 17-07-2022
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneID : MonoBehaviour
{
    public void OpenScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }


}
