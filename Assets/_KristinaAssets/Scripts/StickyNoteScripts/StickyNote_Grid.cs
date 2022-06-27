using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNote_Grid : MonoBehaviour
{
    [SerializeField] private GridNew newGrid;
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
        transform.SetParent(newGrid.transform);
        this.transform.localPosition = newGrid.GridSnapPos(this.transform.localPosition);

    }


}
