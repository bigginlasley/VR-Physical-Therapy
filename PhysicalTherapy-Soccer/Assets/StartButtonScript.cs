using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    private Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        this.startButton = this.GetComponent<Button>();

        this.startButton.onClick.AddListener(() =>
        {
            Debug.Log("Start button clicked.");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
