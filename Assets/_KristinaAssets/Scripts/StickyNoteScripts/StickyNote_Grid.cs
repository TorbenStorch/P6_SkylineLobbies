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

    public void PlaceThisOnGrid()
    {

        _start = true;

        GameObject thisNote = StickyNoteManager.Instance.selectedObject;

        //thisNote.transform.localPosition = newGrid.GridSnapPos(newGrid.RandomCanvasPos());

        Vector3 pos = newGrid.transform.position + new Vector3(0,0,gridNumber);
        gridNumber -= thisNote.transform.localScale.z * 6f;
        thisNote.transform.position = pos;
        //thisNote.transform.rotation = newGrid.transform.rotation;
        thisNote.transform.rotation = Quaternion.Euler(0,0,90);
        //thisNote.transform.SetParent(newGrid.transform);


    }


}
