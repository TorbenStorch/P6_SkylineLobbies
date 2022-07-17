/*-------------------------------------------------------
Creator: Kristina Koseva
Expanded Realities P6
last change: 17-07-2022
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNoteOnGrid : MonoBehaviour
{

    private Grid grid;
    private Camera tableCamera;



    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }



    public void PlaceNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;
    }




}
