using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKneeJoint : MonoBehaviour
{
    private ReportKneeAngle kneeAngleScript;
    private float lastRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject leg = GameObject.Find("Leg");
        this.kneeAngleScript = leg.GetComponent<ReportKneeAngle>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {      
        Quaternion localRotation = Quaternion.Euler(this.kneeAngleScript.currentAngle - lastRot, 0f, 0f);
        this.transform.rotation = this.transform.rotation * localRotation;
        lastRot = this.kneeAngleScript.currentAngle;
    }
}
