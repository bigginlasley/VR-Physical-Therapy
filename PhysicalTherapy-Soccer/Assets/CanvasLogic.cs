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
        CalibrationMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void EnterCalibrationButton()
    {
        Debug.Log("Entered Calibration");
        MainMenu.SetActive(false);
        CalibrationMenu.SetActive(true);
    }
}