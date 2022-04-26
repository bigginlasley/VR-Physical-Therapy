using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{
    private Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        this.exitButton = this.GetComponent<Button>();

        this.exitButton.onClick.AddListener(() =>
        {
            Debug.Log("Exit button clicked.");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
