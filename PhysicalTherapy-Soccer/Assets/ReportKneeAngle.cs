using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReportKneeAngle : MonoBehaviour
{
    private GameObject thigh;
    private GameObject knee;
    private GameObject calf;

    public float maxAngle;
    public float minAngle;
    public float currentAngle;

    public bool logAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        this.thigh = GameObject.Find("ThighTracker");
        this.knee = GameObject.Find("KneeTracker");
        this.calf = GameObject.Find("CalfTracker");

        float initialAngle = this.GetAngle();
        this.maxAngle = 0f;
        this.minAngle = 180f;
    }

    // Update is called once per frame
    void Update()
    {       
        this.currentAngle = this.GetAngle();

        if (this.currentAngle > this.maxAngle)
        {
            this.maxAngle = this.currentAngle;
        }
        if (this.currentAngle < this.minAngle)
        {
            this.minAngle = this.currentAngle;
        }

        if (logAngle)
        {
            Debug.Log(String.Format("Max angle: {0}\nMin angle: {1}", this.maxAngle, this.minAngle));
            Debug.Log(String.Format("Current angle: {0}", this.currentAngle));
        }
    }

    private float GetAngle()
    {
        Vector3 thighPos = this.thigh.transform.position;
        Vector3 kneePos = this.knee.transform.position;
        Vector3 calfPos = this.calf.transform.position;
        
        return Vector3.Angle(thighPos - kneePos, calfPos - kneePos);
    }
}