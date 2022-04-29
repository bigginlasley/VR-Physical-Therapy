using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scored : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if(GetComponet<Collider> ().GetType () == typeof(BoxCollider))
        animator.SetBool("isScored", true);
        Debug.Log("GOAL");

        Destroy(other.gameObject);
        animator.SetBool("isScored", false);
    }
}
