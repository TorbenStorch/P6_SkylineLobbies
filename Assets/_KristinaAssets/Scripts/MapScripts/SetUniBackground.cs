using UnityEngine;

public class SetUniBackground : MonoBehaviour
{



    [SerializeField]
    private GameObject sofia3DMap;

    //drag and drop the gameObject sphere in the inspector
    //(the sphere that encapsulates the cameras, we use it as a background by having the FlippedNormals script on it too)
    [SerializeField]
    private GameObject gameObjectSphere;

    //drag and drop the game object's material in the inspector
    [SerializeField]
    private Material m_mat;

    //drag and drop the textures you want it to cycle through in the inspector
    [SerializeField]
    private Texture m_MainTexture, m_SofiaTexture, m_ClujNapocaTexture;

    

    Renderer m_Renderer;
    //m_Renderer = GetComponent<Renderer>();



    void Start()
    {

        //get the sphere's renderer component on start
        Renderer m_Renderer = gameObjectSphere.GetComponent<Renderer>();
        m_mat = gameObjectSphere.GetComponent<Renderer>().material;
        //set the material on start

        //m_mat.SetTexture("_MainTex", m_MapTexture);
        //set the material's texture on start
        SetMapTexture();
        Debug.Log("map texture is set to MAP on START");

    }





    //reference these in the button OnClick() event
    public void SetMapTexture()
    {

        m_mat.SetTexture("_BaseMap", m_MainTexture);
        Debug.Log("map texture is set back to MAP");

        sofia3DMap.SetActive(false);

    }


    public void SetSofiaTexture()
    {

        m_mat.SetTexture("_BaseMap", m_SofiaTexture);
        Debug.Log("map texture is set to SOFIA");

    }

    public void SetClujTexture()
    {

        m_mat.SetTexture("_BaseMap", m_ClujNapocaTexture);
        Debug.Log("map texture is set to CLUJ");

    }




    public void SetSofia3DActive()
    {

        sofia3DMap.SetActive(true);
        Debug.Log("map texture is set to CLUJ");

    }

}