/*-------------------------------------------------------
Creator: Kristina Koseva - adjusted by Torben Storch (changed from Canvas-Image to 3D-GameObject/prefab)
Expanded Realities P6
last change: 17-07-2022
Topic: Script to place the StickyNote onto a grid 
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNote_Grid : MonoBehaviour
{
    
    [SerializeField] private GridNew newGrid; //the whiteboard is the new grid
    [SerializeField] private bool _start = false;
	private float gridNumber = 0;

	private void Update()
    {
        if (_start)
        {
            PlaceThisOnGrid();
            _start = false;
        }
    }

    public void PlaceThisOnGrid()// adjusted by T.S. 
    {

        _start = true;

        GameObject thisNote = StickyNoteManager.Instance.selectedObject;

        //thisNote.transform.localPosition = newGrid.GridSnapPos(newGrid.RandomCanvasPos());



        // adjusted by T.S. (placed the sticky note prefabs on a set position and move it back each time a new one comes)
        Vector3 pos = newGrid.transform.position + new Vector3(0,0,gridNumber);
        gridNumber -= thisNote.transform.localScale.z * 6f;
        thisNote.transform.position = pos;
        //thisNote.transform.rotation = newGrid.transform.rotation;
        thisNote.transform.rotation = Quaternion.Euler(0,0,90);
        //thisNote.transform.SetParent(newGrid.transform);


    }


}
