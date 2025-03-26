using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using Valve.VR.Extras;

public class MissedGoal : MonoBehaviour
{
    public Animator animator;
    public Animator animator1;
    public GameObject encMessage;
    public GameObject blank;
    // Start is called before the first frame update
    void Start()
    {
        blank.SetActive(true);
        encMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Fail());
        Debug.Log("You're bad");

        Destroy(other.gameObject);
    }
    
    IEnumerator Fail()
    {
        Debug.Log("enum");
        animator1.Play("Fail");
        animator.Play("soccer fail");
        blank.SetActive(false);
        encMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        blank.SetActive(true);
        encMessage.SetActive(false);
        animator1.Play("Breathing Idle");
        animator.Play("soccer idle");
    }
}

