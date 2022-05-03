using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLogic : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CalibrationMenu;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ExitCalibrationButton()
    {
        Debug.Log("CanvasLogic: Exited Calibration");
        CalibrationMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void EnterCalibrationButton()
    {
        Debug.Log("CanvasLogic: Entered Calibration");
        MainMenu.SetActive(false);
        CalibrationMenu.SetActive(true);
    }
}