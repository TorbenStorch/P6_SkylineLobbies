using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//will allow to get InputDevise
using UnityEngine.XR;

//creating list of input devices to store our input devices in
public class InputReader : MonoBehaviour
{
    List<InputDevice> inputDevices = new List<InputDevice>();

    // Start is called before the first frame update
    void Start()
    {
        //try and initialize inputreader here but all components may not be loaded
        InitializeInputReader();
    }

    //will try to initialize inputreader by getting all devices and printing them in debug.log
    void InitializeInputReader()
    {
        //InputDevices.GetDevices(inputDevices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, inputDevices);

        foreach (var inputDevice in inputDevices)
        {
            inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
            Debug.Log(inputDevice.name + " " + triggerValue);
            //Debug.Log(inputDevice.name + " " + inputDevice.characteristics);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //should have 3 input devices at least for the headset and 2 controllers soo if thats not the case lez reinitialize them again
        if(inputDevices.Count < 2)
        {
            InitializeInputReader();
        }
    }
}
