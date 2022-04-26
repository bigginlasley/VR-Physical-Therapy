using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class launch_ball : MonoBehaviour
{
    public SteamVR_Action_Boolean triggerSqueezed;
    public SteamVR_Action_Boolean buttonPressed; // TODO: Remove testing
    public SteamVR_Input_Sources handType;

    public GameObject leg;
    private ReportKneeAngle kneeAngleScript;

    private float minAngle;
    private float maxAngle;
    private bool isTriggerDown;

    private float minCalibration; // TODO: Remove testing
    private float maxCalibration;
    private bool isButtonDown;

    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        triggerSqueezed.AddOnStateUpListener(TriggerUp, handType);
        triggerSqueezed.AddOnStateDownListener(TriggerDown, handType);
        buttonPressed.AddOnStateUpListener(ButtonUp, handType);
        buttonPressed.AddOnStateDownListener(ButtonDown, handType);
        this.kneeAngleScript = leg.GetComponent<ReportKneeAngle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggerDown)
        {
            float currentAngle = this.kneeAngleScript.currentAngle;
            if (currentAngle > maxAngle)
            {
                maxAngle = currentAngle;
            }
            if (currentAngle < minAngle)
            {
                minAngle = currentAngle;
            }
        }

        if (isButtonDown)
        {
            float currentAngle = this.kneeAngleScript.currentAngle;
            if (currentAngle > maxCalibration)
            {
                maxCalibration = currentAngle;
            }
            if (currentAngle < minCalibration)
            {
                minCalibration = currentAngle;
            }
        }

        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     Debug.Log("Space bar pressed");
        //     LaunchBall();
        // }
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        Debug.Log("Trigger released");
        this.isTriggerDown = false;
        LaunchBall();
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        Debug.Log("Trigger pressed");
        this.isTriggerDown = true;
        this.minAngle = 180f;
        this.maxAngle = 0f;
    }

    public void ButtonUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        this.isButtonDown = false;
        Debug.Log("Finished calibrating");
    }

    public void ButtonDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        Debug.Log("Calibrating...");
        this.isButtonDown = true;
        this.minCalibration = 180f;
        this.maxCalibration = 0f;
    }

    // private void LaunchBall() {
    //     Debug.Log(string.Format("Max angle: {0}\nMin angle: {1}", this.maxAngle, this.minAngle));

    //     GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //     sphere.transform.position = this.transform.position;
    //     sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    //     // sphere.transform.position = new Vector3(0, 1.5f, 0);

    //     Rigidbody gameObjectsRigidBody = sphere.AddComponent<Rigidbody>();
    //     gameObjectsRigidBody.mass = 1;
    //     gameObjectsRigidBody.AddForce(Vector3.back * 100, ForceMode.VelocityChange);
    //     Vector3 bar = transform.position;
    //     PlayerPrefs.SetInt("max", 69);
    //     // Debug.Log(bar);
    //     // gameObjectsRigidBody.velocity = transform.TransformDirection(Vector3.foward * 10);
    // }

    private void LaunchBall() {
        Debug.Log(string.Format("Max angle: {0}\nMin angle: {1}", this.maxAngle, this.minAngle));

        float shotAccuracy = this.maxAngle / this.maxCalibration;
        float shotPower = this.minCalibration / this.minAngle;

        Debug.Log(string.Format("Shot accuracy: {0}\nShot power: {1}", shotAccuracy * 100, shotPower * 100));

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position;
        sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        // sphere.transform.position = new Vector3(0, 1.5f, 0);

        Rigidbody gameObjectsRigidBody = sphere.AddComponent<Rigidbody>();
        gameObjectsRigidBody.mass = 1;
        gameObjectsRigidBody.AddForce(Vector3.back * 15 * shotPower, ForceMode.VelocityChange);
        gameObjectsRigidBody.AddForce(Vector3.up * 8 * shotPower, ForceMode.VelocityChange);

        // Accuracy scale
        float leftRight;
        if (random.Next(100) < 50)
        {
            leftRight = -1;
        }
        else
        {
            leftRight = 1;
        }

        gameObjectsRigidBody.AddForce(Vector3.right * 10 * (1 - shotAccuracy) * leftRight, ForceMode.VelocityChange);

        Vector3 bar = transform.position;
        // Debug.Log(bar);
        // gameObjectsRigidBody.velocity = transform.TransformDirection(Vector3.foward * 10);
    }
}
