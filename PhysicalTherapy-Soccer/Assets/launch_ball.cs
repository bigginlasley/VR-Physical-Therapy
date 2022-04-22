using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space)) {
            Debug.Log("Space bar pressed");
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(0, 1.5f, 0);
            Rigidbody gameObjectsRigidBody = sphere.AddComponent<Rigidbody>();
            gameObjectsRigidBody.mass = 1;
            gameObjectsRigidBody.AddForce(Vector3.back * 100, ForceMode.VelocityChange);
            Vector3 bar = transform.position;
            Debug.Log(bar);
            // gameObjectsRigidBody.velocity = transform.TransformDirection(Vector3.foward * 10);
        }



    }
}
