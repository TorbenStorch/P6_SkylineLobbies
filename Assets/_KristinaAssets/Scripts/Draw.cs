using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

    public Camera tableCamera;
    public GameObject brush;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;




    public void Update()
    {
        DrawNow();
    }



    void DrawNow()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = tableCamera.ScreenToWorldPoint(Input.mousePosition);
            
            if(mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }

        }
        else
        {
            currentLineRenderer = null;
        }


    }



    void CreateBrush()
    {

        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = tableCamera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);


    }




    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }


}
