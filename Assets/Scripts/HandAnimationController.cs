using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimationController : MonoBehaviour
{

    public InputDeviceCharacteristics controllerType;
    public InputDevice thisController;

    private bool isControllerDetected = false;
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        Initialise();
        animatorController = GetComponent<Animator>();
    }

    void Initialise()
    {
        List<InputDevice> controllerDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerType, controllerDevices);

        if (controllerDevices.Count.Equals(0))
        {
            //Debug.Log("List is empty");
        }
        else
        {
            thisController = controllerDevices[0];
            //Debug.Log(thisController.name);
            isControllerDetected = true;
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        if(!isControllerDetected)
        {
            Initialise();
        }
        else
        {
            if (thisController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            {
                //Debug.Log("Trigger Press");
                animatorController.SetFloat("Trigger", triggerValue);
            }
            if (thisController.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
            {
                //Debug.Log("Grip Press " + gripValue);
                // //access the animator component - control a value - grip animation
                animatorController.SetFloat("Grip", gripValue);
            }
        }
            
               
    }
}
