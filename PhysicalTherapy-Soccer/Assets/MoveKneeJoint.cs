using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKneeJoint : MonoBehaviour
{
    private ReportKneeAngle kneeAngleScript;
    private float lastSlider = 0f;

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
        // this.transform.Rotate(this.kneeAngleScript.currentAngle, 0f, 0f, Space.Self);
        // this.transform.eulerAngles = new Vector3(
        //     this.kneeAngleScript.currentAngle,
        //     this.transform.eulerAngles.y,
        //     this.transform.eulerAngles.z
        // );
        
        Quaternion localRotation = Quaternion.Euler(this.kneeAngleScript.currentAngle - lastSlider, 0f, 0f);
        this.transform.rotation = this.transform.rotation * localRotation;
        lastSlider = this.kneeAngleScript.currentAngle;
        // Vector3 eulers = this.transform.rotation.eulerAngles;
        // this.transform.rotation = Quaternion.Euler(new Vector3(
        //     this.kneeAngleScript.currentAngle - lastSlider,
        //     eulers.y,
        //     eulers.z
        // ));
        // lastSlider = this.kneeAngleScript.currentAngle;
        // max = 180
        // this.transform.rotation = Quaternion.Euler(-(this.kneeAngleScript.currentAngle + 180),this.rotation.,0);
        // Debug.Log(this.transform.rotation);

        // Vector3 targetRot = new Vector3(this.kneeAngleScript.currentAngle, this.transform.rotation.y, this.transform.rotation.z);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 10);
    }
}
