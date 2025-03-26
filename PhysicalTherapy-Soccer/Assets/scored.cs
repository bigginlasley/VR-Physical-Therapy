using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using Valve.VR.Extras;

public class scored : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    public GameObject posMessage;
    public GameObject blank;
    // Start is called before the first frame update
    void Start()
    {
        blank.SetActive(true);
        posMessage.SetActive(false);

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
        blank.SetActive(false);
        posMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        blank.SetActive(true);
        posMessage.SetActive(false);
        animator.Play("Breathing Idle");
        animator2.Play("soccer idle");

        // yield return new WaitForSeconds(2);
    }

}
