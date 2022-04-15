using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReportKneeAngle : MonoBehaviour
{
    public GameObject thigh;
    public GameObject knee;
    public GameObject calf;

    public float maxAngle;
    public float minAngle;
    

    // Start is called before the first frame update
    void Start()
    {
        this.thigh = GameObject.Find("Thigh");
        this.knee = GameObject.Find("Knee");
        this.calf = GameObject.Find("Calf");

        float initialAngle = this.GetAngle();
        this.maxAngle = 0f;
        this.minAngle = 180f;
    }

    // Update is called once per frame
    void Update()
    {       
        float angle = this.GetAngle();

        if (angle > this.maxAngle)
        {
            this.maxAngle = angle;
        }
        if (angle < this.minAngle)
        {
            this.minAngle = angle;
        }

        Debug.Log(String.Format("Max angle: {0}\nMin angle: {1}", this.maxAngle, this.minAngle));
        Debug.Log(String.Format("Current angle: {0}", angle));
    }

    private float GetAngle()
    {
        Vector3 thighPos = this.thigh.transform.position;
        Vector3 kneePos = this.knee.transform.position;
        Vector3 calfPos = this.calf.transform.position;
        
        return Vector3.Angle(thighPos - kneePos, calfPos - kneePos);
    }
}