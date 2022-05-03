/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    public GameObject MainMenu;
    public GameObject CalibrationMenu;
    public GameObject PlayMenu;

    public UnityEvent EnteredCalibration;
    public UnityEvent ExitedCalibration;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    void Start() {
        // Start with the MainMenu frame visible
        MainMenu.SetActive(true);
        CalibrationMenu.SetActive(false);
        PlayMenu.SetActive(false);    
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        // Enter calibration frame
        if (e.target.name == "CalibrateButton")
        {
            Debug.Log("SceneHandler: Entered Calibration");
            MainMenu.SetActive(false);
            CalibrationMenu.SetActive(true);
            EnteredCalibration.Invoke();
        }
        // Exit calibration frame
        else if (e.target.name == "LeaveCalibrationButton")
        {
            Debug.Log("SceneHandler: Exited Calibration");
            CalibrationMenu.SetActive(false);
            MainMenu.SetActive(true);
            ExitedCalibration.Invoke();
        }
        // Enter play frame
        else if (e.target.name == "PlayButton")
        {
            Debug.Log("SceneHandler: Entered Game");
            MainMenu.SetActive(false);
            PlayMenu.SetActive(true);
        }
        // Exit play frame
        else if (e.target.name == "LeavePlayButton")
        {
            Debug.Log("SceneHandler: Exited Game");
            PlayMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
    }
}