using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNote_Grid : MonoBehaviour
{
    
    [SerializeField] private GridNew newGrid; //the whiteboard is the new grid
    [SerializeField] private bool _start = false;

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

        thisNote.transform.localPosition = newGrid.GridSnapPos(newGrid.RandomCanvasPos());
        thisNote.transform.rotation = newGrid.transform.rotation;

        thisNote.transform.SetParent(newGrid.transform);

    }


}
