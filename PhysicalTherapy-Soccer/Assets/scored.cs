using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scored : MonoBehaviour
{
    public Animator animator;
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
        yield return new WaitForSeconds(6);
        animator.Play("Breathing Idle");
        yield return new WaitForSeconds(2);
    }

    IEnumerator idle()
    {
        animator.Play("Idle");
        yield return new WaitForSeconds(2);
    }


}
