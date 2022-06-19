using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColourObjectExample : MonoBehaviour
{
    public InputActionReference colourReference = null;

    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float value = colourReference.action.ReadValue<float>();
        UpdateColour(value);
    }

    private void UpdateColour(float value)
    {
        meshRenderer.material.color = new Color(value, value, value);
    }
}
