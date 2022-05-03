using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedGoal : MonoBehaviour
{
    public Animator animator;
    public Animator animator1;
    // Start is called before the first frame update
    void Start()
    {
        // animator1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if(GetComponet<Collider> ().GetType () == typeof(BoxCollider))
        StartCoroutine(Fail());
        Debug.Log("You're bad");

        Destroy(other.gameObject);
        // animator.SetBool("isScored", false);
        // StartCoroutine(idle());
    }
    
    IEnumerator Fail()
    {
        Debug.Log("enum");
        animator1.Play("Fail");
        animator.Play("soccer fail");
        yield return new WaitForSeconds(6);
        animator1.Play("Breathing Idle");
        animator.Play("soccer idle");
        yield return new WaitForSeconds(2);
    }
}

