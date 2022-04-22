using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class Navigation : MonoBehaviour
{
    public XRNode inputSource;
    private Vector2 inputAxis;
    private CharacterController character;

    private float speed = 10;
    private XROrigin rig;

    private float gravity = -9.81f;
    private float fallingSpeed;

    public LayerMask groundLayer;
    public Animator animator;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        if (Input.GetKeyDown(KeyCode.JoystickButton1) && direction == Vector3.zero)
        {
            StartCoroutine("Pass");
        }

        //Right circle trigger
        if (Input.GetKey(KeyCode.JoystickButton15))
        {
            speed += 5;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton15))
        {
            speed = 10;
        }

        character.Move(direction * Time.fixedDeltaTime * speed);

        //gravity
        bool isGrounded = checkIfGrounded();
        // Button A jumping
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            fallingSpeed = 5;
        }
        else if (isGrounded)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }


        if(direction != Vector3.zero)
        {
           animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

    }

    bool checkIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float length = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit HitInfo, length, groundLayer);
        return hasHit;
    }

    IEnumerator Pass()
    {
        animator.Play("Soccer Pass");
        yield return new WaitForSeconds(1);
    }
}