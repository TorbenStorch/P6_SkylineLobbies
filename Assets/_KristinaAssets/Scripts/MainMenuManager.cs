using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

    private GameObject currentActivePanel; 
    
    private bool isCampusPanelActive;
    
    private Vector3 _initialCardPosition;



    [SerializeField]
    private GameObject mapPanel;


    //----Sofia----//
    [SerializeField]
    private GameObject sofiaPanel;
    [SerializeField]
    private GameObject[] sofiaProjectCards;

    //----Cluj----//
    [SerializeField]
    private GameObject clujPanel;
    [SerializeField]
    private GameObject[] clujProjectCards;

    //----Cyprus----//
    [SerializeField]
    private GameObject cyprusPanel;
    [SerializeField]
    private GameObject[] cyprusProjectCards;

    //----Darmstadt----//
    [SerializeField]
    private GameObject darmstadtPanel;
    [SerializeField]
    private GameObject[] darmstadtProjectCards;

    //----more----//


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            switchToSofia();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Refresh();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            switchToMap();
        }

    }


    public void switchToSofia()
    {

            mapPanel.SetActive(false);
            sofiaPanel.SetActive(true);

            currentActivePanel = sofiaPanel;
            isCampusPanelActive = true;


    }

    public void switchToCluj()
    {
        mapPanel.SetActive(false);
        clujPanel.SetActive(true);

        currentActivePanel = clujPanel;
        isCampusPanelActive = true;

    }

    public void switchToCyprus()
    {
        mapPanel.SetActive(false);
        cyprusPanel.SetActive(true);

        currentActivePanel = cyprusPanel;
        isCampusPanelActive = true;

    }

    public void switchToDarmstadt()
    {
        mapPanel.SetActive(false);
        darmstadtPanel.SetActive(true);

        currentActivePanel = darmstadtPanel;
        isCampusPanelActive = true;

    }





    public void switchToMap()
    {

            currentActivePanel.SetActive(false);

            isCampusPanelActive = false;

            mapPanel.SetActive(true);


    }





    public void checkActivePanel()
    {
        if(currentActivePanel == false)
        {
            mapPanel.SetActive(true);
        }
        else
        {
            return;
        }
    }




    public void Refresh()
    {
        //----Sofia----//

        foreach (GameObject card in sofiaProjectCards)
        {
                card.SetActive(true);
                card.transform.localPosition = new Vector2(0, 0);
                card.transform.localEulerAngles = new Vector3(0, 0, 0);

                card.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        


        //----Cluj----//
        foreach (GameObject card in clujProjectCards)
        {
            card.SetActive(true);
            card.transform.localPosition = new Vector2(0, 0);
            card.transform.localEulerAngles = new Vector3(0, 0, 0);

            card.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }


        /*
        //----Cyprus----//
        foreach (GameObject card in cyprusProjectCards)
        {
            card.SetActive(true);
            card.transform.localPosition = new Vector2(0, 0);
            card.transform.localEulerAngles = new Vector3(0, 0, 0);

            card.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        */

    }




    //-----------------------------------------





    public void ExitGame()
    {
        Application.Quit();
    }


}