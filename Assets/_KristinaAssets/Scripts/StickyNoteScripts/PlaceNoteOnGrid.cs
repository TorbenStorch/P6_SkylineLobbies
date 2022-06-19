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




    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = tableCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceNear(hitInfo.point);
            }
    
        
        }
    
    
    }



    private void PlaceNear(Vector3 nearPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(nearPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;
    }




}
