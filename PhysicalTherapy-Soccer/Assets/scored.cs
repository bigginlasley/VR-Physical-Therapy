using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scored : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(idle());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if(GetComponet<Collider> ().GetType () == typeof(BoxCollider))
        StartCoroutine(victory());
        Debug.Log("GOAL");

        Destroy(other.gameObject);
        // animator.SetBool("isScored", false);
        // StartCoroutine(idle());
    }
    
    IEnumerator victory()
    {
        Debug.Log("enum");
        animator.Play("Cheering");
        animator2.Play("soccer cheering");
        yield return new WaitForSeconds(6);
        animator.Play("Breathing Idle");
        animator2.Play("soccer idle");
        yield return new WaitForSeconds(2);
    }

}
