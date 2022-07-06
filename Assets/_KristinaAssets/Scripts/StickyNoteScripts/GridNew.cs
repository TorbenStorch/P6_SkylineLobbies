using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridNew : MonoBehaviour
{

    //attach the script to the canvas
    private float _canvasMesurementsX;
    private float _canvasMesurementsY;
    [SerializeField] private int Collums =2;
    [SerializeField] private int Rows =2 ;
    private float _incrementX;
    private float _incrementY;


    private void Start()
    {
        GetCanvasInfo();
        CalculateIncrements();

    }


    public void GetCanvasInfo()
    {
        _canvasMesurementsY =GetComponent<RectTransform>().rect.height;
        _canvasMesurementsX = GetComponent<RectTransform>().rect.width;
       //Debug.Log(_canvasMesurementsY);
       //Debug.Log(_canvasMesurementsX);

    }


    public Vector2 RandomCanvasPos()
    {
        Vector2 output = Vector2.zero;
        output.x = Random.Range(0, _canvasMesurementsX);
        output.y = Random.Range(0, _canvasMesurementsY);

        return output;
    }


    private void CalculateIncrements()
    {
        _incrementX = _canvasMesurementsX/ Rows;
        _incrementY = _canvasMesurementsY / Collums;

    }


    public Vector2 GridSnapPos(Vector2 inputPos)
    {
        Vector2 output = Vector2.zero;
        output.x = Mathf.RoundToInt(inputPos.x / _incrementX) * _incrementX;
        output.y = Mathf.RoundToInt(inputPos.y / _incrementY) * _incrementY;
        Debug.LogWarning(output);
        return output;

    }



}
