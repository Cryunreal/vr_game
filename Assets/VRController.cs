using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRController : MonoBehaviour
{

    public uint index;
    public VRControllerState_t controllerState;


    public bool steamPressed = false;
    public bool menuPressed = false;
    public bool grippedPressed = false;

    public bool triggerPressed = false;
    public bool triggerTouched = false;
    public float triggerValue = 0.0f;

    public bool padPressed = false;
    public bool padTouched = false;
    public Vector2 padDirection = Vector2.zero;


    private bool steamPressedOld = false;
    private bool menuPressedOld = false;
    private bool grippedPressedOld = false;

    private bool triggerPressedOld = false;
    private bool triggerTouchedOld = false;
    private float triggerValueOld = 0.0f;

    private bool padPressedOld = false;
    private bool padTouchedOld = false;
    private Vector2 padDirectionOld = Vector2.zero;

    void Start()
    {
        index = (uint)this.GetComponent<SteamVR_TrackedObject>().index;
    }

    void Update()
    {
        var system = OpenVR.System;
        if (system != null)
        {
            system.GetControllerState(index, ref controllerState);
            padDirection.x = controllerState.rAxis0.x;
            padDirection.y = controllerState.rAxis0.y;
            triggerValue = controllerState.rAxis1.x;

            triggerPressed = triggerValue >= (1.0f - float.Epsilon);
            triggerTouched = triggerValue > float.Epsilon;
            grippedPressed = (controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_Grip))) > 0L;
            menuPressed = (controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_ApplicationMenu))) > 0L;
            padPressed = (controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_SteamVR_Touchpad))) > 0L;
            padTouched = (controllerState.ulButtonTouched & (1UL << ((int)EVRButtonId.k_EButton_SteamVR_Touchpad))) > 0L;

            if (triggerPressed && !triggerPressedOld)
            {
                OnTriggerClicked();
            }
            else if ((!triggerPressed) && triggerPressedOld)
            {
                OnTriggerUnclicked();
            }

            if (triggerTouched && !triggerTouchedOld)
            {
                OnTriggerTouched();
            }
            else if ((!triggerTouched) && triggerTouchedOld)
            {
                OnTriggerUntouched();
            }

            if (grippedPressed && !grippedPressedOld)
            {
                OnGripped();
            }
            else if ((!grippedPressed) && grippedPressedOld)
            {
                OnUngripped();
            }

            if (menuPressed && !menuPressedOld)
            {
                OnMenuClicked();
            }
            else if ((!menuPressed) && menuPressedOld)
            {
                OnMenuUnclicked();
            }

            if (padPressed && !padPressedOld)
            {
                OnPadClicked();
            }
            else if ((!padPressed) && padPressedOld)
            {
                OnPadUnclicked();
            }

            if (padTouched && !padTouchedOld)
            {
                OnPadTouched();
            }
            else if ((!padTouched) && padTouchedOld)
            {
                OnPadUntouched();
            }

            steamPressedOld = steamPressed;
            menuPressedOld = menuPressed;
            grippedPressedOld = grippedPressed;

            triggerPressedOld = triggerPressed;
            triggerTouchedOld = triggerTouched;
            triggerValueOld = triggerValue;

            padPressedOld = padPressed;
            padTouchedOld = padTouched;
            padDirectionOld = padDirection;
            padDirection.x = controllerState.rAxis0.x;
            padDirection.y = controllerState.rAxis0.y;
            triggerValue = controllerState.rAxis1.x;
        }
    }

    public virtual void OnTriggerClicked()
    {
        
    }

    public virtual void OnTriggerUnclicked()
    {
    }

    public virtual void OnTriggerTouched()
    {
    }

    public virtual void OnTriggerUntouched()
    {
    }

    public virtual void OnMenuClicked()
    {
    }

    public virtual void OnMenuUnclicked()
    {
    }

    public virtual void OnPadClicked()
    {
    }

    public virtual void OnPadUnclicked()
    {
    }

    public virtual void OnPadTouched()
    {
    }

    public virtual void OnPadUntouched()
    {
    }

    public virtual void OnGripped()
    {
    }

    public virtual void OnUngripped()
    {
    }
}
