/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    public GameObject MainMenu;
    public GameObject CalibrationMenu;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "CalibrateButton")
        {
            Debug.Log("Entered Calibration");
            MainMenu.SetActive(false);
            CalibrationMenu.SetActive(true);
        }
        else if (e.target.name == "ExitButton")
        {
            Debug.Log("Exited Calibration");
            CalibrationMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "CalibrateButton")
        {
            Debug.Log("CalibrateButton Button was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
            
            if (e.target.name == "PlayButton")
        {
            Debug.Log("PlayButton Button was clicked");
        } else if (e.target.name == "Button")
        {
            Debug.Log("Button was clicked");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        // if (e.target.name == "StartButton")
        // {
        //     Debug.Log("Start Button was exited");
        // }
        // else if (e.target.name == "Button")
        // {
        //     Debug.Log("Button was exited");
        // }

        // if (e.target.name == "ExitButton")
        // {
        //     Debug.Log("Exit Button was clicked");
        // } else if (e.target.name == "Button")
        // {
        //     Debug.Log("Button was clicked");
        // }
    }
}